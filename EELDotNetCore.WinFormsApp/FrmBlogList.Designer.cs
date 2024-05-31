namespace EELDotNetCore.WinFormsApp
{
    partial class FrmBlogList
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
            dgvData = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colTitle = new DataGridViewTextBoxColumn();
            colAuthor = new DataGridViewTextBoxColumn();
            colContent = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
            SuspendLayout();
            // 
            // dgvData
            // 
            dgvData.AllowUserToAddRows = false;
            dgvData.AllowUserToDeleteRows = false;
            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvData.Columns.AddRange(new DataGridViewColumn[] { colId, colTitle, colAuthor, colContent });
            dgvData.Dock = DockStyle.Fill;
            dgvData.Location = new Point(0, 0);
            dgvData.Name = "dgvData";
            dgvData.ReadOnly = true;
            dgvData.RowHeadersWidth = 102;
            dgvData.RowTemplate.Height = 49;
            dgvData.Size = new Size(1448, 797);
            dgvData.TabIndex = 0;
            dgvData.CellContentClick += dataGridView1_CellContentClick;
            // 
            // colId
            // 
            colId.HeaderText = "ID";
            colId.MinimumWidth = 12;
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Visible = false;
            // 
            // colTitle
            // 
            colTitle.HeaderText = "Title";
            colTitle.MinimumWidth = 12;
            colTitle.Name = "colTitle";
            colTitle.ReadOnly = true;
            // 
            // colAuthor
            // 
            colAuthor.HeaderText = "Author";
            colAuthor.MinimumWidth = 12;
            colAuthor.Name = "colAuthor";
            colAuthor.ReadOnly = true;
            // 
            // colContent
            // 
            colContent.HeaderText = "Content";
            colContent.MinimumWidth = 12;
            colContent.Name = "colContent";
            colContent.ReadOnly = true;
            // 
            // FrmBlogList
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1448, 797);
            Controls.Add(dgvData);
            Name = "FrmBlogList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blogs";
            Load += FrmBlogList_Load;
            ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvData;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colAuthor;
        private DataGridViewTextBoxColumn colContent;
    }
}