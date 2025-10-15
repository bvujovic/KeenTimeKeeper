using KeenTimeKeeper.Classes;
using System;
using System.Text.Json;

namespace KeenTimeKeeper.Controls
{
    public partial class CtrlTimer : UserControl
    {
        public CtrlTimer()
        {
            InitializeComponent();
        }

        private readonly TimerKeeper timerKeeper = new();

        public string[] TimesList
        {
            get { return lstTimerTimes.Items.Cast<string>().ToArray(); }
            set
            {
                lstTimerTimes.Items.Clear();
                if (value != null)
                    lstTimerTimes.Items.AddRange(value);
            }
        }

        public void LoadTimesList(string? times)
        {
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

        private void LstTimerTimes_SelectedIndexChanged(object sender, EventArgs e)
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
                if (string.IsNullOrWhiteSpace(txtTimerNewTime.Text))
                    lstTimerTimes.Focus();
                else
                    try
                    {
                        var secs = timerKeeper.ParseTime(txtTimerNewTime.Text, false);
                        lstTimerTimes.Items.Add(TimerKeeper.PrintTime(secs));
                        txtTimerNewTime.Clear();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void LstTimerTimes_KeyUp(object sender, KeyEventArgs e)
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
                StartTimerFromTheList();
        }

        //* ovo bi se moglo izvesti samo ako bi se Escape detektovao na glavnoj formi
        //* uz KeyPreview = true pa onda da se proslijedi kontroli koja je trenutno aktivna
        //private void CtrlTimer_KeyUp(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Escape && timerKeeper.IsStarted)
        //    {
        //        StartStopTimer();
        //        e.Handled = true;
        //        e.SuppressKeyPress = true;
        //    }
        //}

        private void TimTimer_Tick(object sender, EventArgs e)
        {
            timerKeeper.Tick();
            lblTimerTime.Text = timerKeeper.PrintTime();
            if (!timerKeeper.IsStarted)
            {
                timTimer.Stop();
                Application.DoEvents();
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
    }
}
