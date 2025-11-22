using KeenTimeKeeper.Classes;
using KeenTimeKeeper.Controls;
using System.Diagnostics;

namespace KeenTimeKeeper
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            ctrlModes = [ctrlTimer, ctrlTimeOnTask, ctrlCurrentTime];
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
                tsmiCurrentTime.Tag = ctrlCurrentTime;
                tsmiMminimizeOnStartTimer.DropDownItems.Clear();
                var minOnStartTime = ds.Settings.ReadString(nameof(MinimizeOnStartTime)
                    , Enum.GetName(MinimizeOnStartTime.Never));
                foreach (MinimizeOnStartTime mode in Enum.GetValues(typeof(MinimizeOnStartTime)))
                {
                    var item = new ToolStripMenuItem(mode.ToString())
                    {
                        Checked = Enum.GetName(mode) == minOnStartTime,
                        CheckOnClick = true,
                        Tag = mode
                    };
                    item.Click += TsmiMinimizeOnStartTimer_Click;
                    tsmiMminimizeOnStartTimer.DropDownItems.Add(item);
                }
                var strMode = ds.Settings.ReadString("strMode", string.Empty);
                if (strMode != null)
                {
                    // maybe some list/dict that would connect ctrlModes with ToolStripMenuItems would be better
                    if (strMode.EndsWith(nameof(CtrlTimer)))
                        tsmiModesTimer.PerformClick();
                    else if (strMode.EndsWith(nameof(CtrlTimeOnTask)))
                        tsmiModesTimeOnTask.PerformClick();
                    else if (strMode.EndsWith(nameof(CtrlCurrentTime)))
                        tsmiCurrentTime.PerformClick();
                }
                foreach (var ctrl in ctrlModes)
                {
                    ctrl.LoadSettings(ds);
                    ctrl.StartTimerClicked += CtrlMode_StartTimerClicked;
                    ctrl.TimerEnded += CtrlMode_TimerEnded;
                }
                //ctrlTimer.LoadSettings(ds);
                //ctrlTimeOnTask.LoadSettings(ds);
                //ctrlTimeOnTask.StartTimerClicked += CtrlMode_StartTimerClicked;
                //ctrlTimeOnTask.TimerEnded += CtrlMode_TimerEnded;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            IsLoadFinished = true;
        }

        private void CtrlMode_StartTimerClicked(object? sender, EventArgs e)
        {
            if (GetMinOnStartTime() != MinimizeOnStartTime.Never)
            {
                var itv = GetMinOnStartTime() switch
                {
                    MinimizeOnStartTime.Immediately => 1,
                    MinimizeOnStartTime.After1Sec => 1000,
                    MinimizeOnStartTime.After2Secs => 2000,
                    MinimizeOnStartTime.After5Secs => 5000,
                    _ => 0
                };
                if (itv > 0)
                {
                    timMinOnStartTimer.Interval = itv;
                    timMinOnStartTimer.Start();
                }
            }
        }

        private void CtrlMode_TimerEnded(object? sender, EventArgs e)
        {
            if (GetMinOnStartTime() != MinimizeOnStartTime.Never)
            {
                this.WindowState = FormWindowState.Minimized;
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        private MinimizeOnStartTime GetMinOnStartTime()
        {
            foreach (ToolStripMenuItem item in tsmiMminimizeOnStartTimer.DropDownItems)
                if (item.Checked && Enum.TryParse<MinimizeOnStartTime>(item.Text, out var mode))
                    return mode;
            return MinimizeOnStartTime.Never;
        }

        private void TsmiMinimizeOnStartTimer_Click(object? sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in tsmiMminimizeOnStartTimer.DropDownItems)
            {
                item.Checked = item == sender;
                if (item == sender && item.Tag is MinimizeOnStartTime mode)
                    ds.Settings.SaveSetting(nameof(MinimizeOnStartTime), Enum.GetName(mode));
            }
        }

        public bool IsLoadFinished { get; private set; } = false;

        private readonly Ds ds = new();

        private readonly CtrlTimer ctrlTimer = new();
        private readonly CtrlTimeOnTask ctrlTimeOnTask = new();
        private readonly CtrlCurrentTime ctrlCurrentTime = new();
        private readonly CtrlMode[] ctrlModes;

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsLoadFinished) // Loading not finished -> it's not safe to save settings
                return;
            try
            {
                var ctrl = GetCurrentCtrl();
                var strMode = ctrl != null ? ctrl.GetType().ToString() : string.Empty;
                ds.Settings.SaveSetting(nameof(strMode), strMode);
                //ctrlTimer.SaveSettings(ds);
                //ctrlTimeOnTask.SaveSettings(ds);
                foreach (var c in ctrlModes)
                    c.SaveSettings(ds);

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
                foreach (ToolStripMenuItem item in tsmiModes.DropDownItems)
                {
                    item.Checked = item == tsmi;
                    if (item == tsmi)
                        ctrl = item.Tag as CtrlMode;
                }
            this.pnlMain.Controls.Clear();
            if (ctrl != null)
            {
                this.Size = this.MinimumSize;
                var initCtrlSize = ctrl.Size;
                ctrl.Dock = DockStyle.Fill;
                this.pnlMain.Controls.Add(ctrl);
                var dw = initCtrlSize.Width - ctrl.Width;
                var dh = initCtrlSize.Height - ctrl.Height;
                this.Size = new Size(this.Width + dw, this.Height + dh);
            }
        }

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
            => GetCurrentCtrl()?.CtrlKeyUp(e);

        private CtrlMode? GetCurrentCtrl()
            => this.pnlMain.Controls.Count > 0 ? this.pnlMain.Controls[0] as CtrlMode : null;

        private void TsmiAlwaysOnTop_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = tsmiAlwaysOnTop.Checked;
        }

        private void TimMinOnStartTimer_Tick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            timMinOnStartTimer.Stop();
        }
    }
}
