using System;

namespace GPManagement.GP.Entity
{
    class Schedule
    {
        private int id;
        private DateTime time;
        private String type;
        private String place;
        private String content;
        private String comment;
        private String strFilter;

        public Schedule()
        {

        }
        public Schedule(DateTime date, String type, String place, String content, String comment)
        {
            this.time = date;
            this.type = type;
            this.place= place;
            this.content = content;
            this.comment = comment;
        }

        public void setTime(DateTime time)
        {
            this.time = time;
        }

        public void setType(String type)
        {
            this.type = type;
        }

        public void setPlace(String place)
        {
            this.place = place;
        }

        public void setContent(String content)
        {
            this.content = content;
        }

        public void setComment(String comment)
        {
            this.comment = comment;
        }

        public DateTime getTime()
        {
            return this.time;
        }

        public String getType()
        {
            return this.type;
        }

        public String getPlace()
        {
            return this.place;
        }

        public String getContent()
        {
            return this.content;
        }

        public String getComment()
        {
            return this.comment;
        }

        public int getId()
        {
            return this.id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public void setStrFilter(String strFilter)
        {
            this.strFilter = strFilter;
        }

        public String getStrFilter()
        {
            return this.strFilter;
        }

    }
}
