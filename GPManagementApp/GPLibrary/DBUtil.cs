using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace GPLibrary
{
    public class DBUtil
    {
        public static string getConnectionString(string name)
        {
            string cs = null;
            try
            {
                cs = ConfigurationManager.ConnectionStrings[name].ConnectionString;
                return cs;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public static MySqlConnection getConnection(string cs)
        {
            MySqlConnection conn = null;
            
            try
            {
                conn = new MySqlConnection(cs);
                conn.Open();
                return conn;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public static void CloseConnection(MySqlConnection conn)
        {
            if(conn != null)
            {
                if(conn.State == ConnectionState.Open)
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
