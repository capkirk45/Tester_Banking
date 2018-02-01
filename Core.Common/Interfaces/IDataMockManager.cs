using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.AppCore.Common.Interfaces
{
    public interface IDataMockManager: IEnumerable
    {
        void GetData<T>(T data);
        List<T> GetListData<T>(T datatype);

    }
}
