using Library;
using MySql.Data.MySqlClient;
using System;

namespace GPManagement
{
    public class BaseDAO
    {
        private String config;
        public MySqlConnection conn = null;
        public MySqlConnection getConnection()
        {
            if(config != null)
            {
                String cs = DBUtil.getConnectionString(config);
                return DBUtil.getConnection(cs);
            }
            return null;
        }

        public void setConfig(String config)
        {
            this.config = config;
        }

    }
}
