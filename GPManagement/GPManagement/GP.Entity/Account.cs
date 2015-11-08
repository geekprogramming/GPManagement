using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPManagement.GP.Entity
{
    class Account
    {
        private int idEmp;
        private string userName;
        private string passWord;
        private string strFilter;

        public Account()
        {

        }

        public Account(int idEmp, string userName, string passWord)
        {
            this.idEmp = idEmp;
            this.userName = userName;
            this.passWord = passWord;
        }

        public void setIdEmp(int idEmp)
        {
            this.idEmp = idEmp;
        }

        public void setUserName(string userName)
        {
            this.userName = userName;
        }

        public void setPassWord(string passWord)
        {
            this.passWord = passWord;
        }

        public int getIdEmp()
        {
            return this.idEmp;
        }

        public string getUserName()
        {
            return this.userName;
        }

        public string getPassWord()
        {
            return this.passWord;
        }

        public string getStrFilter()
        {
            return this.strFilter;
        }

        public void setStrFilter(String strFilter)
        {
            this.strFilter = strFilter;
        }
    }
}
