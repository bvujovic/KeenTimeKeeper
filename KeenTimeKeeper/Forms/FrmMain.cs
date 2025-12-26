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
                ds.ReadXml(Data.GetDataSetFileName());
                tsmiModesTimer.Tag = ctrlTimer;
                tsmiModesTimeOnTask.Tag = ctrlTimeOnTask;
                tsmiCurrentTime.Tag = ctrlCurrentTime;
                tsmiMminimizeOnStartTimer.DropDownItems.Clear();
                var minOnStartTime = ds.Settings.ReadString(nameof(MinimizeOnStartTime)
                    , Enum.GetName(MinimizeOnStartTime.Never));
                foreach (MinimizeOnStartTime mode in Enum.GetValues(typeof(MinimizeOnStartTime)))
                {
                    var item = new ToolStripMenuItem(mode.ToDisplayString())
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
                // Set position of the form 
                var a = Screen.GetWorkingArea(this);
                var xaxis = ds.Settings.ReadString("XAxis", nameof(Left));
                var left = ds.Settings.ReadInt(nameof(Left), Left, it => it >= 0 && it < a.Width);
                Left = (xaxis == nameof(Left)) ? left : (a.Width - left - Width);
                var yaxis = ds.Settings.ReadString("YAxis", nameof(Top));
                var top = ds.Settings.ReadInt(nameof(Top), Top, it => it >= 0 && it <= a.Height);
                Top = (yaxis == nameof(Top)) ? top : (a.Height - top - Height);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            IsLoadFinished = true;
        }

        private void CtrlMode_StartTimerClicked(object? sender, EventArgs e)
        {
            if (GetMinOnStartTime() != MinimizeOnStartTime.Never)
            {
                const int itvLilWait = 250;
                var itv = GetMinOnStartTime() switch
                {
                    MinimizeOnStartTime.Immediately => 1,
                    MinimizeOnStartTime.After1Sec => 1000 + itvLilWait,
                    MinimizeOnStartTime.After2Secs => 2000 + itvLilWait,
                    MinimizeOnStartTime.After5Secs => 5000 + itvLilWait,
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
                if (item.Checked && item.Tag is MinimizeOnStartTime mode)
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
        public Ds DataSet => ds;

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
                Data.UpdateDataSetFromFile(ds);
                ds.Settings.SaveSetting(nameof(strMode), strMode);
                foreach (var c in ctrlModes)
                    c.SaveSettings(ds);
                // Save position of the form - save distances from closer edges of the screen
                if (WindowState == FormWindowState.Normal)
                {
                    var a = Screen.GetWorkingArea(this);
                    var right = a.X + a.Width - Right;
                    ds.Settings.SaveSetting(nameof(Left), (Math.Min(Left, right)).ToString());
                    ds.Settings.SaveSetting("XAxis", (Left < right ? nameof(Left) : nameof(Right)));

                    var bottom = a.Y + a.Height - Bottom;
                    ds.Settings.SaveSetting(nameof(Top), (Math.Min(Top, bottom)).ToString());
                    ds.Settings.SaveSetting("YAxis", (Top < bottom ? nameof(Top) : nameof(Bottom)));
                }
                ds.WriteXml(Data.GetDataSetFileName());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void TsmiModes_Click(object sender, EventArgs e)
        {
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
            if (ctrl is CtrlCurrentTime && !TopMost)
                SetTopMost(true, true);
            if (ctrl is not CtrlCurrentTime && TopMost && turnOffTopMost)
                SetTopMost(false, true);
        }

        /// <summary>...</summary>
        private bool turnOffTopMost = false;

        /// <summary>
        /// ...
        /// </summary>
        /// <param name="isTopMost"></param>
        /// <param name="isAuto"></param>
        private void SetTopMost(bool isTopMost, bool isAuto)
        {
            tsmiAlwaysOnTop.CheckedChanged -= TsmiAlwaysOnTop_CheckedChanged;
            turnOffTopMost = isTopMost && isAuto;
            TopMost = isTopMost;
            tsmiAlwaysOnTop.Checked = isTopMost;
            tsmiAlwaysOnTop.CheckedChanged += TsmiAlwaysOnTop_CheckedChanged;
        }

        private void TsmiAlwaysOnTop_CheckedChanged(object? sender, EventArgs e)
        {
            SetTopMost(tsmiAlwaysOnTop.Checked, false);
        }

        private void TimMinOnStartTimer_Tick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            timMinOnStartTimer.Stop();
        }

        private void TsmiCopyLocationOfDataFile_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Data.GetDataSetFileName() ?? "");
        }

        private void TsmiUpdateDataFromFile_Click(object sender, EventArgs e)
        {
            try
            {
                Data.UpdateDataSetFromFile(ds);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
            => GetCurrentCtrl()?.CtrlKeyUp(e);

        private CtrlMode? GetCurrentCtrl()
            => this.pnlMain.Controls.Count > 0 ? this.pnlMain.Controls[0] as CtrlMode : null;
    }
}
