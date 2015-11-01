using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using GPManagement.GP.Entity;
using Library;
namespace GPManagement.GP.Dao
{
    public class EmployeeDAO
    {
        private MySqlConnection conn = null;
        private MySqlConnection getConnection()
        {
            String cs = DBUtil.getConnectionString("url_mysql");
            return DBUtil.getConnection(cs);
        }
        public List<Employee> getAllEmployee(String sortColumn,Boolean asc, Boolean exactFilter)
        {
            List<Employee> result = new List<Employee>();
            
            return result;
        }

        public Boolean insertNewEmployee(Employee emp)
        {
            Boolean FLAG = false;
            MySqlTransaction tr = null;
            try
            {
                conn = getConnection();
                tr = conn.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = tr;
                cmd.CommandText = "INSERT INTO GP_EMPLOYEE(E_NAME,E_PHONE,E_EMAIL,E_BIRTH_DAY,E_IMAGE) VALUES(@NAME,@PHONE,@EMAIL,@BIRTHDAY,@IMAGE)";
                cmd.Parameters.AddWithValue("@NAME",emp.getName());
                cmd.Parameters.AddWithValue("@PHONE", emp.getPhone());
                cmd.Parameters.AddWithValue("@EMAIL", emp.getEmail());
                cmd.Parameters.AddWithValue("@BIRTHDAY", emp.getPhone());
                cmd.Parameters.AddWithValue("@IMAGE", ConvertUtil.convertFileToBufferData(emp.getImage()));
                cmd.ExecuteNonQuery();
                tr.Commit();
                FLAG = true;
            }catch(Exception ex)
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

        public Boolean updateEmployee(Employee emp)
        {
            Boolean FLAG = false;
            MySqlTransaction tr = null;
            try
            {
                conn = getConnection();
                tr = conn.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = tr;
                cmd.CommandText = "UPDATE GP_EMPLOYEE SET E_NAME=@NAME, E_PHONE=@PHONE, E_EMAIL=@EMAIL, E_BIRTH_DAY=@BIRTHDAY, E_IMAGE=@IMAGE WHERE E_ID = @ID";
                cmd.Parameters.AddWithValue("@NAME", emp.getName());
                cmd.Parameters.AddWithValue("@PHONE", emp.getPhone());
                cmd.Parameters.AddWithValue("@EMAIL", emp.getEmail());
                cmd.Parameters.AddWithValue("@BIRTHDAY", emp.getPhone());
                cmd.Parameters.AddWithValue("@IMAGE", ConvertUtil.convertFileToBufferData(emp.getImage()));
                cmd.Parameters.AddWithValue("@ID", emp.getId());
                cmd.ExecuteNonQuery();
                tr.Commit();
                FLAG = true;
            }catch(Exception ex)
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

        public Boolean removeEmployee(Employee emp)
        {
            Boolean FLAG = false;
            MySqlTransaction tr = null;
            try
            {
                conn = getConnection();
                tr = conn.BeginTransaction();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = tr;
                cmd.CommandText = "DELETE FROM GP_EMPLOYEE WHERE E_ID=@ID";
                cmd.Parameters.AddWithValue("@ID", emp.getId());
                cmd.ExecuteNonQuery();
                tr.Commit();
                FLAG = true;
            }
            catch(Exception ex)
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
