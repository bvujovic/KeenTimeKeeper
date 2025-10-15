using KeenTimeKeeper.Classes;
using KeenTimeKeeper.Controls;
using System.Text.Json;

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
            try
            {
                ds.ReadXml(Utils.GetDataSetFileName());
                var times = ds.Settings.ReadString(nameof(ctrlTimer.TimesList), string.Empty)!;
                ctrlTimer.LoadTimesList(times);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private readonly Ds ds = new();

        private readonly CtrlTimeOnTask ctrlTimeOnTask = new() { Dock = DockStyle.Fill };

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ds.Settings.SaveSetting(nameof(ctrlTimer.TimesList), JsonSerializer.Serialize(ctrlTimer.TimesList));
                ds.WriteXml(Utils.GetDataSetFileName());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void TsmiModes_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem tsmi)
                foreach (ToolStripMenuItem item in ctxModes.Items)
                    item.Checked = item == tsmi;
            this.Controls.Clear();
            if (tsmiModesTimer.Checked)
                this.Controls.Add(ctrlTimer);
            if (tsmiModesTimeOnTask.Checked)
                this.Controls.Add(ctrlTimeOnTask);
        }
    }
}
