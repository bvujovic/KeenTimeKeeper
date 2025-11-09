using KeenTimeKeeper.Classes;

namespace KeenTimeKeeper.Forms
{
    public partial class FrmTextInput : Form
    {

        public FrmTextInput(string initialText, string? caption = null)
        {
            InitializeComponent();
            txt.Text = initialText;
            Text = caption ?? "Text Input";
            lblValue.Text = "";
            cmbList.Location = txt.Location;
            cmbList.Hide();
        }

        public string InputText
        {
            get => txt.Visible ? txt.Text : cmbList.Text;
        }

        private List<TaskItem> taskItems;

        public int? SelectedTaskTimeInSecs 
            => cmbList.SelectedItem is TaskItem it ? it.TimeInSecs : null;

        private void CmbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbList.SelectedItem is TaskItem it)
                lblValue.Text = Utils.SecsToMS(it.TimeInSecs);
        }

        public List<TaskItem> TaskItems
        {
            get => taskItems;
            internal set
            {
                taskItems = value;
                cmbList.Items.Clear();
                foreach (var item in taskItems)
                    cmbList.Items.Add(item);
                cmbList.DisplayMember = "Name";
                cmbList.SelectedIndex = 0;
                cmbList.Show();
                txt.Hide();
            }
        }
    }
}
