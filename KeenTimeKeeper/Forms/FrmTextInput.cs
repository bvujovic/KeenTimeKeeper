namespace KeenTimeKeeper.Forms
{
    public partial class FrmTextInput : Form
    {
        public FrmTextInput(string initialText)
        {
            InitializeComponent();
            txt.Text = initialText;
        }

        public string InputText
        {
            get => txt.Text;
        }
    }
}
