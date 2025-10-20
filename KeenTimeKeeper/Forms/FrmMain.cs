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
                tsmiModesTimer.Tag = ctrlTimer;
                tsmiModesTimeOnTask.Tag = ctrlTimeOnTask;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private readonly Ds ds = new();

        private readonly CtrlTimer ctrlTimer = new();
        private readonly CtrlTimeOnTask ctrlTimeOnTask = new();

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
            CtrlMode? ctrl = null;
            if (sender is ToolStripMenuItem tsmi)
                foreach (ToolStripMenuItem item in ctxModes.Items)
                {
                    item.Checked = item == tsmi;
                    if (item == tsmi)
                        ctrl = item.Tag as CtrlMode;
                }
            this.Controls.Clear();
            if (ctrl != null)
            {
                this.Size = this.MinimumSize;
                var initCtrlSize = ctrl.Size;
                ctrl.Dock = DockStyle.Fill;
                this.Controls.Add(ctrl);
                var dw = initCtrlSize.Width - ctrl.Width;
                var dh = initCtrlSize.Height - ctrl.Height;
                this.Size = new Size(this.Width + dw, this.Height + dh);
            }
        }
    }
}
