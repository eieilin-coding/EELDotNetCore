namespace EELDotNetCore.WinFormsApp
{
    partial class FrmBlog
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
            btnCancel = new Button();
            btnSave = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTitle = new TextBox();
            txtAuthor = new TextBox();
            txtContent = new TextBox();
            btnUpdate = new Button();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(121, 85, 72);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.Location = new Point(66, 590);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(249, 85);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "&Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(104, 159, 56);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = SystemColors.ButtonHighlight;
            btnSave.Location = new Point(374, 590);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(244, 85);
            btnSave.TabIndex = 2;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
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
            txtTitle.Size = new Size(867, 47);
            txtTitle.TabIndex = 7;
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(66, 223);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(867, 47);
            txtAuthor.TabIndex = 8;
            // 
            // txtContent
            // 
            txtContent.Location = new Point(66, 389);
            txtContent.Multiline = true;
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(867, 154);
            txtContent.TabIndex = 9;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(128, 128, 255);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = SystemColors.ButtonHighlight;
            btnUpdate.Location = new Point(374, 590);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(244, 85);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "&Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // FrmBlog
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1707, 906);
            Controls.Add(btnUpdate);
            Controls.Add(txtContent);
            Controls.Add(txtAuthor);
            Controls.Add(txtTitle);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Name = "FrmBlog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmBlog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnSave;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTitle;
        private TextBox txtAuthor;
        private TextBox txtContent;
        private Button btnUpdate;
    }
}
