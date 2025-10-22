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

                var screen = Screen.PrimaryScreen!.WorkingArea;
                Left = ds.Settings.ReadInt(nameof(Left), Left, it => it >= 0 && it < screen.Width);
                Top = ds.Settings.ReadInt(nameof(Top), Top, it => it >= 0 && it <= screen.Height);
                tsmiModesTimer.Tag = ctrlTimer;
                tsmiModesTimeOnTask.Tag = ctrlTimeOnTask;
                var strMode = ds.Settings.ReadString("strMode", string.Empty);
                if (strMode != null)
                {
                    if (strMode.EndsWith(nameof(CtrlTimer)))
                        //this.Controls.Add(ctrlTimer);
                        tsmiModesTimer.PerformClick();
                    else if (strMode.EndsWith(nameof(CtrlTimeOnTask)))
                        tsmiModesTimeOnTask.PerformClick();
                }
                ctrlTimer.LoadTimesList(times);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            IsLoadFinished = true;
        }

        public bool IsLoadFinished { get; private set; } = false;

        private readonly Ds ds = new();

        private readonly CtrlTimer ctrlTimer = new();
        private readonly CtrlTimeOnTask ctrlTimeOnTask = new();

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var mode = this.Controls.Count > 0 ? this.Controls[0] as CtrlMode : null;
                var strMode = mode != null ? mode.GetType().ToString() : string.Empty;
                ds.Settings.SaveSetting(nameof(strMode), strMode);

                ds.Settings.SaveSetting(nameof(ctrlTimer.TimesList), JsonSerializer.Serialize(ctrlTimer.TimesList));
                if (WindowState == FormWindowState.Normal)
                {
                    ds.Settings.SaveSetting(nameof(Left), Left.ToString());
                    ds.Settings.SaveSetting(nameof(Top), Top.ToString());
                }
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
