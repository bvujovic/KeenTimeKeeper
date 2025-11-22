using KeenTimeKeeper.Classes;

namespace KeenTimeKeeper.Controls
{
    public partial class CtrlMode : UserControl
    {
        public CtrlMode()
        {
            InitializeComponent();
        }

        protected FrmMain? FrmMain => this.Parent?.Parent as FrmMain;

        public virtual void LoadSettings(Ds ds) { }

        public virtual void SaveSettings(Ds ds) { }

        public virtual void CtrlKeyUp(KeyEventArgs e) { }

        public event EventHandler? StartTimerClicked;
        protected void OnStartTimerClicked() => StartTimerClicked?.Invoke(this, EventArgs.Empty);

        public event EventHandler? TimerEnded;
        protected void OnTimerEnded() => TimerEnded?.Invoke(this, EventArgs.Empty);
    }
}
