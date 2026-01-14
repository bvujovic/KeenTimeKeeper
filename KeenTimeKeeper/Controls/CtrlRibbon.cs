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
        }

        public void ShowToUser()
        {
            if (Top < 0 && IsHidden)
            {
                Top = 0;
                IsHidden = false;
            }
        }

        private void HideFromUserIN()
        {
            if (!IsHidden && !Bounds.Contains(PointToClient(Cursor.Position)))
            {
                Top = -Height;
                IsHidden = true;
            }
        }

        public void HideFromUser()
        {
            Top = -Height;
            IsHidden = true;
            //System.Diagnostics.Debug.WriteLine("hide");
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
            else
                HideFromUserIN();
        }

        private void CtrlRibbon_MouseLeave(object sender, EventArgs e)
        {
            HideFromUser();
        }

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
            // TopMost = isTopMost;
            TopMostChanged?.Invoke(this, isTopMost);
            tsmiAlwaysOnTop.Checked = isTopMost;
            tsmiAlwaysOnTop.CheckedChanged += TsmiAlwaysOnTop_CheckedChanged;
        }

        public EventHandler<bool> TopMostChanged;
    }
}
