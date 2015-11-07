using System.Collections.Generic;
using GPManagement.GP.Dao;

namespace GPManagement.GP.Service
{
    class ScheduleService : IService
    {
        ScheduleDao dao = new ScheduleDao();

        public List<object> getAllData(object obj, string sortColumn, bool asc, bool exactFilter)
        {
            return dao.getAllData(obj, sortColumn, asc, exactFilter);
        }

        public bool insertNewData(object obj)
        {
            return dao.insertNewData(obj);
        }

        public bool removeData(object obj)
        {
            return dao.removeData(obj);
        }

        public bool updateData(object obj)
        {
            return dao.updateData(obj);
        }
    }
}
