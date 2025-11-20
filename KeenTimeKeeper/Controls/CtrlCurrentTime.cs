namespace KeenTimeKeeper.Controls
{
    public partial class CtrlCurrentTime : CtrlMode
    {
        public CtrlCurrentTime()
        {
            InitializeComponent();
            lblTime.Text = string.Empty;
            tim.Start();
        }

        private int seconds = -1;

        private void Tim_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Second != seconds)
            {
                seconds = DateTime.Now.Second;
                lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            }
        }
    }
}
