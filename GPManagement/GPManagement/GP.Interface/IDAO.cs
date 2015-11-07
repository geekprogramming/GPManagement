using System.Collections.Generic;


namespace GPManagement
{
    interface IDAO
    {
        List<object> getAllData(object obj, string sortColumn, bool asc, bool exactFilter);
        bool insertNewData(object obj);
        bool updateData(object obj);
        bool removeData(object obj);
        
    }
}
