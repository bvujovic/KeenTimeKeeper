namespace KeenTimeKeeper.Controls
{
    partial class CtrlTimeOnTask
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
            lblTaskName = new Label();
            ctxEmpty = new ContextMenuStrip(components);
            lblProgress = new Label();
            lblCurrentChunkMinutes = new Label();
            label2 = new Label();
            label3 = new Label();
            numTimeChunk = new NumericUpDown();
            btnStart = new Button();
            lblChunkCount = new Label();
            chkPause = new CheckBox();
            lblTimerStatus = new Label();
            tim = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)numTimeChunk).BeginInit();
            SuspendLayout();
            // 
            // lblTaskName
            // 
            lblTaskName.BorderStyle = BorderStyle.FixedSingle;
            lblTaskName.Dock = DockStyle.Top;
            lblTaskName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTaskName.Location = new Point(0, 0);
            lblTaskName.Name = "lblTaskName";
            lblTaskName.Size = new Size(225, 28);
            lblTaskName.TabIndex = 0;
            lblTaskName.Text = "Task";
            lblTaskName.TextAlign = ContentAlignment.MiddleCenter;
            lblTaskName.MouseUp += LblTaskName_MouseUp;
            // 
            // ctxEmpty
            // 
            ctxEmpty.Name = "ctxTimerTimes";
            ctxEmpty.Size = new Size(61, 4);
            // 
            // lblProgress
            // 
            lblProgress.Anchor = AnchorStyles.Top;
            lblProgress.AutoSize = true;
            lblProgress.Location = new Point(22, 36);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(181, 20);
            lblProgress.TabIndex = 1;
            lblProgress.Text = "Working: 10/10 min, 100%";
            // 
            // lblCurrentChunkMinutes
            // 
            lblCurrentChunkMinutes.Location = new Point(40, 67);
            lblCurrentChunkMinutes.Name = "lblCurrentChunkMinutes";
            lblCurrentChunkMinutes.Size = new Size(34, 20);
            lblCurrentChunkMinutes.TabIndex = 2;
            lblCurrentChunkMinutes.Text = "0";
            lblCurrentChunkMinutes.TextAlign = ContentAlignment.MiddleCenter;
            lblCurrentChunkMinutes.MouseUp += LblCurrentChunkMinutes_MouseUp;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(77, 67);
            label2.Name = "label2";
            label2.Size = new Size(15, 20);
            label2.TabIndex = 2;
            label2.Text = "/";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(150, 67);
            label3.Name = "label3";
            label3.Size = new Size(34, 20);
            label3.TabIndex = 2;
            label3.Text = "min";
            // 
            // numTimeChunk
            // 
            numTimeChunk.Location = new Point(98, 65);
            numTimeChunk.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numTimeChunk.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTimeChunk.Name = "numTimeChunk";
            numTimeChunk.Size = new Size(46, 27);
            numTimeChunk.TabIndex = 3;
            numTimeChunk.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnStart
            // 
            btnStart.Location = new Point(77, 98);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 28);
            btnStart.TabIndex = 4;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += BtnStart_Click;
            btnStart.MouseUp += BtnStart_MouseUp;
            // 
            // lblChunkCount
            // 
            lblChunkCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblChunkCount.BorderStyle = BorderStyle.FixedSingle;
            lblChunkCount.Location = new Point(3, 125);
            lblChunkCount.Name = "lblChunkCount";
            lblChunkCount.Size = new Size(34, 24);
            lblChunkCount.TabIndex = 5;
            lblChunkCount.Text = "0";
            lblChunkCount.TextAlign = ContentAlignment.MiddleCenter;
            lblChunkCount.MouseUp += LblChunkCount_MouseUp;
            // 
            // chkPause
            // 
            chkPause.AutoSize = true;
            chkPause.Location = new Point(79, 127);
            chkPause.Name = "chkPause";
            chkPause.Size = new Size(67, 24);
            chkPause.TabIndex = 6;
            chkPause.Text = "pause";
            chkPause.UseVisualStyleBackColor = true;
            chkPause.CheckedChanged += ChkPause_CheckedChanged;
            chkPause.MouseUp += ChkPause_MouseUp;
            // 
            // lblTimerStatus
            // 
            lblTimerStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTimerStatus.BackColor = Color.LightGreen;
            lblTimerStatus.Location = new Point(172, 124);
            lblTimerStatus.Name = "lblTimerStatus";
            lblTimerStatus.Size = new Size(50, 25);
            lblTimerStatus.TabIndex = 7;
            lblTimerStatus.Text = "ON";
            lblTimerStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tim
            // 
            tim.Interval = 1000;
            tim.Tick += Tim_Tick;
            // 
            // CtrlTimeOnTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            ContextMenuStrip = ctxEmpty;
            Controls.Add(lblTimerStatus);
            Controls.Add(chkPause);
            Controls.Add(lblChunkCount);
            Controls.Add(btnStart);
            Controls.Add(numTimeChunk);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblCurrentChunkMinutes);
            Controls.Add(lblProgress);
            Controls.Add(lblTaskName);
            Font = new Font("Segoe UI", 11.25F);
            Margin = new Padding(5);
            Name = "CtrlTimeOnTask";
            Size = new Size(225, 152);
            Load += CtrlTimeOnTask_Load;
            ((System.ComponentModel.ISupportInitialize)numTimeChunk).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTaskName;
        private ContextMenuStrip ctxEmpty;
        private Label lblProgress;
        private Label lblCurrentChunkMinutes;
        private Label label2;
        private Label label3;
        private NumericUpDown numTimeChunk;
        private Button btnStart;
        private Label lblChunkCount;
        private CheckBox chkPause;
        private Label lblTimerStatus;
        private System.Windows.Forms.Timer tim;
    }
}
