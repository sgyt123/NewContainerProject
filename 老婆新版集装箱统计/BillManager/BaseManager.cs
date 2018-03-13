using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace BillManager
{
    public class BaseManager<T>
    {
        public bool InsertBoxSize(T b)
        {
            return new BaseService<T>().InsertRecord(b)>0?true:false;
        }

        public bool UpdateBoxSize(T b)
        {
            return new BaseService<T>().UpdateRecord(b) > 0 ? true : false;
        }

        public bool DeleteBoxSize(string id)
        {
            return new BaseService<T>().DeleteRecord(id) > 0 ? true : false;
        }
    }
}
