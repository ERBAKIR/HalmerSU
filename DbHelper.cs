
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HalmerSuTuketim
{
    public class DbHelper
    {
        private static string Cs =>
         ConfigurationManager.ConnectionStrings["HalmerConn"].ConnectionString;

        public static DataTable DataGetir(string sql, params MySqlParameter[] p)
        {
            using (var c = new MySqlConnection(Cs))
            using (var cmd = new MySqlCommand(sql, c))
            using (var da = new MySqlDataAdapter(cmd))
            {
                if (p?.Length > 0) cmd.Parameters.AddRange(p);
                var dt = new DataTable();
                try
                {
                    c.Open();
                    da.Fill(dt);
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine($" SQL Hatası: {ex.Message}");
                }
                return dt;
            }
        }

        public static int Execute(string sql, params MySqlParameter[] p)
        {
            using (var c = new MySqlConnection(Cs))
            using (var cmd = new MySqlCommand(sql, c))
            {
                if (p?.Length > 0) cmd.Parameters.AddRange(p);
                c.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object Scalar(string sql, params MySqlParameter[] p)
        {
            using (var c = new MySqlConnection(Cs))
            using (var cmd = new MySqlCommand(sql, c))
            {
                if (p?.Length > 0) cmd.Parameters.AddRange(p);
                c.Open();
                return cmd.ExecuteScalar();
            }
        }

    }
}
