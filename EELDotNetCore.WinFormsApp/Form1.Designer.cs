namespace EELDotNetCore.WinFormsApp
{
    partial class Form1
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
            btnCancel_Click = new Button();
            btnSave_Click = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            SuspendLayout();
            // 
            // btnCancel_Click
            // 
            btnCancel_Click.BackColor = Color.FromArgb(121, 85, 72);
            btnCancel_Click.FlatAppearance.BorderSize = 0;
            btnCancel_Click.FlatStyle = FlatStyle.Flat;
            btnCancel_Click.ForeColor = SystemColors.ButtonHighlight;
            btnCancel_Click.Location = new Point(66, 590);
            btnCancel_Click.Name = "btnCancel_Click";
            btnCancel_Click.Size = new Size(268, 113);
            btnCancel_Click.TabIndex = 1;
            btnCancel_Click.Text = "Cancel";
            btnCancel_Click.UseVisualStyleBackColor = false;
            btnCancel_Click.Click += btnCancel_Click_Click;
            // 
            // btnSave_Click
            // 
            btnSave_Click.BackColor = Color.FromArgb(104, 159, 56);
            btnSave_Click.FlatAppearance.BorderSize = 0;
            btnSave_Click.FlatStyle = FlatStyle.Flat;
            btnSave_Click.ForeColor = SystemColors.ButtonHighlight;
            btnSave_Click.Location = new Point(472, 590);
            btnSave_Click.Name = "btnSave_Click";
            btnSave_Click.Size = new Size(259, 113);
            btnSave_Click.TabIndex = 2;
            btnSave_Click.Text = "Save";
            btnSave_Click.UseVisualStyleBackColor = false;
            btnSave_Click.Click += btnSave_Click_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 37);
            label1.Name = "label1";
            label1.Size = new Size(89, 41);
            label1.TabIndex = 4;
            label1.Text = "Title :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(66, 165);
            label2.Name = "label2";
            label2.Size = new Size(124, 41);
            label2.TabIndex = 5;
            label2.Text = "Author :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(66, 308);
            label3.Name = "label3";
            label3.Size = new Size(140, 41);
            label3.TabIndex = 6;
            label3.Text = "Content :";
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(66, 90);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(665, 47);
            txtTitle.TabIndex = 7;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(66, 223);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(665, 47);
            txtAuthor.TabIndex = 8;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(66, 389);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(665, 154);
            txtContent.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1707, 906);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSave_Click);
            Controls.Add(btnCancel_Click);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmBlog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel_Click;
        private Button btnSave_Click;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
    }
}
