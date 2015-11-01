using GPManagement.GP.Dao;
using GPManagement.GP.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPManagement.GP.Service
{
    public class EmployeeService
    {
        private EmployeeDAO dao = new EmployeeDAO();
        public List<Employee> getAllEmployee(Employee emp, String sortColumn, Boolean asc, Boolean exactFilter)
        {
            return dao.getAllEmployee(emp, sortColumn, asc, exactFilter);
        }

        public Boolean insertNewEmployee(Employee emp)
        {
            return dao.insertNewEmployee(emp);
        }

        public Boolean updateEmployee(Employee emp)
        {
            return dao.updateEmployee(emp);
        }

        public Boolean removeEmployee(Employee emp)
        {
            return dao.removeEmployee(emp);
        }
    }
}
