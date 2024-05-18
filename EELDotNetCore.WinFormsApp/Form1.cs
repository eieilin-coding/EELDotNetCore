using EELDotNetCore.Shared;

namespace EELDotNetCore.WinFormsApp
{
    public partial class Form1 : Form
    {
       private readonly DapperService _dapperService; 
        public Form1()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
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
