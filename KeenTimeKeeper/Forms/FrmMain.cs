using KeenTimeKeeper.Classes;

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
            if (lstTimer.Items.Count > 0)
            {
                lstTimer.SelectedIndex = 0;
                lstTimer.Focus();
            }
        }

        private readonly TimerKeeper timerKeeper = new();

        private void LstTimer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTimer.SelectedItem != null)
                lblTimerTime.Text = lstTimer.SelectedItem.ToString();
        }

        private void CtxTimerTimes_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tsmiTimerRemoveTime.Enabled = lstTimer.SelectedItem != null;
        }

        private void TsmiTimerRemoveTime_Click(object sender, EventArgs e)
        {
            if (lstTimer.SelectedItem != null)
                lstTimer.Items.Remove(lstTimer.SelectedItem);
        }

        private void TxtTimerNewTime_KeyDown(object sender, KeyEventArgs e)
        {
            // add time from txt to lst if it's valid (00:00)
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    var secs = timerKeeper.ParseTime(txtTimerNewTime.Text, false);
                    lstTimer.Items.Add(TimerKeeper.PrintTime(secs));
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
                if (e.KeyCode == Keys.Up && lstTimer.SelectedIndex == 0
                    || e.KeyCode == Keys.Down && lstTimer.SelectedIndex == lstTimer.Items.Count - 1)
                    return;
                var d = e.KeyCode == Keys.Down ? +1 : -1;
                var i = lstTimer.SelectedIndex;
                (lstTimer.Items[i], lstTimer.Items[i + d]) = (lstTimer.Items[i + d], lstTimer.Items[i]);
                lstTimer.SelectedIndex += d;
            }
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
                const int itv = 250;
                for (int i = 0; i < 3; i++)
                {
                    Console.Beep(1500, itv);
                    Thread.Sleep(itv);
                }
            }
        }

        private void BtnTimerStartCancel_Click(object sender, EventArgs e)
        {
            if (!timerKeeper.IsStarted)
                timerKeeper.ParseTime(lblTimerTime.Text, true);
            timTimer.Enabled = timerKeeper.IsStarted = !timerKeeper.IsStarted;
        }
    }
}
