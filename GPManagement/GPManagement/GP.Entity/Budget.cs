using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPManagement.GP.Entity
{
    class Budget
    {
        public string TIME = "B_TIME";
        public string TYPE = "B_TYPE";
        public string QUANTITY = "B_QUANTITY";
        public string TOTAL = "B_TOTAL";
        public string COMMENT = "B_COMMENT";
        private int id;
        private DateTime date;
        private String type;
        private double quantity;
        private double total;
        private String comment;
        private String strFilter;

        public Budget()
        {

        }
        public Budget(DateTime date, String type, double quantity, double total, String comment)
        {
            this.date = date;
            this.type = type;
            this.quantity = quantity;
            this.total = total;
            this.comment = comment;
        }

        public void setDate(DateTime date)
        {
            this.date = date;
        }

        public void setType(String type)
        {
            this.type = type;
        }

        public void setQuantity(double quantity)
        {
            this.quantity = quantity;
        }

        public void setTotal(double total)
        {
            this.total = total;
        }

        public void setComment(String comment)
        {
            this.comment = comment;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public DateTime getDateTime()
        {
            return this.date;
        }

        public String getType()
        {
            return this.type;
        }

        public double getQuantity()
        {
            return this.quantity;
        }

        public double getTotal()
        {
            return this.total;
        }

        public String getComment()
        {
            return this.comment;
        }

        public int getId()
        {
            return this.id;
        }

        public void setStrFilter(String filter)
        {
            this.strFilter = filter;

        }

        public String getStrFilter()
        {
            return this.strFilter;
        }

    }
}
