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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlRibbon));
            toolStrip = new ToolStrip();
            tsmiModes = new ToolStripDropDownButton();
            tsmiModesTimer = new ToolStripMenuItem();
            tsmiModesTimeOnTask = new ToolStripMenuItem();
            tsmiCurrentTime = new ToolStripMenuItem();
            tsmiOptions = new ToolStripDropDownButton();
            tsmiAlwaysOnTop = new ToolStripMenuItem();
            tsmiMminimizeOnStartTimer = new ToolStripMenuItem();
            tsmiCopyLocationOfDataFile = new ToolStripMenuItem();
            tsmiUpdateDataFromFile = new ToolStripMenuItem();
            lblBatteryInfo = new ToolStripLabel();
            timBatteryInfoRegUpdate = new System.Windows.Forms.Timer(components);
            timBatteryInfoDisplay = new System.Windows.Forms.Timer(components);
            timHideIN = new System.Windows.Forms.Timer(components);
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.Items.AddRange(new ToolStripItem[] { tsmiModes, tsmiOptions, lblBatteryInfo });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Size = new Size(235, 25);
            toolStrip.TabIndex = 0;
            toolStrip.Text = "toolStrip1";
            // 
            // tsmiModes
            // 
            tsmiModes.AutoToolTip = false;
            tsmiModes.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsmiModes.DropDownItems.AddRange(new ToolStripItem[] { tsmiModesTimer, tsmiModesTimeOnTask, tsmiCurrentTime });
            tsmiModes.ImageTransparentColor = Color.Magenta;
            tsmiModes.Name = "tsmiModes";
            tsmiModes.Size = new Size(56, 22);
            tsmiModes.Text = "Modes";
            tsmiModes.TextImageRelation = TextImageRelation.TextBeforeImage;
            // 
            // tsmiModesTimer
            // 
            tsmiModesTimer.Name = "tsmiModesTimer";
            tsmiModesTimer.Size = new Size(144, 22);
            tsmiModesTimer.Text = "Timer";
            tsmiModesTimer.Click += TsmiModes_Click;
            // 
            // tsmiModesTimeOnTask
            // 
            tsmiModesTimeOnTask.Name = "tsmiModesTimeOnTask";
            tsmiModesTimeOnTask.Size = new Size(144, 22);
            tsmiModesTimeOnTask.Text = "Time on Task";
            tsmiModesTimeOnTask.Click += TsmiModes_Click;
            // 
            // tsmiCurrentTime
            // 
            tsmiCurrentTime.Name = "tsmiCurrentTime";
            tsmiCurrentTime.Size = new Size(144, 22);
            tsmiCurrentTime.Text = "Current Time";
            tsmiCurrentTime.Click += TsmiModes_Click;
            // 
            // tsmiOptions
            // 
            tsmiOptions.AutoToolTip = false;
            tsmiOptions.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsmiOptions.DropDownItems.AddRange(new ToolStripItem[] { tsmiAlwaysOnTop, tsmiMminimizeOnStartTimer, tsmiCopyLocationOfDataFile, tsmiUpdateDataFromFile });
            tsmiOptions.Image = (Image)resources.GetObject("tsmiOptions.Image");
            tsmiOptions.ImageTransparentColor = Color.Magenta;
            tsmiOptions.Name = "tsmiOptions";
            tsmiOptions.Size = new Size(62, 22);
            tsmiOptions.Text = "Options";
            // 
            // tsmiAlwaysOnTop
            // 
            tsmiAlwaysOnTop.CheckOnClick = true;
            tsmiAlwaysOnTop.Name = "tsmiAlwaysOnTop";
            tsmiAlwaysOnTop.Size = new Size(213, 22);
            tsmiAlwaysOnTop.Text = "Always on Top";
            tsmiAlwaysOnTop.CheckedChanged += TsmiAlwaysOnTop_CheckedChanged;
            // 
            // tsmiMminimizeOnStartTimer
            // 
            tsmiMminimizeOnStartTimer.Name = "tsmiMminimizeOnStartTimer";
            tsmiMminimizeOnStartTimer.Size = new Size(213, 22);
            tsmiMminimizeOnStartTimer.Text = "Minimize on Start Timer";
            // 
            // tsmiCopyLocationOfDataFile
            // 
            tsmiCopyLocationOfDataFile.Name = "tsmiCopyLocationOfDataFile";
            tsmiCopyLocationOfDataFile.Size = new Size(213, 22);
            tsmiCopyLocationOfDataFile.Text = "Copy Location of Data File";
            tsmiCopyLocationOfDataFile.Click += TsmiCopyLocationOfDataFile_Click;
            // 
            // tsmiUpdateDataFromFile
            // 
            tsmiUpdateDataFromFile.Name = "tsmiUpdateDataFromFile";
            tsmiUpdateDataFromFile.Size = new Size(213, 22);
            tsmiUpdateDataFromFile.Text = "Update Data from File";
            tsmiUpdateDataFromFile.Visible = false;
            tsmiUpdateDataFromFile.Click += TsmiUpdateDataFromFile_Click;
            // 
            // lblBatteryInfo
            // 
            lblBatteryInfo.Alignment = ToolStripItemAlignment.Right;
            lblBatteryInfo.Name = "lblBatteryInfo";
            lblBatteryInfo.Size = new Size(53, 22);
            lblBatteryInfo.Text = "battery...";
            lblBatteryInfo.Click += LblBatteryInfo_Click;
            // 
            // timBatteryInfoRegUpdate
            // 
            timBatteryInfoRegUpdate.Enabled = true;
            timBatteryInfoRegUpdate.Interval = 60000;
            timBatteryInfoRegUpdate.Tick += TimBatteryInfoRegUpdate_Tick;
            // 
            // timBatteryInfoDisplay
            // 
            timBatteryInfoDisplay.Interval = 500;
            timBatteryInfoDisplay.Tick += TimBatteryInfoDisplay_Tick;
            // 
            // timHideIN
            // 
            timHideIN.Interval = 500;
            timHideIN.Tick += TimHideIN_Tick;
            // 
            // CtrlRibbon
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(toolStrip);
            Name = "CtrlRibbon";
            Size = new Size(235, 26);
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip;
        private ToolStripButton toolStripButton2;
        private ToolStripDropDownButton tsmiOptions;
        private ToolStripLabel lblBatteryInfo;
        private ToolStripDropDownButton tsmiModes;
        private ToolStripMenuItem tsmiModesTimer;
        private ToolStripMenuItem tsmiModesTimeOnTask;
        private ToolStripMenuItem tsmiCurrentTime;
        private ToolStripMenuItem tsmiAlwaysOnTop;
        private System.Windows.Forms.Timer timBatteryInfoRegUpdate;
        private ToolStripMenuItem tsmiMminimizeOnStartTimer;
        private ToolStripMenuItem tsmiCopyLocationOfDataFile;
        private ToolStripMenuItem tsmiUpdateDataFromFile;
        private System.Windows.Forms.Timer timBatteryInfoDisplay;
        private System.Windows.Forms.Timer timHideIN;
    }
}
