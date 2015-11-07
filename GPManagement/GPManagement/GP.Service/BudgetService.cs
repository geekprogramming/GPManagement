using System.Collections.Generic;
using GPManagement.GP.Dao;


namespace GPManagement.GP.Service
{
    class BudgetService : IService
    {
        BubgetDAO budDao = new BubgetDAO();

        public List<object> getAllData(object obj, string sortColumn, bool asc, bool exactFilter)
        {
            return budDao.getAllData(obj, sortColumn, asc, exactFilter);
        }

        public bool insertNewData(object obj)
        {
            return budDao.insertNewData(obj);
        }

        public bool removeData(object obj)
        {
            return budDao.removeData(obj);
        }

        public bool updateData(object obj)
        {
            return budDao.updateData(obj);
        }
    }
}
