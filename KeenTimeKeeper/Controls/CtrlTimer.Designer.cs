namespace KeenTimeKeeper.Controls
{
    partial class CtrlTimer
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
            grpTimer = new GroupBox();
            txtNewTime = new TextBox();
            lblCurrentTime = new Label();
            lstTimes = new ListBox();
            ctxTimerTimes = new ContextMenuStrip(components);
            tsmiTimerRemoveTime = new ToolStripMenuItem();
            btnStartCancel = new Button();
            timTimer = new System.Windows.Forms.Timer(components);
            ctxEmpty = new ContextMenuStrip(components);
            timDelayLoad = new System.Windows.Forms.Timer(components);
            grpTimer.SuspendLayout();
            ctxTimerTimes.SuspendLayout();
            SuspendLayout();
            // 
            // grpTimer
            // 
            grpTimer.Controls.Add(txtNewTime);
            grpTimer.Controls.Add(lblCurrentTime);
            grpTimer.Controls.Add(lstTimes);
            grpTimer.Controls.Add(btnStartCancel);
            grpTimer.Location = new Point(3, 3);
            grpTimer.Name = "grpTimer";
            grpTimer.Size = new Size(221, 147);
            grpTimer.TabIndex = 2;
            grpTimer.TabStop = false;
            grpTimer.Text = "Timer";
            // 
            // txtNewTime
            // 
            txtNewTime.Location = new Point(6, 114);
            txtNewTime.Name = "txtNewTime";
            txtNewTime.PlaceholderText = "New Timer";
            txtNewTime.Size = new Size(95, 27);
            txtNewTime.TabIndex = 23;
            txtNewTime.KeyDown += TxtNewTime_KeyDown;
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCurrentTime.BorderStyle = BorderStyle.FixedSingle;
            lblCurrentTime.Font = new Font("Segoe UI", 14.25F);
            lblCurrentTime.Location = new Point(124, 74);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(91, 36);
            lblCurrentTime.TabIndex = 22;
            lblCurrentTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lstTimes
            // 
            lstTimes.ContextMenuStrip = ctxTimerTimes;
            lstTimes.FormattingEnabled = true;
            lstTimes.ItemHeight = 20;
            lstTimes.Items.AddRange(new object[] { "00:05", "01:00", "01:30", "02:00", "04:00", "05:00", "10:00", "15:00" });
            lstTimes.Location = new Point(6, 26);
            lstTimes.Name = "lstTimes";
            lstTimes.Size = new Size(95, 84);
            lstTimes.TabIndex = 21;
            lstTimes.SelectedIndexChanged += LstTimes_SelectedIndexChanged;
            lstTimes.DoubleClick += LstTimes_DoubleClick;
            lstTimes.KeyUp += LstTimes_KeyUp;
            // 
            // ctxTimerTimes
            // 
            ctxTimerTimes.Items.AddRange(new ToolStripItem[] { tsmiTimerRemoveTime });
            ctxTimerTimes.Name = "ctxTimerTimes";
            ctxTimerTimes.Size = new Size(118, 26);
            ctxTimerTimes.Opening += CtxTimes_Opening;
            // 
            // tsmiTimerRemoveTime
            // 
            tsmiTimerRemoveTime.Name = "tsmiTimerRemoveTime";
            tsmiTimerRemoveTime.Size = new Size(117, 22);
            tsmiTimerRemoveTime.Text = "Remove";
            tsmiTimerRemoveTime.Click += TsmiRemoveTime_Click;
            // 
            // btnStartCancel
            // 
            btnStartCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStartCancel.Font = new Font("Segoe UI", 14.25F);
            btnStartCancel.Location = new Point(124, 26);
            btnStartCancel.Name = "btnStartCancel";
            btnStartCancel.Size = new Size(91, 45);
            btnStartCancel.TabIndex = 0;
            btnStartCancel.Text = "Start";
            btnStartCancel.UseVisualStyleBackColor = true;
            btnStartCancel.Click += BtnStartCancel_Click;
            // 
            // timTimer
            // 
            timTimer.Interval = 1000;
            timTimer.Tick += TimTimer_Tick;
            // 
            // ctxEmpty
            // 
            ctxEmpty.Name = "ctxTimerTimes";
            ctxEmpty.Size = new Size(61, 4);
            // 
            // timDelayLoad
            // 
            timDelayLoad.Interval = 250;
            timDelayLoad.Tick += TimDelayLoad_Tick;
            // 
            // CtrlTimer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ContextMenuStrip = ctxEmpty;
            Controls.Add(grpTimer);
            Name = "CtrlTimer";
            Size = new Size(237, 154);
            Load += CtrlTimer_Load;
            grpTimer.ResumeLayout(false);
            grpTimer.PerformLayout();
            ctxTimerTimes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpTimer;
        private TextBox txtNewTime;
        private Label lblCurrentTime;
        private ListBox lstTimes;
        private Button btnStartCancel;
        private System.Windows.Forms.Timer timTimer;
        private ContextMenuStrip ctxTimerTimes;
        private ToolStripMenuItem tsmiTimerRemoveTime;
        private ContextMenuStrip ctxEmpty;
        private System.Windows.Forms.Timer timDelayLoad;
    }
}
