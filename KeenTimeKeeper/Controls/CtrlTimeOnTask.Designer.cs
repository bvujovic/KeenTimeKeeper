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
            ctxReset = new ContextMenuStrip(components);
            tsmiResetTime = new ToolStripMenuItem();
            lblCurrentChunkMinutes = new Label();
            label2 = new Label();
            label3 = new Label();
            numTimeChunk = new NumericUpDown();
            btnStart = new Button();
            lblChunkCount = new Label();
            lblTotalTime = new Label();
            tim = new System.Windows.Forms.Timer(components);
            timBtnStart = new System.Windows.Forms.Timer(components);
            timDelayDisplay = new System.Windows.Forms.Timer(components);
            ctxReset.SuspendLayout();
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
            // ctxReset
            // 
            ctxReset.Items.AddRange(new ToolStripItem[] { tsmiResetTime });
            ctxReset.Name = "ctxReset";
            ctxReset.Size = new Size(130, 26);
            // 
            // tsmiResetTime
            // 
            tsmiResetTime.Name = "tsmiResetTime";
            tsmiResetTime.Size = new Size(129, 22);
            tsmiResetTime.Text = "Reset time";
            tsmiResetTime.Click += TsmiResetTime_Click;
            // 
            // lblCurrentChunkMinutes
            // 
            lblCurrentChunkMinutes.Font = new Font("Segoe UI", 14.25F);
            lblCurrentChunkMinutes.Location = new Point(59, 79);
            lblCurrentChunkMinutes.Name = "lblCurrentChunkMinutes";
            lblCurrentChunkMinutes.Size = new Size(34, 23);
            lblCurrentChunkMinutes.TabIndex = 2;
            lblCurrentChunkMinutes.Text = "0";
            lblCurrentChunkMinutes.TextAlign = ContentAlignment.MiddleRight;
            lblCurrentChunkMinutes.MouseUp += LblCurrentChunkMinutes_MouseUp;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F);
            label2.Location = new Point(96, 79);
            label2.Name = "label2";
            label2.Size = new Size(19, 25);
            label2.TabIndex = 2;
            label2.Text = "/";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F);
            label3.Location = new Point(164, 79);
            label3.Name = "label3";
            label3.Size = new Size(44, 25);
            label3.TabIndex = 2;
            label3.Text = "min";
            // 
            // numTimeChunk
            // 
            numTimeChunk.Font = new Font("Segoe UI", 14.25F);
            numTimeChunk.Location = new Point(116, 77);
            numTimeChunk.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numTimeChunk.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTimeChunk.Name = "numTimeChunk";
            numTimeChunk.Size = new Size(46, 33);
            numTimeChunk.TabIndex = 2;
            numTimeChunk.Value = new decimal(new int[] { 10, 0, 0, 0 });
            numTimeChunk.ValueChanged += NumTimeChunk_ValueChanged;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Bottom;
            btnStart.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnStart.Location = new Point(73, 117);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(90, 38);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += BtnStart_Click;
            // 
            // lblChunkCount
            // 
            lblChunkCount.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblChunkCount.BorderStyle = BorderStyle.FixedSingle;
            lblChunkCount.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblChunkCount.Location = new Point(3, 73);
            lblChunkCount.Name = "lblChunkCount";
            lblChunkCount.Size = new Size(53, 37);
            lblChunkCount.TabIndex = 5;
            lblChunkCount.Text = "0";
            lblChunkCount.TextAlign = ContentAlignment.MiddleCenter;
            lblChunkCount.MouseUp += LblChunkCount_MouseUp;
            // 
            // lblTotalTime
            // 
            lblTotalTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTotalTime.BackColor = Color.LightGreen;
            lblTotalTime.BorderStyle = BorderStyle.FixedSingle;
            lblTotalTime.ContextMenuStrip = ctxReset;
            lblTotalTime.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalTime.Location = new Point(73, 33);
            lblTotalTime.Name = "lblTotalTime";
            lblTotalTime.Size = new Size(89, 37);
            lblTotalTime.TabIndex = 7;
            lblTotalTime.Text = "00:00";
            lblTotalTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tim
            // 
            tim.Interval = 1000;
            tim.Tick += Tim_Tick;
            // 
            // timBtnStart
            // 
            timBtnStart.Interval = 500;
            timBtnStart.Tick += TimBtnStart_Tick;
            // 
            // timDelayDisplay
            // 
            timDelayDisplay.Interval = 250;
            timDelayDisplay.Tick += TimDelayDisplay_Tick;
            // 
            // CtrlTimeOnTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ContextMenuStrip = ctxEmpty;
            Controls.Add(lblTotalTime);
            Controls.Add(lblChunkCount);
            Controls.Add(btnStart);
            Controls.Add(numTimeChunk);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblCurrentChunkMinutes);
            Controls.Add(lblTaskName);
            Margin = new Padding(5);
            Name = "CtrlTimeOnTask";
            Size = new Size(237, 154);
            Load += CtrlTimeOnTask_Load;
            ctxReset.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numTimeChunk).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTaskName;
        private ContextMenuStrip ctxEmpty;
        private Label lblCurrentChunkMinutes;
        private Label label2;
        private Label label3;
        private NumericUpDown numTimeChunk;
        private Button btnStart;
        private Label lblChunkCount;
        private Label lblTotalTime;
        private System.Windows.Forms.Timer tim;
        private ContextMenuStrip ctxReset;
        private ToolStripMenuItem tsmiResetTime;
        private System.Windows.Forms.Timer timBtnStart;
        private System.Windows.Forms.Timer timDelayDisplay;
    }
}
