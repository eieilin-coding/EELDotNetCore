
using System.Data;
using System.Data.SqlClient;
Console.WriteLine("Hello, World!");
SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "EIEILIN";
stringBuilder.InitialCatalog = "DotNetTrainingBath4";
stringBuilder.UserID = "sa";
stringBuilder.Password = "sa@123";
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

Console.WriteLine("Connection Open.");

string query = "select * from Tbl_Blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
sqlDataAdapter.Fill(dt);


connection.Close();
Console.WriteLine("Connection Close.");

//Dataset ==> datatable
//Datatable ==> datarow
//Datarow ==> datacolumn

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("Blog Id=>" + dr["BlogID"]);
    Console.WriteLine("Blog Title=>" + dr["BlogTitle"]);
    Console.WriteLine("Blog Author=>" + dr["BlogAuthor"]);
    Console.WriteLine("Blog Content=>" + dr["BlogContent"]);

}

Console.ReadKey();





