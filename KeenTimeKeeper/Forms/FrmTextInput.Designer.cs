namespace KeenTimeKeeper.Forms
{
    partial class FrmTextInput
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txt = new TextBox();
            btnOk = new Button();
            btnCancel = new Button();
            lblValue = new Label();
            cmbList = new ComboBox();
            SuspendLayout();
            // 
            // txt
            // 
            txt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txt.Location = new Point(12, 12);
            txt.Name = "txt";
            txt.Size = new Size(311, 25);
            txt.TabIndex = 0;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(167, 46);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 26);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(248, 46);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 26);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Location = new Point(12, 51);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(13, 17);
            lblValue.TabIndex = 3;
            lblValue.Text = "/";
            // 
            // cmbList
            // 
            cmbList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbList.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbList.FormattingEnabled = true;
            cmbList.Location = new Point(12, 18);
            cmbList.Name = "cmbList";
            cmbList.Size = new Size(311, 25);
            cmbList.TabIndex = 1;
            cmbList.SelectedIndexChanged += CmbList_SelectedIndexChanged;
            // 
            // FrmTextInput
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(335, 81);
            Controls.Add(cmbList);
            Controls.Add(lblValue);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(txt);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "FrmTextInput";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Text Input";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txt;
        private Button btnOk;
        private Button btnCancel;
        private Label lblValue;
        private ComboBox cmbList;
    }
}