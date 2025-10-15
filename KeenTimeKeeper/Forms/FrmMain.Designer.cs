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
            ctrlTimer = new KeenTimeKeeper.Controls.CtrlTimer();
            ctxModes = new ContextMenuStrip(components);
            tsmiModesTimer = new ToolStripMenuItem();
            tsmiModesTimeOnTask = new ToolStripMenuItem();
            ctxModes.SuspendLayout();
            SuspendLayout();
            // 
            // ctrlTimer
            // 
            ctrlTimer.BorderStyle = BorderStyle.FixedSingle;
            ctrlTimer.Font = new Font("Segoe UI", 11.25F);
            ctrlTimer.Location = new Point(21, 13);
            ctrlTimer.Margin = new Padding(3, 4, 3, 4);
            ctrlTimer.Name = "ctrlTimer";
            ctrlTimer.Size = new Size(227, 154);
            ctrlTimer.TabIndex = 0;
            ctrlTimer.TimesList = new string[]
    {
    "00:05",
    "01:00",
    "01:30",
    "02:00",
    "04:00",
    "05:00",
    "10:00",
    "15:00"
    };
            // 
            // ctxModes
            // 
            ctxModes.Items.AddRange(new ToolStripItem[] { tsmiModesTimer, tsmiModesTimeOnTask });
            ctxModes.Name = "ctxModes";
            ctxModes.Size = new Size(143, 48);
            // 
            // tsmiModesTimer
            // 
            tsmiModesTimer.Checked = true;
            tsmiModesTimer.CheckState = CheckState.Checked;
            tsmiModesTimer.Name = "tsmiModesTimer";
            tsmiModesTimer.Size = new Size(142, 22);
            tsmiModesTimer.Text = "Timer";
            tsmiModesTimer.Click += TsmiModes_Click;
            // 
            // tsmiModesTimeOnTask
            // 
            tsmiModesTimeOnTask.Name = "tsmiModesTimeOnTask";
            tsmiModesTimeOnTask.Size = new Size(142, 22);
            tsmiModesTimeOnTask.Text = "Time on Task";
            tsmiModesTimeOnTask.Click += TsmiModes_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(269, 181);
            ContextMenuStrip = ctxModes;
            Controls.Add(ctrlTimer);
            Font = new Font("Segoe UI", 11.25F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimumSize = new Size(285, 210);
            Name = "FrmMain";
            Padding = new Padding(16);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Keen TimeKeeper";
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            ctxModes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Controls.CtrlTimer ctrlTimer;
        private ContextMenuStrip ctxModes;
        private ToolStripMenuItem tsmiModesTimer;
        private ToolStripMenuItem tsmiModesTimeOnTask;
    }
}
