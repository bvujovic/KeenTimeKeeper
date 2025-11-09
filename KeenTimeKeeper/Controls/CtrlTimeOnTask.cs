using KeenTimeKeeper.Classes;
using KeenTimeKeeper.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.Diagnostics;

namespace KeenTimeKeeper.Controls
{
    public partial class CtrlTimeOnTask : CtrlMode
    {
        public CtrlTimeOnTask()
        {
            InitializeComponent();
        }

        private void CtrlTimeOnTask_Load(object sender, EventArgs e)
        {
            timDelayDisplay.Start();
        }

        /// <summary>Changes the text of a control on right-click using a dialog.</summary>
        private void ChangeText(Control ctrl, MouseEventArgs e, bool isItInt = false)
        {
            if (e.Button != MouseButtons.Right)
                return;

            string? caption = null;
            if (isItInt)
            {
                if (ctrl == lblCurrentChunkMinutes)
                    caption = $"Enter minutes (0-{TimeChunkMinutes - 1})";
                else
                    caption = "Enter a number";
            }
            if (ctrl == lblTaskName)
                caption = "Select or add new Task";
            var prevText = lblTaskName.Text;
            var frm = new FrmTextInput(ctrl.Text, caption);
            if (ctrl == lblTaskName)
            {
                var ti = taskItems.Find(it => it.Name == lblTaskName.Text);
                if (ti != null)
                    ti.TimeInSecs = timeInSecs;
                frm.TaskItems = taskItems;
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (isItInt && !int.TryParse(frm.InputText, out _))
                    MessageBox.Show("Invalid number format.", "Error"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    ctrl.Text = frm.InputText;
                if (ctrl == lblTaskName && lblTaskName.Text != prevText)
                {
                    timeInSecs = frm.SelectedTaskTimeInSecs ?? 0;
                    DisplayTime();
                }
            }
            lastChangeTextClose = DateTime.Now;
        }

        private DateTime lastChangeTextClose = DateTime.MinValue;

        private bool IsRecentlyChangedText()
            => (DateTime.Now - lastChangeTextClose).TotalMilliseconds < 250;

        private void LblTaskName_MouseUp(object sender, MouseEventArgs e)
        {
            //var prevText = lblTaskName.Text;
            ChangeText(lblTaskName, e);
            //if (lblTaskName.Text != prevText)
            //{
            //    if (MessageBox.Show("Do you want to reset time?", "New Task?"
            //        , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        ResetTime();
            //    lastChangeTextClose = DateTime.Now;
            //}
        }

        private void ResetTime()
        {
            timeInSecs = 0;
            DisplayTime();
        }

        private void TsmiResetTime_Click(object sender, EventArgs e)
        {
            ResetTime();
        }

        private void LblCurrentChunkMinutes_MouseUp(object sender, MouseEventArgs e)
        {
            ChangeText(lblCurrentChunkMinutes, e, true);
            timeInSecs = int.Parse(lblChunkCount.Text) * TimeChunkMinutes * 60
                + int.Parse(lblCurrentChunkMinutes.Text) * 60;
            DisplayTime();
        }

        private void LblChunkCount_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                var d = TimeChunkMinutes * 60;
                if (e.Button == MouseButtons.Left)
                    timeInSecs += d;
                else if (e.Button == MouseButtons.Right && timeInSecs >= d)
                    timeInSecs -= d;
                DisplayTime();
            }
            catch { MessageBox.Show("Invalid number format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        /// <summary>Indicates whether the timer is currently running.</summary>
        private bool isRunning = false;
        /// <summary>Measured time in seconds.</summary>
        private int timeInSecs;

        private int TimeChunkMinutes => (int)numTimeChunk.Value;

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (cancelBtnStartClick)
                return;
            cancelBtnStartClick = true;
            timBtnStart.Start();
            isRunning = !isRunning;
            tim.Enabled = isRunning;
            DisplayTime();
            if (isRunning)
                FrmMain!.WindowState = FormWindowState.Minimized;
        }

        private bool cancelBtnStartClick = false;

        private void TimBtnStart_Tick(object sender, EventArgs e)
            => cancelBtnStartClick = false;

        private void Tim_Tick(object sender, EventArgs e)
        {
            if (isRunning)
            {
                timeInSecs++;
                DisplayTime();
                var minutes = timeInSecs / 60;
                // Time chunk completed -> notify user by showing the main window and pause the timer
                if (minutes > 0 && minutes % TimeChunkMinutes == 0 && timeInSecs % 60 == 0)
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    FrmMain!.WindowState = FormWindowState.Minimized;
                    FrmMain!.WindowState = FormWindowState.Normal;
                    btnStart.PerformClick();
                }
            }
        }

        private void DisplayTime()
        {
            var minutes = timeInSecs / 60;
            var currChunkMinutes = minutes % TimeChunkMinutes;
            lblCurrentChunkMinutes.Text = (currChunkMinutes).ToString();
            lblChunkCount.Text = (minutes / TimeChunkMinutes).ToString();
            lblTotalMinutes.Text = $"Total: {minutes} min";
            btnStart.Text = isRunning ? "Pause" : (timeInSecs == 0 ? "Start" : "Resume");
            var isItOn = isRunning;
            lblTotalTime.Text = Utils.SecsToMS(timeInSecs);
            lblTotalTime.BackColor = isItOn ? Color.LightGreen : Color.Yellow;
            if (FrmMain?.IsLoadFinished == true)
            {
                TaskbarManager.Instance.SetProgressValue(currChunkMinutes, TimeChunkMinutes);
                TaskbarManager.Instance.SetProgressState(isItOn ? TaskbarProgressBarState.Normal : TaskbarProgressBarState.Paused);
                timDelayDisplay.Stop();
            }
            // Debug.WriteLine(timeInSecs);
        }

        private void TimDelayDisplay_Tick(object sender, EventArgs e)
        {
            DisplayTime();
        }

        private void NumTimeChunk_ValueChanged(object sender, EventArgs e)
        {
            DisplayTime();
        }

        public override void LoadSettings(Ds ds)
        {
            timeInSecs = ds.Settings.ReadInt(nameof(timeInSecs), 0);
            lblTaskName.Text = ds.Settings.ReadString(nameof(lblTaskName), lblTaskName.Text)!;
            numTimeChunk.Value = ds.Settings.ReadInt(nameof(numTimeChunk), (int)numTimeChunk.Value);
            var tasks = ds.Settings.ReadGroup(nameof(lblTaskName));
            foreach (var s in tasks)
            {
                taskItems.Add(new TaskItem
                {
                    Name = s.Name,
                    TimeInSecs = int.TryParse(s.Value, out var secs) ? secs : 0
                });
            }
            var t = taskItems.Find(it => it.Name == lblTaskName.Text);
            if (t != null)
                timeInSecs = t.TimeInSecs;
            DisplayTime();
        }

        private readonly List<TaskItem> taskItems = [];

        public override void SaveSettings(Ds ds)
        {
            var t = taskItems.Find(it => it.Name == lblTaskName.Text);
            if (t != null)
                t.TimeInSecs = timeInSecs;
            else
                taskItems.Add(new TaskItem { Name = lblTaskName.Text, TimeInSecs = timeInSecs });
            foreach (var ti in taskItems)
                ds.Settings.SaveSetting(nameof(lblTaskName), ti.Name, ti.TimeInSecs.ToString());
            ds.Settings.SaveSetting(nameof(lblTaskName), lblTaskName.Text);
            ds.Settings.SaveSetting(nameof(numTimeChunk), numTimeChunk.Value.ToString());
        }

        public override void CtrlKeyUp(KeyEventArgs e)
        {
            // Space for toggling timer, Enter for starting time, Escape for stopping time
            if (e.KeyCode == Keys.Space
                || e.KeyCode == Keys.Enter && !isRunning && !IsRecentlyChangedText()
                || e.KeyCode == Keys.Escape && isRunning && !IsRecentlyChangedText())
            {
                btnStart.Focus();
                btnStart.PerformClick();
                //e.Handled = true;
                //e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.F2)
                LblTaskName_MouseUp(lblTaskName, new MouseEventArgs(MouseButtons.Right, 1, 0, 0, 0));
        }
    }
}
