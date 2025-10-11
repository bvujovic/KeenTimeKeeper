using KeenTimeKeeper.Classes;
using System.Text.Json;

namespace KeenTimeKeeper
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                ds.ReadXml(Utils.GetDataSetFileName());
                var times = ds.Settings.ReadString(nameof(lstTimerTimes), string.Empty)!;
                if (!string.IsNullOrWhiteSpace(times))
                {
                    var arr = JsonSerializer.Deserialize<string[]>(times);
                    if (arr != null)
                    {
                        lstTimerTimes.Items.Clear();
                        lstTimerTimes.Items.AddRange(arr);
                    }
                }
                if (lstTimerTimes.Items.Count > 0)
                {
                    lstTimerTimes.SelectedIndex = 0;
                    lstTimerTimes.Focus();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private readonly Ds ds = new();

        private readonly TimerKeeper timerKeeper = new();

        private void LstTimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTimerTimes.SelectedItem != null && !timerKeeper.IsStarted)
                lblTimerTime.Text = lstTimerTimes.SelectedItem.ToString();
        }

        private void CtxTimerTimes_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tsmiTimerRemoveTime.Enabled = lstTimerTimes.SelectedItem != null;
        }

        private void TsmiTimerRemoveTime_Click(object sender, EventArgs e)
        {
            if (lstTimerTimes.SelectedItem != null)
                lstTimerTimes.Items.Remove(lstTimerTimes.SelectedItem);
        }

        private void TxtTimerNewTime_KeyDown(object sender, KeyEventArgs e)
        {
            // add time from txt to lst if it's valid (format 00:00)
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    var secs = timerKeeper.ParseTime(txtTimerNewTime.Text, false);
                    lstTimerTimes.Items.Add(TimerKeeper.PrintTime(secs));
                    txtTimerNewTime.Clear();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void LstTimer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt && (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down))
            {
                if (e.KeyCode == Keys.Up && lstTimerTimes.SelectedIndex == 0
                    || e.KeyCode == Keys.Down && lstTimerTimes.SelectedIndex == lstTimerTimes.Items.Count - 1)
                    return;
                var d = e.KeyCode == Keys.Down ? +1 : -1;
                var i = lstTimerTimes.SelectedIndex;
                (lstTimerTimes.Items[i], lstTimerTimes.Items[i + d]) = (lstTimerTimes.Items[i + d], lstTimerTimes.Items[i]);
                lstTimerTimes.SelectedIndex += d;
            }
            if (e.KeyCode == Keys.Enter && lstTimerTimes.SelectedItem != null)
                //btnTimerStartCancel.PerformClick();
                StartTimerFromTheList();
        }

        private void TimTimer_Tick(object sender, EventArgs e)
        {
            timerKeeper.Tick();
            lblTimerTime.Text = timerKeeper.PrintTime();
            if (!timerKeeper.IsStarted)
            {
                timTimer.Stop();
                Application.DoEvents();
                //using var soundPlayer = new SoundPlayer(@"c:\Windows\Media\notify.wav");
                //using var soundPlayer = new SoundPlayer(@"c:\Windows\Media\tada.wav");
                //soundPlayer.Play();
                //const int itv = 250;
                //for (int i = 0; i < 3; i++)
                //{
                //    TimerBeep(itv);
                //    Thread.Sleep(itv);
                //}
                TimerBeep(3);
                btnTimerStartCancel.Text = "Start";
            }
        }

        private static void TimerBeep(int count = 1, int itv = 250)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Beep(1500, itv);
                Thread.Sleep(itv);
            }
        }

        private void BtnTimerStartCancel_Click(object sender, EventArgs e)
        {
            StartStopTimer();
        }

        private void StartStopTimer()
        {
            if (!timerKeeper.IsStarted)
                timerKeeper.ParseTime(lblTimerTime.Text, true);
            else
                lblTimerTime.Text = lstTimerTimes.SelectedItem?.ToString();
            timTimer.Enabled = timerKeeper.IsStarted = !timerKeeper.IsStarted;
            btnTimerStartCancel.Text = timerKeeper.IsStarted ? "Cancel" : "Start";
            TimerBeep();
        }

        private void StartTimerFromTheList()
        {
            StartStopTimer();
            // if first StartStopTimer() call stopped the timer, start it again
            if (!timerKeeper.IsStarted)
                StartStopTimer();
        }

        private void LstTimer_DoubleClick(object sender, EventArgs e)
        {
            StartTimerFromTheList();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ds.Settings.SaveSetting(nameof(lstTimerTimes), JsonSerializer.Serialize(lstTimerTimes.Items));
                ds.WriteXml(Utils.GetDataSetFileName());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
