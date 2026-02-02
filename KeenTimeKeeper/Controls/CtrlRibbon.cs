using Bv.Shared.Core;
using Bv.Shared.WinForms;
using KeenTimeKeeper.Classes;
using System.Diagnostics;

namespace KeenTimeKeeper.Controls
{
    public partial class CtrlRibbon : UserControl
    {
        public CtrlRibbon()
        {
            InitializeComponent();
            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            BorderStyle = BorderStyle.FixedSingle;
            Location = new Point(0, -Height); // hidden above form
            IsHidden = true;
            ctrlModes = [ctrlTimer, ctrlTimeOnTask, ctrlCurrentTime];
            // For testing
            //BatteryStatus.Init(
            //    [99, 98, 97, 96, 95, 94, 93, 92, 91, 90
            //    , 89, 88, 87, 86, 85, 84, 83, 82, 81
            //    , 80, 70, 60, 50, 40, 30, 20, 10, 5]);
            DisplayBatteryInfo();
        }

        private Ds ds;

        public void LoadSettings(Ds ds)
        {
            this.ds = ds;
            tsmiMminimizeOnStartTimer.DropDownItems.Clear();
            //var minOnStartTime = ds.Settings.ReadString(nameof(MinimizeOnStartTime)
            //    , Enum.GetName(MinimizeOnStartTime.Never));
            var minOnStartTime = Setts.ReadString(nameof(MinimizeOnStartTime)
                , Enum.GetName(MinimizeOnStartTime.Never));
            foreach (MinimizeOnStartTime mode in Enum.GetValues<MinimizeOnStartTime>())
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
            tsmiModesTimer.Tag = ctrlTimer;
            tsmiModesTimeOnTask.Tag = ctrlTimeOnTask;
            tsmiCurrentTime.Tag = ctrlCurrentTime;
            //var strMode = ds.Settings.ReadString("strMode", string.Empty);
            var strMode = Setts.ReadString("strMode", string.Empty);
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
        }

        private void TsmiMinimizeOnStartTimer_Click(object? sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in tsmiMminimizeOnStartTimer.DropDownItems)
            {
                item.Checked = item == sender;
                if (item == sender && item.Tag is MinimizeOnStartTime mode)
                    Setts.WriteValue(nameof(MinimizeOnStartTime), Enum.GetName(mode));
            }
        }

        public MinimizeOnStartTime GetMinOnStartTime()
        {
            foreach (ToolStripMenuItem item in tsmiMminimizeOnStartTimer.DropDownItems)
                if (item.Checked && item.Tag is MinimizeOnStartTime mode)
                    return mode;
            return MinimizeOnStartTime.Never;
        }

        public int GetStartTimeInterval()
        {
            const int itvLilWait = 250;
            return GetMinOnStartTime() switch
            {
                MinimizeOnStartTime.Immediately => 1,
                MinimizeOnStartTime.After1Sec => 1000 + itvLilWait,
                MinimizeOnStartTime.After2Secs => 2000 + itvLilWait,
                MinimizeOnStartTime.After5Secs => 5000 + itvLilWait,
                _ => 0
            };
        }

        public void ShowToUser()
        {
            if (Top < 0 && IsHidden)
            {
                Top = 0;
                IsHidden = false;
                timHideIN.Start();
            }
        }

        private DateTime? dontHideUntil = null;

        private void HideFromUserIN()
        {
            if (!IsHidden && !Bounds.Contains(PointToClient(Cursor.Position))
                && (!dontHideUntil.HasValue || DateTime.Now > dontHideUntil.Value)
                && (!tsmiModes.DropDown.Visible && !tsmiOptions.DropDown.Visible))
            {
                Top = -Height;
                IsHidden = true;
                dontHideUntil = null;
            }
        }

        public void HideFromUser()
        {
            Top = -Height;
            IsHidden = true;
        }

        public bool IsHidden { get; private set; }

        /// <summary>
        /// Height in pixels of the zone at the top of the window that
        /// reveals the ribbon when the mouse is over it.
        /// </summary>
        private const int revealZoneHeight = 20;

        public void MouseMoveHandler(object? sender, MouseEventArgs e)
        {
            if (e.Y <= revealZoneHeight)
                ShowToUser();
            //else
            //    HideFromUserIN();
        }

        private void TimHideIN_Tick(object sender, EventArgs e)
        {
            //Debug.WriteLine(!Bounds.Contains(PointToClient(Cursor.Position)));
            HideFromUserIN();
            if (IsHidden)
                timHideIN.Stop();
        }

        //private void CtrlRibbon_MouseLeave(object sender, EventArgs e)
        //{
        //    HideFromUser();
        //}

        private void TsmiAlwaysOnTop_CheckedChanged(object? sender, EventArgs e)
        {
            SetTopMost(tsmiAlwaysOnTop.Checked, false);
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
            TopMostChanged?.Invoke(this, isTopMost);
            tsmiAlwaysOnTop.Checked = isTopMost;
            tsmiAlwaysOnTop.CheckedChanged += TsmiAlwaysOnTop_CheckedChanged;
        }

        public EventHandler<bool> TopMostChanged;

        public EventHandler BatteryLevelChanged;

        private void TimBatteryInfoRegUpdate_Tick(object sender, EventArgs e)
        {
            //DisplayBatteryInfo();
            //if (BatteryStatus.BatteryLevelNotif())
            if (DisplayBatteryInfo())
            {
                BatteryLevelChanged?.Invoke(this, EventArgs.Empty);
                lblBatteryInfo.ForeColor = Color.Red;
                timBatteryInfoDisplay.Interval = 2000;
                timBatteryInfoDisplay.Start();
                dontHideUntil = DateTime.Now.AddSeconds(2);
            }
        }

        private void TimBatteryInfoDisplay_Tick(object sender, EventArgs e)
        {
            timBatteryInfoDisplay.Stop();
            lblBatteryInfo.ForeColor = SystemColors.ControlText;
        }

        private bool DisplayBatteryInfo()
        {
            lblBatteryInfo.Text = BatteryStatus.IsCharging ?
                $"{BatteryStatus.BatteryLevel}%, Charging..." : $"Remaining {BatteryStatus.BatteryLevel}%";
            return BatteryStatus.BatteryLevelNotif();
        }

        private void LblBatteryInfo_Click(object sender, EventArgs e)
        {
            DisplayBatteryInfo();
            //// This will prevent user from getting notif. for batt. level that he saw by refreshing lbl on click
            //BatteryStatus.BatteryLevelNotif();
            lblBatteryInfo.ForeColor = Color.Red;
            timBatteryInfoDisplay.Interval = 200;
            timBatteryInfoDisplay.Start();
        }

        private void TsmiCopyLocationOfDataFile_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(MyData.GetDataSetFilePath());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void TsmiUpdateDataFromFile_Click(object sender, EventArgs e)
        {
            try
            {
                Data.UpdateDataSetFromFile(ds);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private readonly CtrlTimer ctrlTimer = new();
        private readonly CtrlTimeOnTask ctrlTimeOnTask = new();
        private readonly CtrlCurrentTime ctrlCurrentTime = new();
        private readonly CtrlMode[] ctrlModes;
        public CtrlMode[] CtrlModes => ctrlModes;

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
            ModeChanged?.Invoke(this, ctrl);
        }

        public EventHandler<CtrlMode?> ModeChanged;
    }
}
