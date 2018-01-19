using Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Entities;
using System.Collections;

namespace Core.Business
{
    public class TransactionManager : ITransactionManager
    {
        public void CreateTransaction(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable ViewTransactionHistory(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
