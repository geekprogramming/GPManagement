using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Library;
using GPManagement.GP.Entity;

namespace GPManagement.GP.Dao
{
    class ScheduleDao : BaseDAO, IDAO
    {
        public ScheduleDao()
        {
            setConfig("url_mysql");
        }

        public List<object> getAllData(object obj, string sortColumn, bool asc, bool exactFilter)
        {
            List<object> result = new List<object>();
            MySqlTransaction tr = null;
            MySqlDataReader rdr = null;
            String sql = "SELECT * FROM GP_SCHEDULE WHERE 1=1 ";
            Dictionary<String, String> paramDic = new Dictionary<String, String>();
            Schedule schedule = (Schedule)obj;
            if (schedule != null)
            {
                String strFilter = schedule.getStrFilter();
                if (!String.IsNullOrWhiteSpace(strFilter))
                {
                    if (exactFilter)
                    {
                        sql += " AND (S_COMMENT = @COMMENT) ";
                        paramDic.Add("@COMMENT", strFilter);
                    }
                    else
                    {
                        sql += " AND S_COMMENT LIKE @COMMENT ";
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
                    Schedule temp = new Schedule();
                    temp.setTime(rdr.GetDateTime("S_TIME"));
                    temp.setType(rdr.GetString("S_TYPE"));
                    temp.setPlace(rdr.GetString("S_PLACE"));
                    temp.setContent(rdr.GetString("S_CONTENT"));
                    temp.setComment(rdr.GetString("S_COMMENT"));
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
            Schedule schedule = (Schedule)obj;
            bool FLAG = false;
            MySqlTransaction tr = null;
            try
            {
                conn = getConnection();
                tr = conn.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = tr;
                cmd.CommandText = "INSERT INTO GP_SCHEDULE (S_TIME,S_TYPE,S_PLACE,S_CONTENT,S_COMMENT) VALUES(@TIME,@TYPE,@PLACE,@CONTENT,@COMMENT)";
                cmd.Parameters.AddWithValue("@TIME", schedule.getTime());
                cmd.Parameters.AddWithValue("@TYPE", schedule.getType());
                cmd.Parameters.AddWithValue("@PLACE", schedule.getPlace());
                cmd.Parameters.AddWithValue("@CONTENT", schedule.getContent());
                cmd.Parameters.AddWithValue("@COMMENT", schedule.getComment());
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
            Schedule schedule = (Schedule)obj;
            bool FLAG = false;
            MySqlTransaction tr = null;
            try
            {
                conn = getConnection();
                tr = conn.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = tr;
                cmd.CommandText = "UPDATE GP_SCHEDULE SET S_TIME=@TIME, S_TYPE=@TYPE ,S_PLACE = @PLACE ,S_CONTENT = @CONTENT ,S_COMMENT=@COMMENT WHERE S_ID = @ID";
                cmd.Parameters.AddWithValue("@TIME", schedule.getTime());
                cmd.Parameters.AddWithValue("@TYPE", schedule.getType());
                cmd.Parameters.AddWithValue("@PLACE", schedule.getPlace());
                cmd.Parameters.AddWithValue("@CONTENT", schedule.getContent());
                cmd.Parameters.AddWithValue("@COMMENT", schedule.getComment());
                cmd.Parameters.AddWithValue("@ID", schedule.getId());
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
            Schedule schedule = (Schedule)obj;
            bool FLAG = false;
            MySqlTransaction tr = null;
            try
            {
                conn = getConnection();
                tr = conn.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = tr;
                cmd.CommandText = "DELETE FROM GP_SCHEDULE WHERE S_ID=@ID";
                cmd.Parameters.AddWithValue("@ID", schedule.getId());
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
