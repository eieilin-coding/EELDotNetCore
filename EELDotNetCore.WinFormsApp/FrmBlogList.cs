using EELDotNetCore.Shared;
using EELDotNetCore.WinFormsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EELDotNetCore.WinFormsApp
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperService _dapperService;
        //private const int _edit = 1;
        //private const int _delete = 2;
        public FrmBlogList()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>("select * from tbl_blog");
            dgvData.DataSource = lst;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int columnIndex = e.ColumnIndex;
            //int rowIndex = e.RowIndex;

            if(e.ColumnIndex == (int)EnumFormControlType.Edit)
            {

            }
            else if(e.ColumnIndex == (int)EnumFormControlType.Delete)
            {

            }
            EnumFormControlType enumFormControlType = EnumFormControlType.None;
            //switch (enumFormControlType)
            //{
            //    case EnumFormControlType.None:
            //        break;
            //    case EnumFormControlType.Delete:
            //        break;
            //    case EnumFormControlType.Edit:
            //        break;
            //    case enumFormControlType.abcde:
            //        break;
            //}
            //string formControlType = "None";
            //switch(formControlType)
            //{
            //    case "abcde":
            //        break;
            //    case "efgh":
            //        break;
            //}
        }
    }
}
