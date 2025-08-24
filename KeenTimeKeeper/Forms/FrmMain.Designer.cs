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
            btnTimerStartCancel = new Button();
            grpTimer = new GroupBox();
            txtTimerNewTime = new TextBox();
            lblTimerTime = new Label();
            lstTimer = new ListBox();
            ctxTimerTimes = new ContextMenuStrip(components);
            tsmiTimerRemoveTime = new ToolStripMenuItem();
            timTimer = new System.Windows.Forms.Timer(components);
            grpTimer.SuspendLayout();
            ctxTimerTimes.SuspendLayout();
            SuspendLayout();
            // 
            // btnTimerStartCancel
            // 
            btnTimerStartCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimerStartCancel.Font = new Font("Segoe UI", 14.25F);
            btnTimerStartCancel.Location = new Point(122, 26);
            btnTimerStartCancel.Name = "btnTimerStartCancel";
            btnTimerStartCancel.Size = new Size(91, 45);
            btnTimerStartCancel.TabIndex = 0;
            btnTimerStartCancel.Text = "Start";
            btnTimerStartCancel.UseVisualStyleBackColor = true;
            btnTimerStartCancel.Click += BtnTimerStartCancel_Click;
            // 
            // grpTimer
            // 
            grpTimer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpTimer.Controls.Add(txtTimerNewTime);
            grpTimer.Controls.Add(lblTimerTime);
            grpTimer.Controls.Add(lstTimer);
            grpTimer.Controls.Add(btnTimerStartCancel);
            grpTimer.Location = new Point(327, 12);
            grpTimer.Name = "grpTimer";
            grpTimer.Size = new Size(219, 147);
            grpTimer.TabIndex = 1;
            grpTimer.TabStop = false;
            grpTimer.Text = "Timer";
            // 
            // txtTimerNewTime
            // 
            txtTimerNewTime.Location = new Point(6, 114);
            txtTimerNewTime.Name = "txtTimerNewTime";
            txtTimerNewTime.Size = new Size(95, 27);
            txtTimerNewTime.TabIndex = 23;
            txtTimerNewTime.KeyDown += TxtTimerNewTime_KeyDown;
            // 
            // lblTimerTime
            // 
            lblTimerTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTimerTime.BorderStyle = BorderStyle.FixedSingle;
            lblTimerTime.Font = new Font("Segoe UI", 14.25F);
            lblTimerTime.Location = new Point(122, 74);
            lblTimerTime.Name = "lblTimerTime";
            lblTimerTime.Size = new Size(91, 36);
            lblTimerTime.TabIndex = 22;
            lblTimerTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lstTimer
            // 
            lstTimer.ContextMenuStrip = ctxTimerTimes;
            lstTimer.FormattingEnabled = true;
            lstTimer.ItemHeight = 20;
            lstTimer.Items.AddRange(new object[] { "00:05", "01:00", "01:30", "02:00", "04:00", "05:00", "10:00", "15:00" });
            lstTimer.Location = new Point(6, 26);
            lstTimer.Name = "lstTimer";
            lstTimer.Size = new Size(95, 84);
            lstTimer.TabIndex = 21;
            lstTimer.SelectedIndexChanged += LstTimer_SelectedIndexChanged;
            lstTimer.KeyUp += LstTimer_KeyUp;
            // 
            // ctxTimerTimes
            // 
            ctxTimerTimes.Items.AddRange(new ToolStripItem[] { tsmiTimerRemoveTime });
            ctxTimerTimes.Name = "ctxTimerTimes";
            ctxTimerTimes.Size = new Size(118, 26);
            ctxTimerTimes.Opening += CtxTimerTimes_Opening;
            // 
            // tsmiTimerRemoveTime
            // 
            tsmiTimerRemoveTime.Name = "tsmiTimerRemoveTime";
            tsmiTimerRemoveTime.Size = new Size(117, 22);
            tsmiTimerRemoveTime.Text = "Remove";
            tsmiTimerRemoveTime.Click += TsmiTimerRemoveTime_Click;
            // 
            // timTimer
            // 
            timTimer.Interval = 1000;
            timTimer.Tick += TimTimer_Tick;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 416);
            Controls.Add(grpTimer);
            Font = new Font("Segoe UI", 11.25F);
            Margin = new Padding(4);
            Name = "FrmMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Keen TimeKeeper";
            Load += FrmMain_Load;
            grpTimer.ResumeLayout(false);
            grpTimer.PerformLayout();
            ctxTimerTimes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnTimerStartCancel;
        private GroupBox grpTimer;
        private Label lblTimerTime;
        private ListBox lstTimer;
        private ContextMenuStrip ctxTimerTimes;
        private ToolStripMenuItem tsmiTimerRemoveTime;
        private TextBox txtTimerNewTime;
        private System.Windows.Forms.Timer timTimer;
    }
}
