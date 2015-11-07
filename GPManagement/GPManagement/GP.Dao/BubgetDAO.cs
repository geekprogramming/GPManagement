using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Library;
using GPManagement.GP.Entity;

namespace GPManagement.GP.Dao
{
    class BubgetDAO : BaseDAO, IDAO
    {
        public BubgetDAO()
        {
            setConfig("url_mysql");
        }

        public List<object> getAllData(object obj, string sortColumn, bool asc, bool exactFilter)
        {
            List<object> result = new List<object>();
            MySqlTransaction tr = null;
            MySqlDataReader rdr = null;
            String sql = "SELECT * FROM GP_BUDGET WHERE 1=1 ";
            Dictionary<String, String> paramDic = new Dictionary<String, String>();
            Budget bud = (Budget)obj;
            if (bud != null)
            {
                String strFilter = bud.getStrFilter();
                if (!String.IsNullOrWhiteSpace(strFilter))
                {
                    if (exactFilter)
                    {
                        sql += " AND (B_COMMENT = @COMMENT) ";
                        paramDic.Add("@COMMENT", strFilter);
                    }
                    else
                    {
                        sql += " AND B_COMMENT LIKE @COMMENT ";
                        paramDic.Add("@COMMENT", "%" + strFilter + "%");
                    }

                }
            }
            if (sortColumn != null)
            {
                String sort = (asc == true ? "ASC" : "DSC");

                sql += " ORDER BY @COLUMN @SORT ";
                paramDic.Add("@COLUMN", sortColumn);
                paramDic.Add("@SORT", sort);
            }
            try
            {
                conn = getConnection();
                tr = conn.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = tr;
                cmd.CommandText = sql;
                foreach (KeyValuePair<String, String> pair in paramDic)
                {
                    cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                }

                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Budget temp = new Budget();
                    temp.setId(rdr.GetInt32("B_ID"));
                    temp.setDate(rdr.GetDateTime("B_TIME"));
                    temp.setQuantity(rdr.GetDouble("B_QUANTITY"));
                    temp.setTotal(rdr.GetDouble("B_TOTAL"));
                    temp.setComment(rdr.GetString("B_COMMENT"));
                    temp.setType(rdr.GetString("B_TYPE"));
                    result.Add(temp);
                }
                tr.Commit();
            }
            catch (Exception ex)
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                tr.Rollback();
            }
            finally
            {

                DBUtil.CloseConnection(conn);
            }
            return result;
        }

        public bool insertNewData(object obj)
        {
            Budget bud = (Budget)obj;
            bool FLAG = false;
            MySqlTransaction tr = null;
            try
            {
                conn = getConnection();
                tr = conn.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = tr;
                cmd.CommandText = "INSERT INTO GP_BUDGET (B_TIME,B_TYPE,B_QUANTITY,B_TOTAL,B_COMMENT) VALUES(@TIME,@TYPE,@QUANTITY,@TOTAL,@COMMENT)";
                cmd.Parameters.AddWithValue("@TIME", bud.getDateTime());
                cmd.Parameters.AddWithValue("@TYPE", bud.getType());
                cmd.Parameters.AddWithValue("@QUANTITY", bud.getQuantity());
                cmd.Parameters.AddWithValue("@TOTAL", bud.getTotal());
                cmd.Parameters.AddWithValue("@COMMENT", bud.getComment());
                cmd.ExecuteNonQuery();
                tr.Commit();
                FLAG = true;
            }
            catch (Exception ex)
            {
                FLAG = false;
                tr.Rollback();
            }
            finally
            {
                DBUtil.CloseConnection(conn);
            }
            return FLAG;
        }

        public bool updateData(object obj)
        {
            Budget bud = (Budget)obj;
            Boolean FLAG = false;
            MySqlTransaction tr = null;
            try
            {
                conn = getConnection();
                tr = conn.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = tr;
                cmd.CommandText = "UPDATE GP_BUDGET SET B_TIME=@TIME, B_TYPE=@TYPE ,B_QUANTITY = @QUANTITY ,B_TOTAL = @TOTAL ,B_COMMENT=@COMMENT WHERE B_ID = @ID";
                cmd.Parameters.AddWithValue("@TIME", bud.getDateTime());
                cmd.Parameters.AddWithValue("@TYPE", bud.getType());
                cmd.Parameters.AddWithValue("@QUANTITY", bud.getQuantity());
                cmd.Parameters.AddWithValue("@TOTAL", bud.getTotal());
                cmd.Parameters.AddWithValue("@COMMENT", bud.getComment());
                cmd.Parameters.AddWithValue("@ID", bud.getId());
                cmd.ExecuteNonQuery();
                tr.Commit();
                FLAG = true;
            }
            catch (Exception ex)
            {
                FLAG = false;
                tr.Rollback();
            }
            finally
            {
                DBUtil.CloseConnection(conn);
            }

            return FLAG;
        }

        public bool removeData(object obj)
        {
            Budget bud = (Budget)obj;
            Boolean FLAG = false;
            MySqlTransaction tr = null;
            try
            {
                conn = getConnection();
                tr = conn.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = tr;
                cmd.CommandText = "DELETE FROM GP_BUDGET WHERE B_ID=@ID";
                cmd.Parameters.AddWithValue("@ID", bud.getId());
                cmd.ExecuteNonQuery();
                tr.Commit();
                FLAG = true;
            }
            catch (Exception ex)
            {
                FLAG = false;
                tr.Rollback();
            }
            finally
            {
                DBUtil.CloseConnection(conn);
            }
            return FLAG;
        }
    }
}
