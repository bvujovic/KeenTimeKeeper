namespace KeenTimeKeeper.Controls
{
    partial class CtrlRibbon
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlRibbon));
            toolStrip = new ToolStrip();
            btnModes = new ToolStripDropDownButton();
            timerToolStripMenuItem = new ToolStripMenuItem();
            timeOnTaskToolStripMenuItem = new ToolStripMenuItem();
            currentTimeToolStripMenuItem = new ToolStripMenuItem();
            btnOptions = new ToolStripDropDownButton();
            tsmiAlwaysOnTop = new ToolStripMenuItem();
            tsmiBatteryInfo = new ToolStripLabel();
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.Items.AddRange(new ToolStripItem[] { btnModes, btnOptions, tsmiBatteryInfo });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(235, 25);
            toolStrip.TabIndex = 0;
            toolStrip.Text = "toolStrip1";
            // 
            // btnModes
            // 
            btnModes.AutoToolTip = false;
            btnModes.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnModes.DropDownItems.AddRange(new ToolStripItem[] { timerToolStripMenuItem, timeOnTaskToolStripMenuItem, currentTimeToolStripMenuItem });
            btnModes.ImageTransparentColor = Color.Magenta;
            btnModes.Name = "btnModes";
            btnModes.Size = new Size(56, 22);
            btnModes.Text = "Modes";
            btnModes.TextImageRelation = TextImageRelation.TextBeforeImage;
            // 
            // timerToolStripMenuItem
            // 
            timerToolStripMenuItem.Name = "timerToolStripMenuItem";
            timerToolStripMenuItem.Size = new Size(144, 22);
            timerToolStripMenuItem.Text = "Timer";
            // 
            // timeOnTaskToolStripMenuItem
            // 
            timeOnTaskToolStripMenuItem.Name = "timeOnTaskToolStripMenuItem";
            timeOnTaskToolStripMenuItem.Size = new Size(144, 22);
            timeOnTaskToolStripMenuItem.Text = "Time on Task";
            // 
            // currentTimeToolStripMenuItem
            // 
            currentTimeToolStripMenuItem.Name = "currentTimeToolStripMenuItem";
            currentTimeToolStripMenuItem.Size = new Size(144, 22);
            currentTimeToolStripMenuItem.Text = "Current Time";
            // 
            // btnOptions
            // 
            btnOptions.AutoToolTip = false;
            btnOptions.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnOptions.DropDownItems.AddRange(new ToolStripItem[] { tsmiAlwaysOnTop });
            btnOptions.Image = (Image)resources.GetObject("btnOptions.Image");
            btnOptions.ImageTransparentColor = Color.Magenta;
            btnOptions.Name = "btnOptions";
            btnOptions.Size = new Size(62, 22);
            btnOptions.Text = "Options";
            // 
            // tsmiAlwaysOnTop
            // 
            tsmiAlwaysOnTop.CheckOnClick = true;
            tsmiAlwaysOnTop.Name = "tsmiAlwaysOnTop";
            tsmiAlwaysOnTop.Size = new Size(151, 22);
            tsmiAlwaysOnTop.Text = "Always on Top";
            tsmiAlwaysOnTop.CheckedChanged += TsmiAlwaysOnTop_CheckedChanged;
            // 
            // tsmiBatteryInfo
            // 
            tsmiBatteryInfo.Alignment = ToolStripItemAlignment.Right;
            tsmiBatteryInfo.Name = "tsmiBatteryInfo";
            tsmiBatteryInfo.Size = new Size(53, 22);
            tsmiBatteryInfo.Text = "battery...";
            // 
            // CtrlRibbon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(toolStrip);
            Name = "CtrlRibbon";
            Size = new Size(235, 26);
            MouseLeave += CtrlRibbon_MouseLeave;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip;
        private ToolStripButton toolStripButton2;
        private ToolStripDropDownButton btnOptions;
        private ToolStripLabel tsmiBatteryInfo;
        private ToolStripDropDownButton btnModes;
        private ToolStripMenuItem timerToolStripMenuItem;
        private ToolStripMenuItem timeOnTaskToolStripMenuItem;
        private ToolStripMenuItem currentTimeToolStripMenuItem;
        private ToolStripMenuItem tsmiAlwaysOnTop;
    }
}
