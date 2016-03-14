using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Added using
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PPWorkArea.ClassObjects
{
    public class Class1
    {
        private string _connectionString = string.Empty;

        // constructor
        public Class1()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["SiteSqlServer"].ConnectionString;
        }

        public DataTable RetrieveData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM TestTable1", con))
                    {
                        con.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        dt.Load(sdr);
                    }
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            return dt;

        }
    }
}