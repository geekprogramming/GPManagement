using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPManagement.GP.Entity
{
    public class Employee
    {
        private int id;
        private String name;
        private String phone;
        private String email;
        private DateTime birthday;
        private String image;
        private byte[] bImage;
        /*
            strFilter không phải là một trường trong database
            Nó dùng để lọc dữ liệu trong EmployeeDAO, xem hàm getAllEmployee
        */
        private String strFilter;

        public Employee()
        {
            
        }

        public void setStrFilter(String strFilter)
        {
            this.strFilter = strFilter;
        }

        public String getStrFilter()
        {
            return this.strFilter;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getName()
        {
            return this.name;
        }

        public void setPhone(String phone)
        {
            this.phone = phone;
        }

        public String getPhone()
        {
            return this.phone;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }

        public String getEmail()
        {
            return this.email;
        }

        public void setBirthday(DateTime birthday)
        {
            this.birthday = birthday;
        }

        public DateTime getBirthday()
        {
            return this.birthday;
        }

        public void setImage(String image)
        {
            this.image = image;
        }

        public String getImage()
        {
            return this.image;
        }

        public void setBImage(byte[] bImage)
        {
            this.bImage = bImage;
        }

        public byte[] getBImage()
        {
            return this.bImage;
        }

    }
}
