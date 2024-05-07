using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EELDotNetCore.Shared
{
    public class AdoDotNetService
    {
        private readonly string _connectionstring;
        public AdoDotNetService(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public List<T> Query<T>(string query) 
        {
            SqlConnection connection = new SqlConnection(_connectionstring);
            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);

            string json = JsonConvert.SerializeObject(dt);//C# to Json
            List<T> lst = JsonConvert.DeserializeObject<List<T>>(json)!;

            connection.Close();
            return lst;
        }
    }
}
