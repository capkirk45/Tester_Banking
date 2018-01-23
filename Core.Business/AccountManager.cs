using System;
using Core.Common.Entities;
using System.Collections;
using Core.Business.Interfaces;
using Core.Common.Interfaces;
using System.Collections.Generic;

namespace Core.Business
{
    public class AccountManager : IAccountManager
    {
        private IAccount _account;

        public AccountManager(IAccount account)
        {
            _account = account;


        }


        public void CreateDepositOrCredit(Transaction t)
        {
            if (_account == null || _account.Ledger == null) throw new Exception("A valid Account is needed");
            _account.Ledger.Add(t);
        }

   
        public List<Transaction> ViewLedgerByDateRange(DateTime fromDt, DateTime toDt)
        {
            throw new NotImplementedException();
        }

        public decimal CheckBalance(List<Transaction> ledger)
        {
            throw new NotImplementedException();
        }
    }
}
