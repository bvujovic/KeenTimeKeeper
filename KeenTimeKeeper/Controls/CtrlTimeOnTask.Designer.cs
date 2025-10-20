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
            lblTaskName.Size = new Size(237, 28);
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
            lblProgress.Font = new Font("Segoe UI", 12F);
            lblProgress.Location = new Point(17, 38);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(203, 21);
            lblProgress.TabIndex = 1;
            lblProgress.Text = "Chunk: 0/0 min, Total: 0 min";
            // 
            // lblCurrentChunkMinutes
            // 
            lblCurrentChunkMinutes.Font = new Font("Segoe UI", 12F);
            lblCurrentChunkMinutes.Location = new Point(44, 73);
            lblCurrentChunkMinutes.Name = "lblCurrentChunkMinutes";
            lblCurrentChunkMinutes.Size = new Size(34, 20);
            lblCurrentChunkMinutes.TabIndex = 2;
            lblCurrentChunkMinutes.Text = "0";
            lblCurrentChunkMinutes.TextAlign = ContentAlignment.MiddleRight;
            lblCurrentChunkMinutes.MouseUp += LblCurrentChunkMinutes_MouseUp;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(81, 73);
            label2.Name = "label2";
            label2.Size = new Size(16, 21);
            label2.TabIndex = 2;
            label2.Text = "/";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(150, 73);
            label3.Name = "label3";
            label3.Size = new Size(37, 21);
            label3.TabIndex = 2;
            label3.Text = "min";
            // 
            // numTimeChunk
            // 
            numTimeChunk.Font = new Font("Segoe UI", 12F);
            numTimeChunk.Location = new Point(98, 71);
            numTimeChunk.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numTimeChunk.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTimeChunk.Name = "numTimeChunk";
            numTimeChunk.Size = new Size(46, 29);
            numTimeChunk.TabIndex = 3;
            numTimeChunk.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom;
            btnStart.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStart.Location = new Point(81, 113);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 38);
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
            lblChunkCount.Font = new Font("Segoe UI", 12F);
            lblChunkCount.Location = new Point(3, 127);
            lblChunkCount.Name = "lblChunkCount";
            lblChunkCount.Size = new Size(50, 25);
            lblChunkCount.TabIndex = 5;
            lblChunkCount.Text = "0";
            lblChunkCount.TextAlign = ContentAlignment.MiddleCenter;
            lblChunkCount.MouseUp += LblChunkCount_MouseUp;
            // 
            // lblTimerStatus
            // 
            lblTimerStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTimerStatus.BackColor = Color.LightGreen;
            lblTimerStatus.BorderStyle = BorderStyle.FixedSingle;
            lblTimerStatus.Font = new Font("Segoe UI", 12F);
            lblTimerStatus.Location = new Point(184, 126);
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
            ContextMenuStrip = ctxEmpty;
            Controls.Add(lblTimerStatus);
            Controls.Add(lblChunkCount);
            Controls.Add(btnStart);
            Controls.Add(numTimeChunk);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblCurrentChunkMinutes);
            Controls.Add(lblProgress);
            Controls.Add(lblTaskName);
            Margin = new Padding(5);
            Name = "CtrlTimeOnTask";
            Size = new Size(237, 154);
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
        private Label lblTimerStatus;
        private System.Windows.Forms.Timer tim;
    }
}
