using KeenTimeKeeper.Classes;
using Microsoft.WindowsAPICodePack.Taskbar;
using System.ComponentModel;
using System.Text.Json;

namespace KeenTimeKeeper.Controls
{
    public partial class CtrlTimer : CtrlMode
    {
        public CtrlTimer()
        {
            InitializeComponent();
        }

        private void CtrlTimer_Load(object sender, EventArgs e)
        {
            timDelayLoad.Start();
        }

        private void TimDelayLoad_Tick(object sender, EventArgs e)
        {
            if (FrmMain?.IsLoadFinished == true)
            {
                TaskbarManager.Instance.SetProgressValue(timerKeeper.ElapsedSeconds, timerKeeper.TotalSeconds);
                TaskbarManager.Instance.SetProgressState(timerKeeper.IsStarted ? TaskbarProgressBarState.Normal : TaskbarProgressBarState.Paused);
                timDelayLoad.Stop();
            }
        }

        private readonly TimerKeeper timerKeeper = new();

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] TimesList
        {
            get { return lstTimes.Items.Cast<string>().ToArray(); }
            set
            {
                lstTimes.Items.Clear();
                if (value != null)
                    lstTimes.Items.AddRange(value);
            }
        }

        public void LoadTimesList(string? times)
        {
            if (!string.IsNullOrWhiteSpace(times))
            {
                var arr = JsonSerializer.Deserialize<string[]>(times);
                if (arr != null)
                {
                    lstTimes.Items.Clear();
                    lstTimes.Items.AddRange(arr);
                }
            }
            if (lstTimes.Items.Count > 0)
            {
                lstTimes.SelectedIndex = 0;
                lstTimes.Focus();
            }
        }

        private void LstTimes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTimes.SelectedItem != null && !timerKeeper.IsStarted)
                lblCurrentTime.Text = lstTimes.SelectedItem.ToString();
        }

        private void CtxTimes_Opening(object sender, CancelEventArgs e)
        {
            tsmiTimerRemoveTime.Enabled = lstTimes.SelectedItem != null;
        }

        private void TsmiRemoveTime_Click(object sender, EventArgs e)
        {
            if (lstTimes.SelectedItem != null)
                lstTimes.Items.Remove(lstTimes.SelectedItem);
        }

        private void TxtNewTime_KeyDown(object sender, KeyEventArgs e)
        {
            // add time from txt to lst if it's valid (format 00:00)
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(txtNewTime.Text))
                    lstTimes.Focus();
                else
                    try
                    {
                        var secs = timerKeeper.ParseTime(txtNewTime.Text, false);
                        if (secs <= 0)
                            throw new Exception("Time must be greater than 00:00");
                        lstTimes.Items.Add(TimerKeeper.PrintTime(secs));
                        txtNewTime.Clear();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                lstTimes.Focus();
        }

        private void LstTimes_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt && (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down))
            {
                if (e.KeyCode == Keys.Up && lstTimes.SelectedIndex == 0
                    || e.KeyCode == Keys.Down && lstTimes.SelectedIndex == lstTimes.Items.Count - 1)
                    return;
                var d = e.KeyCode == Keys.Down ? +1 : -1;
                var i = lstTimes.SelectedIndex;
                (lstTimes.Items[i], lstTimes.Items[i + d]) = (lstTimes.Items[i + d], lstTimes.Items[i]);
                lstTimes.SelectedIndex += d;
            }
            if (e.KeyCode == Keys.Enter && lstTimes.SelectedItem != null)
                StartTimerFromTheList();
        }

        public override void CtrlKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && timerKeeper.IsStarted)
            {
                StartStopTimer();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void TimTimer_Tick(object sender, EventArgs e)
        {
            timerKeeper.Tick();
            lblCurrentTime.Text = timerKeeper.PrintTime();
            if (!timerKeeper.IsStarted)
            {
                OnTimerEnded();
                TaskbarManager.Instance.SetProgressValue(1, 1);
                TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                timTimer.Stop();
                Application.DoEvents();
                TimerBeep(3);
                btnStartCancel.Text = "Start";
            }
            TaskbarManager.Instance.SetProgressValue(timerKeeper.ElapsedSeconds, timerKeeper.TotalSeconds);
            TaskbarManager.Instance.SetProgressState(timerKeeper.IsStarted ? TaskbarProgressBarState.Normal : TaskbarProgressBarState.Paused);
        }

        private static void TimerBeep(int count = 1, int itv = 250)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Beep(1500, itv);
                Thread.Sleep(itv);
            }
        }

        private void BtnStartCancel_Click(object sender, EventArgs e)
        {
            StartStopTimer();
        }

        private void StartStopTimer()
        {
            if (!timerKeeper.IsStarted)
                timerKeeper.ParseTime(lblCurrentTime.Text, true);
            else
                lblCurrentTime.Text = lstTimes.SelectedItem?.ToString();
            timTimer.Enabled = timerKeeper.IsStarted = !timerKeeper.IsStarted;
            btnStartCancel.Text = timerKeeper.IsStarted ? "Cancel" : "Start";
            if (timerKeeper.IsStarted)
                OnStartTimerClicked();
            TimerBeep();
        }

        private void StartTimerFromTheList()
        {
            StartStopTimer();
            // if first StartStopTimer() call stopped the timer, start it again
            if (!timerKeeper.IsStarted)
                StartStopTimer();
        }

        private void LstTimes_DoubleClick(object sender, EventArgs e)
        {
            StartTimerFromTheList();
        }

        public override void LoadSettings(Ds ds)
        {
            var times = ds.Settings.ReadString(nameof(TimesList), string.Empty)!;
            LoadTimesList(times);
        }

        public override void SaveSettings(Ds ds)
        {
            ds.Settings.WriteSetting(nameof(TimesList), JsonSerializer.Serialize(TimesList));
        }
    }
}
