namespace KeenTimeKeeper
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            tsmiModesTimer = new ToolStripMenuItem();
            tsmiModesTimeOnTask = new ToolStripMenuItem();
            tsmiCurrentTime = new ToolStripMenuItem();
            pnlMain = new Panel();
            tsmiAlwaysOnTop = new ToolStripMenuItem();
            tsmiMminimizeOnStartTimer = new ToolStripMenuItem();
            ctxMain = new ContextMenuStrip(components);
            tsmiModes = new ToolStripMenuItem();
            tsmiOptions = new ToolStripMenuItem();
            tsmiCopyLocationOfDataFile = new ToolStripMenuItem();
            tsmiUpdateDataFromFile = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            timMinOnStartTimer = new System.Windows.Forms.Timer(components);
            ctxMain.SuspendLayout();
            SuspendLayout();
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
            // pnlMain
            // 
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(16, 8);
            pnlMain.Margin = new Padding(0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(237, 165);
            pnlMain.TabIndex = 2;
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
            // ctxMain
            // 
            ctxMain.Items.AddRange(new ToolStripItem[] { tsmiModes, tsmiOptions });
            ctxMain.Name = "ctxMain";
            ctxMain.Size = new Size(117, 48);
            // 
            // tsmiModes
            // 
            tsmiModes.DropDownItems.AddRange(new ToolStripItem[] { tsmiModesTimer, tsmiModesTimeOnTask, tsmiCurrentTime });
            tsmiModes.Name = "tsmiModes";
            tsmiModes.Size = new Size(116, 22);
            tsmiModes.Text = "Modes";
            // 
            // tsmiOptions
            // 
            tsmiOptions.DropDownItems.AddRange(new ToolStripItem[] { tsmiAlwaysOnTop, tsmiMminimizeOnStartTimer, tsmiCopyLocationOfDataFile, tsmiUpdateDataFromFile });
            tsmiOptions.Name = "tsmiOptions";
            tsmiOptions.Size = new Size(116, 22);
            tsmiOptions.Text = "Options";
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
            tsmiUpdateDataFromFile.Click += TsmiUpdateDataFromFile_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(180, 22);
            toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // timMinOnStartTimer
            // 
            timMinOnStartTimer.Tick += TimMinOnStartTimer_Tick;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(269, 181);
            ContextMenuStrip = ctxMain;
            Controls.Add(pnlMain);
            Font = new Font("Segoe UI", 11.25F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimumSize = new Size(200, 100);
            Name = "FrmMain";
            Padding = new Padding(16, 8, 16, 8);
            StartPosition = FormStartPosition.Manual;
            Text = "Keen TimeKeeper";
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            KeyUp += FrmMain_KeyUp;
            ctxMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ToolStripMenuItem tsmiModesTimer;
        private ToolStripMenuItem tsmiModesTimeOnTask;
        private Panel pnlMain;
        private ToolStripMenuItem tsmiCurrentTime;
        private ToolStripMenuItem tsmiAlwaysOnTop;
        private ToolStripMenuItem tsmiMminimizeOnStartTimer;
        private ContextMenuStrip ctxMain;
        private ToolStripMenuItem tsmiModes;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem tsmiOptions;
        private System.Windows.Forms.Timer timMinOnStartTimer;
        private ToolStripMenuItem tsmiCopyLocationOfDataFile;
        private ToolStripMenuItem tsmiUpdateDataFromFile;
    }
}
