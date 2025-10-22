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
            ctxModes = new ContextMenuStrip(components);
            tsmiModesTimer = new ToolStripMenuItem();
            tsmiModesTimeOnTask = new ToolStripMenuItem();
            ctxModes.SuspendLayout();
            SuspendLayout();
            // 
            // ctxModes
            // 
            ctxModes.Items.AddRange(new ToolStripItem[] { tsmiModesTimer, tsmiModesTimeOnTask });
            ctxModes.Name = "ctxModes";
            ctxModes.Size = new Size(143, 48);
            // 
            // tsmiModesTimer
            // 
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
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(269, 181);
            ContextMenuStrip = ctxModes;
            Font = new Font("Segoe UI", 11.25F);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimumSize = new Size(200, 100);
            Name = "FrmMain";
            Padding = new Padding(16);
            StartPosition = FormStartPosition.Manual;
            Text = "Keen TimeKeeper";
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            ctxModes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip ctxModes;
        private ToolStripMenuItem tsmiModesTimer;
        private ToolStripMenuItem tsmiModesTimeOnTask;
    }
}
