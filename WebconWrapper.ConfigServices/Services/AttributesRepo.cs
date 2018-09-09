using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebconWrapper.ConfigServices.Model;

namespace WebconWrapper.ConfigServices.Services
{
    public class AttributesRepo
    {
        private readonly string _connectionString;

        public AttributesRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ICollection<WebconAttribute> GetAll()
        {
            var data = GetAttributesData();
            ICollection<WebconAttribute> attributesInfo = MapToAttributesInfo(data);
            return attributesInfo;
        }

        private static ICollection<WebconAttribute> MapToAttributesInfo(DataTable data)
        {
            return data.Rows.Cast<DataRow>().Select(row =>
            new WebconAttribute()
            {
                Id = row.Field<int>("A_Id"),
                WFName = row.Field<string>("WF_Name"),
                DEFID = row.Field<int>("DEFID"),
                Title = row.Field<string>("A_Title"),
                Type = row.Field<string>("A_Type"),
                TypeId = row.Field<int>("A_TypeId")
            }).ToList();
        }

        private DataTable GetAttributesData()
        {
            using (var conn = CreateConnection())
            using (var cmd = new SqlCommand(Configuration.Instance.AllAttributesQuery, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private SqlConnection CreateConnection()
        {
            var conn = new SqlConnection(_connectionString);
            conn.Open();
            return conn;
        }
    }
}
