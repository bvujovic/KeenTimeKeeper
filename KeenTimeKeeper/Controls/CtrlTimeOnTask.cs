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
            //taskStarted = DateTime.Now;
            DisplayTime();
            //DisplayStatus();
        }

        /// <summary>Changes the text of a control on right-click using a dialog.</summary>
        private static void ChangeText(Control ctrl, MouseEventArgs e, bool isItInt = false)
        {
            if (e.Button == MouseButtons.Right)
            {
                var frm = new FrmTextInput(ctrl.Text);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (isItInt && !int.TryParse(frm.InputText, out _))
                        MessageBox.Show("Invalid number format.", "Error"
                            , MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        ctrl.Text = frm.InputText;
                }
            }
        }

        private void LblTaskName_MouseUp(object sender, MouseEventArgs e)
        {
            var prevText = lblTaskName.Text;
            ChangeText(lblTaskName, e);
            if (lblTaskName.Text != prevText)
            {
                if (MessageBox.Show("Do you want to reset time?", "New Task?"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    ResetTime();
            }
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

        private void BtnStart_MouseUp(object sender, MouseEventArgs e)
            => ChangeText(btnStart, e);

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

        private FrmMain FrmMain => this.Parent as FrmMain ?? throw new InvalidOperationException("Parent form is not FrmMain.");

        /// <summary>Indicates whether the timer is currently running.</summary>
        private bool isRunning = false;
        /// <summary>Measured time in seconds.</summary>
        private int timeInSecs;
        //private DateTime taskStarted;

        private int TimeChunkMinutes => (int)numTimeChunk.Value;

        private void BtnStart_Click(object sender, EventArgs e)
        {
            isRunning = !isRunning;
            btnStart.Text = isRunning ? "Pause" : "Start";
            tim.Enabled = isRunning;
            //DisplayStatus();
            if (isRunning)
                FrmMain.WindowState = FormWindowState.Minimized;
        }

        private void Tim_Tick(object sender, EventArgs e)
        {
            if (isRunning)
            {
                timeInSecs++;
                DisplayTime();
                var minutes = timeInSecs / 60;
                if (minutes > 0 && minutes % TimeChunkMinutes == 0 && timeInSecs % 60 == 0)
                { // Time chunk completed
                    System.Media.SystemSounds.Exclamation.Play();
                    FrmMain.WindowState = FormWindowState.Minimized;
                    FrmMain.WindowState = FormWindowState.Normal;
                    btnStart.PerformClick();
                }
            }
        }

        private void DisplayTime()
        {
            var minutes = timeInSecs / 60;
            var currChunkMinutes = minutes % TimeChunkMinutes;
            //var seconds = timeInSecs % 60;
            //if (seconds == 0)
                lblCurrentChunkMinutes.Text = (currChunkMinutes).ToString();
            lblChunkCount.Text = (minutes / TimeChunkMinutes).ToString();
            lblProgress.Text = $"Total: {minutes} min";

            var isItOn = isRunning;
            lblTimerStatus.Text = isItOn ? "ON" : "OFF";
            lblTimerStatus.BackColor = isItOn ? Color.LightGreen : Color.Yellow;
            if (FrmMain.IsLoadFinished)
            {
                TaskbarManager.Instance.SetProgressValue(currChunkMinutes, TimeChunkMinutes);
                TaskbarManager.Instance.SetProgressState(isItOn ? TaskbarProgressBarState.Normal : TaskbarProgressBarState.Paused);
            }
            Debug.WriteLine(timeInSecs);
        }

        //private void DisplayStatus()
        //{
        //    bool isItOn = isRunning;
        //    lblTimerStatus.Text = isItOn ? "ON" : "OFF";
        //    lblTimerStatus.BackColor = isItOn ? Color.LightGreen : Color.Yellow;
        //    if (FrmMain.IsLoadFinished)
        //        TaskbarManager.Instance.SetProgressState(isItOn ? TaskbarProgressBarState.Normal : TaskbarProgressBarState.Paused);
        //}

        private void NumTimeChunk_ValueChanged(object sender, EventArgs e)
        {
            DisplayTime();
        }

        public override void LoadSettings(Ds ds)
        {
            lblTaskName.Text = ds.Settings.ReadString(nameof(lblTaskName), lblTaskName.Text)!;
            btnStart.Text = ds.Settings.ReadString(nameof(btnStart), btnStart.Text)!;
            numTimeChunk.Value = ds.Settings.ReadInt(nameof(numTimeChunk), (int)numTimeChunk.Value);
            timeInSecs = ds.Settings.ReadInt(nameof(timeInSecs), 0);
            DisplayTime();
        }
    }
}
