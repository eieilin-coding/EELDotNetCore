
using EELDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;Console.WriteLine("Hello, World!");

//SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
//stringBuilder.DataSource = "Eieilin";
//stringBuilder.InitialCatalog = "DotNetTrainingBatch4";
//stringBuilder.UserID = "sa";
//stringBuilder.Password = "sasa@123";
//SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

//connection.Open();
//Console.WriteLine("Connection Open.");

//string query = "select * from Tbl_Blog";
//SqlCommand cmd = new SqlCommand(query, connection);
//SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
//DataTable dt = new DataTable();
//sqlDataAdapter.Fill(dt);


//connection.Close();
//Console.WriteLine("Connection Close.");

////Dataset ==> datatable
////Datatable ==> datarow
////Datarow ==> datacolumn

//foreach (DataRow dr in dt.Rows)
//{
// Console.WriteLine("Blog Id=>" + dr["BlogID"]);
// Console.WriteLine("Blog Title=>" + dr["BlogTitle"]);
// Console.WriteLine("Blog Author=>" + dr["BlogAuthor"]);
// Console.WriteLine("Blog Content=>" + dr["BlogContent"]);
// Console.WriteLine("------------------------------------");

//}
//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

//adoDotNetExample.Create("title", "author", "content");
//adoDotNetExample.Update(13, "TestTitle", "TestAuthor", "TestContent");
//adoDotNetExample.Read();
//adoDotNetExample.Update(13, "Test Title", "Test Author", "Test Content");
//adoDotNetExample.Delete(11);
//adoDotNetExample.Edit(11);
//adoDotNetExample.Edit(1);

//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Run();

Console.ReadLine();







