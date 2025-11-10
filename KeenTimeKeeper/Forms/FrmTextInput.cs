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
            btnListRemove.Top = cmbList.Top;
            btnListRemove.Hide();
        }

        /// <summary>Is ComboBox visible</summary>
        private bool isListMode = false;

        public string InputText
        {
            get => isListMode ? cmbList.Text : txt.Text;
        }

        private List<TaskItem>? taskItems;

        public List<TaskItem>? TaskItems
        {
            get => taskItems;
            internal set
            {
                taskItems = value;
                cmbList.Items.Clear();
                if (taskItems != null)
                {
                    foreach (var item in taskItems)
                        cmbList.Items.Add(item);
                }
                cmbList.DisplayMember = "Name";
                cmbList.SelectedIndex = 0;
                cmbList.Show();
                btnListRemove.Show();
                txt.Hide();
                isListMode = true;
            }
        }

        public int? SelectedTaskTimeInSecs
            => cmbList.SelectedItem is TaskItem it ? it.TimeInSecs : null;

        private void CmbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbList.SelectedItem is TaskItem it)
                lblValue.Text = Utils.SecsToMS(it.TimeInSecs);
            else
                lblValue.Text = "";
        }

        private void BtnListRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbList.SelectedItem is TaskItem it &&
                    MessageBox.Show("Are you sure you want to remove the selected item?", "Confirm Removal"
                    , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    taskItems?.Remove(it);
                    cmbList.Items.Remove(it);
                    lblValue.Text = "";
                    cmbList.DroppedDown = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
