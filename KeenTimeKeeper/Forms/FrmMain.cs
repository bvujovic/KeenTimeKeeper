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
                var screen = Screen.PrimaryScreen!.WorkingArea;
                Left = ds.Settings.ReadInt(nameof(Left), Left, it => it >= 0 && it < screen.Width);
                Top = ds.Settings.ReadInt(nameof(Top), Top, it => it >= 0 && it <= screen.Height);
                tsmiModesTimer.Tag = ctrlTimer;
                tsmiModesTimeOnTask.Tag = ctrlTimeOnTask;
                var strMode = ds.Settings.ReadString("strMode", string.Empty);
                if (strMode != null)
                {
                    if (strMode.EndsWith(nameof(CtrlTimer)))
                        tsmiModesTimer.PerformClick();
                    else if (strMode.EndsWith(nameof(CtrlTimeOnTask)))
                        tsmiModesTimeOnTask.PerformClick();
                }
                ctrlTimer.LoadSettings(ds);
                ctrlTimeOnTask.LoadSettings(ds);
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
            if (!IsLoadFinished) // Loading not finished -> it's not safe to save settings
                return;
            try
            {
                var ctrl = GetCurrentCtrl();
                var strMode = ctrl != null ? ctrl.GetType().ToString() : string.Empty;
                ds.Settings.SaveSetting(nameof(strMode), strMode);
                ctrlTimer.SaveSettings(ds);
                ctrlTimeOnTask.SaveSettings(ds);
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
            // Save settings of the current control before switching to another one
            //var currentCtrl = this.Controls.Count > 0 ? this.Controls[0] as CtrlMode : null;
            //currentCtrl?.SaveSettings(ds);

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

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
            => GetCurrentCtrl()?.CtrlKeyUp(e);

        private CtrlMode? GetCurrentCtrl()
            => this.Controls.Count > 0 ? this.Controls[0] as CtrlMode : null;
    }
}
