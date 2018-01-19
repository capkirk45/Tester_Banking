using Core.Common.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Interfaces
{
    public interface ITransactionManager
    {
        void CreateTransaction(Transaction transaction);
        IEnumerable ViewTransactionHistory(Account account);
    }
}
