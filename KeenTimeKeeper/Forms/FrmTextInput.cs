using KeenTimeKeeper.Classes;
using System.Data;

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

        public void SetToListMode()
        {
            if (Tasks == null)
                return;
            foreach (var t in Tasks)
                t.NameTime = $"{t.Name} - ({Utils.SecsToMS(t.TimeInSecs)})";
            isListMode = true;
            var bs = new BindingSource
            {
                DataSource = Tasks,
                Sort = "LastUsed DESC"
            };
            cmbList.DisplayMember = "NameTime";
            cmbList.DataSource = bs;
            cmbList.SelectedIndex = 0;
            cmbList.Show();
            timDelayDisplay.Start();
            btnListRemove.Show();
            txt.Hide();
        }

        public string InputText
        {
            get
            {
                if (isListMode)
                {
                    var t = GetTasksRow();
                    return (t != null) ? t.Name : cmbList.Text;
                }
                else
                    return txt.Text;
            }
        }

        public Ds.TasksDataTable? Tasks { get; set; }

        private void CmbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var t = GetTasksRow();
            //lblValue.Text = (t != null) ? Utils.SecsToMS(t.TimeInSecs) : "";
        }

        // Clear label when text is updated manually (not selected from list)
        private void CmbList_TextUpdate(object sender, EventArgs e)
        {
            //lblValue.Text = "";
        }

        public Ds.TasksRow? GetTasksRow()
        {
            if ((cmbList.SelectedItem as DataRowView)?.Row is Ds.TasksRow t && t.NameTime == cmbList.Text)
                return t;
            else
                return null;
        }

        private void BtnListRemove_Click(object sender, EventArgs e)
        {
            try
            {
                var t = GetTasksRow();
                if (t != null && Tasks != null && MessageBox.Show("Are you sure you want to remove the selected item?"
                    , "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Tasks.Rows.Remove(t);
                    //lblValue.Text = "";
                    cmbList.DroppedDown = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing item: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimDelayDisplay_Tick(object sender, EventArgs e)
        {
            timDelayDisplay.Stop();
            cmbList.DroppedDown = true;
        }
    }
}
