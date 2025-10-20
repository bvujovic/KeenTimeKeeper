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
            txtTimerNewTime = new TextBox();
            lblTimerTime = new Label();
            lstTimerTimes = new ListBox();
            ctxTimerTimes = new ContextMenuStrip(components);
            tsmiTimerRemoveTime = new ToolStripMenuItem();
            btnTimerStartCancel = new Button();
            timTimer = new System.Windows.Forms.Timer(components);
            ctxEmpty = new ContextMenuStrip(components);
            grpTimer.SuspendLayout();
            ctxTimerTimes.SuspendLayout();
            SuspendLayout();
            // 
            // grpTimer
            // 
            grpTimer.Controls.Add(txtTimerNewTime);
            grpTimer.Controls.Add(lblTimerTime);
            grpTimer.Controls.Add(lstTimerTimes);
            grpTimer.Controls.Add(btnTimerStartCancel);
            grpTimer.Location = new Point(3, 3);
            grpTimer.Name = "grpTimer";
            grpTimer.Size = new Size(221, 147);
            grpTimer.TabIndex = 2;
            grpTimer.TabStop = false;
            grpTimer.Text = "Timer";
            // 
            // txtTimerNewTime
            // 
            txtTimerNewTime.Location = new Point(6, 114);
            txtTimerNewTime.Name = "txtTimerNewTime";
            txtTimerNewTime.PlaceholderText = "New Timer";
            txtTimerNewTime.Size = new Size(95, 27);
            txtTimerNewTime.TabIndex = 23;
            txtTimerNewTime.KeyDown += TxtTimerNewTime_KeyDown;
            // 
            // lblTimerTime
            // 
            lblTimerTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTimerTime.BorderStyle = BorderStyle.FixedSingle;
            lblTimerTime.Font = new Font("Segoe UI", 14.25F);
            lblTimerTime.Location = new Point(124, 74);
            lblTimerTime.Name = "lblTimerTime";
            lblTimerTime.Size = new Size(91, 36);
            lblTimerTime.TabIndex = 22;
            lblTimerTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lstTimerTimes
            // 
            lstTimerTimes.ContextMenuStrip = ctxTimerTimes;
            lstTimerTimes.FormattingEnabled = true;
            lstTimerTimes.ItemHeight = 20;
            lstTimerTimes.Items.AddRange(new object[] { "00:05", "01:00", "01:30", "02:00", "04:00", "05:00", "10:00", "15:00" });
            lstTimerTimes.Location = new Point(6, 26);
            lstTimerTimes.Name = "lstTimerTimes";
            lstTimerTimes.Size = new Size(95, 84);
            lstTimerTimes.TabIndex = 21;
            lstTimerTimes.SelectedIndexChanged += LstTimerTimes_SelectedIndexChanged;
            lstTimerTimes.DoubleClick += LstTimer_DoubleClick;
            lstTimerTimes.KeyUp += LstTimerTimes_KeyUp;
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
            // btnTimerStartCancel
            // 
            btnTimerStartCancel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimerStartCancel.Font = new Font("Segoe UI", 14.25F);
            btnTimerStartCancel.Location = new Point(124, 26);
            btnTimerStartCancel.Name = "btnTimerStartCancel";
            btnTimerStartCancel.Size = new Size(91, 45);
            btnTimerStartCancel.TabIndex = 0;
            btnTimerStartCancel.Text = "Start";
            btnTimerStartCancel.UseVisualStyleBackColor = true;
            btnTimerStartCancel.Click += BtnTimerStartCancel_Click;
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
            // CtrlTimer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ContextMenuStrip = ctxEmpty;
            Controls.Add(grpTimer);
            Name = "CtrlTimer";
            Size = new Size(237, 154);
            grpTimer.ResumeLayout(false);
            grpTimer.PerformLayout();
            ctxTimerTimes.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpTimer;
        private TextBox txtTimerNewTime;
        private Label lblTimerTime;
        private ListBox lstTimerTimes;
        private Button btnTimerStartCancel;
        private System.Windows.Forms.Timer timTimer;
        private ContextMenuStrip ctxTimerTimes;
        private ToolStripMenuItem tsmiTimerRemoveTime;
        private ContextMenuStrip ctxEmpty;
    }
}
