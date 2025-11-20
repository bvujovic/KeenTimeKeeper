namespace KeenTimeKeeper.Controls
{
    partial class CtrlCurrentTime
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
            lblTime = new Label();
            tim = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblTime
            // 
            lblTime.Dock = DockStyle.Fill;
            lblTime.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTime.Location = new Point(0, 0);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(271, 80);
            lblTime.TabIndex = 0;
            lblTime.Text = "19:02:54";
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tim
            // 
            tim.Tick += Tim_Tick;
            // 
            // CtrlCurrentTime
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblTime);
            Margin = new Padding(3, 5, 3, 5);
            Name = "CtrlCurrentTime";
            Size = new Size(271, 80);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTime;
        private System.Windows.Forms.Timer tim;
    }
}
