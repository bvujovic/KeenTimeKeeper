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
            pnlMain = new Panel();
            toolStripMenuItem1 = new ToolStripMenuItem();
            timMinOnStartTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
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
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlMain;
        private ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Timer timMinOnStartTimer;
    }
}
