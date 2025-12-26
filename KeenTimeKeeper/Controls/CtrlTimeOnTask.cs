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
            try
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
                {
                    caption = "Select or add new Task";
                    Data.UpdateDataSetFromFile(FrmMain!.DataSet);
                }
                var prevText = (ctrl == lblTaskName) ? (CurrentTask != null ? CurrentTask.Name : Ds.TasksRow.DefaultTaskName)
                    : lblTaskName.Text;
                var frm = new FrmTextInput(ctrl.Text, caption);
                if (ctrl == lblTaskName)
                {
                    var task = tasks.Find(prevText);
                    if (task != null)
                        task.TimeInSecs = timeInSecs;
                    frm.Tasks = tasks;
                    frm.SetToListMode();
                }
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (isItInt)
                    {
                        if (!int.TryParse(frm.InputText, out int val))
                            MessageBox.Show("Invalid number format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else if (ctrl == lblCurrentChunkMinutes && (val < 0 || val >= TimeChunkMinutes))
                            MessageBox.Show($"Value must be between 0 and {TimeChunkMinutes - 1}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            ctrl.Text = val.ToString();
                    }

                    var strFrmInput = frm.InputText;
                    if (ctrl == lblTaskName && prevText != strFrmInput)
                    {
                        var task = tasks.Find(strFrmInput);
                        if (task != null)
                            task.LastUsed = DateTime.Now;
                        else
                            tasks.AddTasksRow(strFrmInput, Ds.TasksRow.DefaultTaskTimeInSecs, Ds.TasksRow.DefaultChunkMinutes, DateTime.Now, "");
                        CurrentTask = task;
                        timeInSecs = CurrentTask != null ? CurrentTask.TimeInSecs : Ds.TasksRow.DefaultTaskTimeInSecs;
                    }
                }
                lastChangeTextClose = DateTime.Now;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private DateTime lastChangeTextClose = DateTime.MinValue;

        private bool IsRecentlyChangedText()
            => (DateTime.Now - lastChangeTextClose).TotalMilliseconds < 250;

        private void LblTaskName_MouseUp(object sender, MouseEventArgs e)
        {
            ChangeText(lblTaskName, e);
        }

        private void ResetTime()
        {
            timeInSecs = 0;
            DisplayTime();
        }

        private void TsmiResetTime_Click(object sender, EventArgs e)
        {
            if (isRunning)
                btnStart.PerformClick();
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
                OnStartTimerClicked();
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
                    OnTimerEnded();
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
            tasks = ds.Tasks;
            var taskName = ds.Settings.ReadString(nameof(CurrentTask), string.Empty)!;
            //CurrentTask = FindTask(taskName);
            CurrentTask = tasks.Find(taskName);
        }

        //private Ds.TasksRow? FindTask(string taskName)
        //    => tasks.FirstOrDefault(it => it.Name == taskName);

        private Ds.TasksDataTable tasks;

        private Ds.TasksRow? currentTask;

        public Ds.TasksRow? CurrentTask
        {
            get => currentTask;
            set
            {
                currentTask = value;
                lblTaskName.Text = (currentTask != null) ? currentTask.Name : Ds.TasksRow.DefaultTaskName;
                timeInSecs = (currentTask != null) ? currentTask.TimeInSecs : Ds.TasksRow.DefaultTaskTimeInSecs;
                numTimeChunk.Value = (currentTask != null) ? currentTask.ChunkMinutes : Ds.TasksRow.DefaultChunkMinutes;
                DisplayTime();
            }
        }

        public override void SaveSettings(Ds ds)
        {
            if (currentTask != null)
            {
                currentTask.TimeInSecs = timeInSecs;
                currentTask.ChunkMinutes = TimeChunkMinutes;
                currentTask.LastUsed = DateTime.Now;
            }
            ds.Settings.SaveSetting(nameof(CurrentTask), CurrentTask?.Name);
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
            }
            if (e.KeyCode == Keys.F2)
                LblTaskName_MouseUp(lblTaskName, new MouseEventArgs(MouseButtons.Right, 1, 0, 0, 0));
        }
    }
}
