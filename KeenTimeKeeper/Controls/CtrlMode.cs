using KeenTimeKeeper.Classes;

namespace KeenTimeKeeper.Controls
{
    public partial class CtrlMode : UserControl
    {
        public CtrlMode()
        {
            InitializeComponent();
        }

        public virtual void LoadSettings(Ds ds) { }

        public virtual void SaveSettings(Ds ds) { }

        public virtual void CtrlKeyUp(KeyEventArgs e) { }
    }
}
