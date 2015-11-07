using System.Collections.Generic;

namespace GPManagement
{
    interface IService
    {
        List<object> getAllData(object obj, string sortColumn, bool asc, bool exactFilter);
        bool insertNewData(object obj);
        bool updateData(object obj);
        bool removeData(object obj);
    }
}
