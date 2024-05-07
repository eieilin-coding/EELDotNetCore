using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace EELDotNetCore.Shared
{
    public class DapperService
    {
        private readonly string _connectionString;
        public DapperService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<M> Query<M>(string qurey, object? param = null) 
        { 
            using IDbConnection db = new SqlConnection(_connectionString);
            //if (param != null)
            //{
            //    var lst = db.Query<M>(Query, param).ToList();
            //}
            //else
            //{
            //    var lst = db.Query<M>(Query).ToList();
            //}
            var lst = db.Query<M>(qurey, param).ToList();
            return lst;
        }
        public M QueryFirstOrDefault<M>(string qurey, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            //if (param != null)
            //{
            //    var lst = db.Query<M>(Query, param).ToList();
            //}
            //else
            //{
            //    var lst = db.Query<M>(Query).ToList();
            //}
            var item = db.Query<M>(qurey, param).FirstOrDefault();
            return item!;
        }
        public int Execute(string query, object? param = null)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            var result = db.Execute(query, param);
            return result;
        }
    }
}
