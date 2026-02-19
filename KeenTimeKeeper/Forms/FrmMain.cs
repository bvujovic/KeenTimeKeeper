global using OneDriveData = Bv.Shared.Core.OneDriveSharedAppData;
global using Setts = Bv.Shared.Core.DataSetSettings;
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
            OneDriveData.Init(Application.ProductName);
            ribbon = new CtrlRibbon { Width = ClientSize.Width };
        }

        private readonly CtrlRibbon ribbon;

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                MouseMove += ribbon.MouseMoveHandler;
                ribbon.TopMostChanged += (s, isTopMost) => { TopMost = isTopMost; };
                ribbon.ModeChanged += Ribbon_ModeChanged;
                Controls.Add(ribbon);
                ribbon.BringToFront();
                ds.ReadXml(OneDriveData.GetDataSetFilePath());
                Setts.Init(ds.Settings);
                ribbon.LoadSettings(ds);
                ribbon.BatteryLevelChanged += Ribbon_BatteryLevelChanged;
                foreach (var ctrl in ribbon.CtrlModes)
                {
                    ctrl.LoadSettings(ds);
                    ctrl.StartTimerClicked += CtrlMode_StartTimerClicked;
                    ctrl.TimerEnded += CtrlMode_TimerEnded;
                    //ctrl.MouseMove += ribbon.MouseMoveHandler;
                }
                // Set position of the form 
                var a = Screen.GetWorkingArea(this);
                var xaxis = Setts.ReadString("XAxis", nameof(Left));
                var left = Setts.ReadInt(nameof(Left), Left, it => it >= 0 && it < a.Width);
                Left = (xaxis == nameof(Left)) ? left : (a.Width - left - Width);
                var yaxis = Setts.ReadString("YAxis", nameof(Top));
                var top = Setts.ReadInt(nameof(Top), Top, it => it >= 0 && it <= a.Height);
                Top = (yaxis == nameof(Top)) ? top : (a.Height - top - Height);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            IsLoadFinished = true;
        }

        private void Ribbon_BatteryLevelChanged(object? sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            ribbon.ShowToUser();
            System.Media.SystemSounds.Exclamation.Play();
        }

        private void CtrlMode_StartTimerClicked(object? sender, EventArgs e)
        {
            var itv = ribbon.GetStartTimeInterval();
            if (itv > 0)
            {
                timMinOnStartTimer.Interval = itv;
                timMinOnStartTimer.Start();
            }
        }

        private void CtrlMode_TimerEnded(object? sender, EventArgs e)
        {
            if (ribbon.GetMinOnStartTime() != MinimizeOnStartTime.Never)
            {
                this.WindowState = FormWindowState.Minimized;
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
        }

        public bool IsLoadFinished { get; private set; } = false;

        private readonly Ds ds = new();
        public Ds DataSet => ds;

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsLoadFinished) // Loading not finished -> it's not safe to save settings
                return;
            try
            {
                var ctrl = GetCurrentCtrl();
                var strMode = ctrl != null ? ctrl.GetType().ToString() : string.Empty;
                Data.UpdateDataSetFromFile(ds);
                Setts.WriteValue(nameof(strMode), strMode);
                foreach (var c in ribbon.CtrlModes)
                    c.SaveSettings(ds);
                // Save position of the form - save distances from closer edges of the screen
                if (WindowState == FormWindowState.Normal)
                {
                    var a = Screen.GetWorkingArea(this);
                    var right = a.X + a.Width - Right;
                    Setts.WriteValue(nameof(Left), (Math.Min(Left, right)).ToString());
                    Setts.WriteValue("XAxis", (Left < right ? nameof(Left) : nameof(Right)));

                    var bottom = a.Y + a.Height - Bottom;
                    Setts.WriteValue(nameof(Top), (Math.Min(Top, bottom)).ToString());
                    Setts.WriteValue("YAxis", (Top < bottom ? nameof(Top) : nameof(Bottom)));
                }
                ds.WriteXml(OneDriveData.GetDataSetFilePath());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Ribbon_ModeChanged(object? sender, CtrlMode? ctrl)
        {
            pnlMain.Controls.Clear();
            if (ctrl != null)
            {
                Size = MinimumSize;
                var initCtrlSize = ctrl.Size;
                ctrl.Dock = DockStyle.Fill;
                pnlMain.Controls.Add(ctrl);
                var dw = initCtrlSize.Width - ctrl.Width;
                var dh = initCtrlSize.Height - ctrl.Height;
                Size = new Size(Width + dw, Height + dh);
            }
        }

        private void TimMinOnStartTimer_Tick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            timMinOnStartTimer.Stop();
        }

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
            => GetCurrentCtrl()?.CtrlKeyUp(e);

        private CtrlMode? GetCurrentCtrl()
            => this.pnlMain.Controls.Count > 0 ? this.pnlMain.Controls[0] as CtrlMode : null;
    }
}
