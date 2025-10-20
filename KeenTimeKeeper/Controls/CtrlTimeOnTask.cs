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

        //private void ChkPause_MouseUp(object sender, MouseEventArgs e)
        //    => ChangeText(chkPause, e);

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
                var d = TimeChunkMinutes * 60;
                if (e.Button == MouseButtons.Left)
                    timeInSecs += d;
                else if (e.Button == MouseButtons.Right)
                    timeInSecs -= d;
                DisplayTime();
            }
            catch { MessageBox.Show("Invalid number format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        /// <summary>Indicates whether the timer is currently running.</summary>
        private bool isRunning = false;
        /// <summary>Measured time in seconds.</summary>
        private int timeInSecs;
        private DateTime taskStarted;
        //private bool isPaused = true;
        private int TimeChunkMinutes => (int)numTimeChunk.Value;

        private void BtnStart_Click(object sender, EventArgs e)
        {
            isRunning = !isRunning;
            btnStart.Text = isRunning ? "Pause" : "Start";
            tim.Enabled = isRunning;
            DisplayStatus();
        }

        private void Tim_Tick(object sender, EventArgs e)
        {
            if (isRunning)
            {
                timeInSecs++;
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
            lblProgress.Text = $"Chunk: {currChunkMinutes}/{TimeChunkMinutes} min, "
                + $"Total: {minutes} min";

            //if (TaskbarManager.IsPlatformSupported)
            TaskbarManager.Instance.SetProgressValue(currChunkMinutes, TimeChunkMinutes);
            Debug.WriteLine(timeInSecs);
        }

        private void DisplayStatus()
        {
            bool isItOn = isRunning;
            lblTimerStatus.Text = isItOn ? "ON" : "OFF";
            lblTimerStatus.BackColor = isItOn ? Color.LightGreen : Color.Yellow;
            TaskbarManager.Instance.SetProgressState(isItOn ? TaskbarProgressBarState.Normal : TaskbarProgressBarState.Paused);
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
