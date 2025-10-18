using KeenTimeKeeper.Forms;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;

namespace KeenTimeKeeper.Controls
{
    public partial class CtrlTimeOnTask : UserControl
    {
        public CtrlTimeOnTask()
        {
            InitializeComponent();
        }

        private void CtrlTimeOnTask_Load(object sender, EventArgs e)
        {
            taskStarted = DateTime.Now;
            DisplayTime();
            DisplayStatus();
        }

        /// <summary>Changes the text of a control on right-click using a dialog.</summary>
        private static void ChangeText(Control ctrl, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var frm = new FrmTextInput(ctrl.Text);
                if (frm.ShowDialog() == DialogResult.OK)
                    ctrl.Text = frm.InputText;
            }
        }

        private void LblTaskName_MouseUp(object sender, MouseEventArgs e)
            => ChangeText(lblTaskName, e);

        private void BtnStart_MouseUp(object sender, MouseEventArgs e)
            => ChangeText(btnStart, e);

        private void ChkPause_MouseUp(object sender, MouseEventArgs e)
            => ChangeText(chkPause, e);

        private void LblCurrentChunkMinutes_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var frm = new FrmTextInput(lblCurrentChunkMinutes.Text);
                if (frm.ShowDialog() == DialogResult.OK && int.TryParse(frm.InputText, out _))
                    lblCurrentChunkMinutes.Text = frm.InputText;
            }
        }

        private void LblChunkCount_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                    lblChunkCount.Text = (int.Parse(lblChunkCount.Text) + 1).ToString();
                else if (e.Button == MouseButtons.Right)
                    lblChunkCount.Text = Math.Max(0, int.Parse(lblChunkCount.Text) - 1).ToString();
            }
            catch { MessageBox.Show("Invalid number format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        /// <summary>Indicates whether the timer is currently running.</summary>
        private bool isRunning = false;
        /// <summary>Measured time in seconds.</summary>
        private int timeInSecs;
        private DateTime taskStarted;
        private bool IsPaused => chkPause.Checked;
        private int TimeChunkMinutes => (int)numTimeChunk.Value;

        private void BtnStart_Click(object sender, EventArgs e)
        {
            //* Check if already running and some substantial time has passed (e.g. more than a minute)
            if (isRunning && timeInSecs >= 60 && !IsPaused)
            {
                // Log the time chunk
                //int chunkMinutes = int.Parse(lblCurrentChunkMinutes.Text);
                //int chunkCount = int.Parse(lblChunkCount.Text) + 1;
                //lblChunkCount.Text = chunkCount.ToString();
                //MessageBox.Show($"Logged {chunkMinutes} minutes for task '{lblTaskName.Text}'. Total chunks: {chunkCount}.", "Time Logged", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            isRunning = !isRunning;
            btnStart.Text = isRunning ? "Stop" : "Start";
            tim.Enabled = isRunning;

            DisplayStatus();
        }

        private void ChkPause_CheckedChanged(object sender, EventArgs e)
        {
            DisplayStatus();
            tim.Enabled = isRunning && !IsPaused;
        }

        private void Tim_Tick(object sender, EventArgs e)
        {
            if (isRunning)
            {
                timeInSecs++;
                //lblCurrentChunkMinutes.Text = (timeInSecs / 60).ToString();
                DisplayTime();
                DisplayStatus();
            }
        }

        private void DisplayTime()
        {
            int minutes = timeInSecs / 60;
            var currChunkMinutes = minutes % TimeChunkMinutes;
            int seconds = timeInSecs % 60;
            if (seconds == 0)
                lblCurrentChunkMinutes.Text = (currChunkMinutes).ToString();
            lblChunkCount.Text = (minutes / TimeChunkMinutes).ToString();

            //var totalTime = DateTime.Now.Subtract(taskStarted);
            var totalMinutes = (int)DateTime.Now.Subtract(taskStarted).TotalMinutes;
            var percent = totalMinutes != 0 ? (double)minutes / totalMinutes : 100;
            lblProgress.Text = $"Working: {currChunkMinutes}/{totalMinutes} min, {percent:P0}";
            //if (TaskbarManager.IsPlatformSupported)
            TaskbarManager.Instance.SetProgressValue(currChunkMinutes, TimeChunkMinutes);
        }

        private void DisplayStatus()
        {
            bool isItOn = isRunning && !IsPaused;
            lblTimerStatus.Text = isItOn ? "ON" : "OFF";
            lblTimerStatus.BackColor = isItOn ? Color.LightGreen : Color.Yellow;
            TaskbarManager.Instance.SetProgressState(isItOn ? TaskbarProgressBarState.Normal : TaskbarProgressBarState.Paused);
        }
    }
}
