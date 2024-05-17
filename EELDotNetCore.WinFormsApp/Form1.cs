namespace EELDotNetCore.WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCancel_Click_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtAuthor.Clear();
            txtContent.Clear(); 

            txtTitle.Focus();
        }

        private void btnSave_Click_Click(object sender, EventArgs e)
        {

        }
    }
}
