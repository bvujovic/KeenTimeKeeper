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
            if (e.KeyCode == Keys.Enter)
            {
                //lstTimer.Focus();
                //... add time from txt to lst if it's valid (00:00)
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void TimTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
