using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseDAL
{
    public interface IBase<T>
    {
        int InsertRecord(T item);
        int UpdateRecord(T item);
        int DeleteRecord(string id);
        List<T> GetRecords(string where);
        T GetRecord(string where);
    }
}
