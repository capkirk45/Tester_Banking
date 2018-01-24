using System;
using Core.Common.Entities;
using Core.Business.Interfaces;
using Core.Common.Interfaces;
using System.Collections.Generic;
using Core.DataAccess;

namespace Core.Business
{
    public class AccountManager : IAccountManager
    {
        private IAccount _account;
        private IUnitOfWork _uow;

        public AccountManager(IAccount account, IUnitOfWork uow)
        {
            _account = account;
            _uow = uow;
        }

        public void CreateDepositOrCredit(Transaction t)
        {
            if (t == null) throw new Exception("The transaction is not valid");
            _uow.AccountRepository.DebitOrCreditAccount(t);
        }

   
        public List<Transaction> ViewLedgerByDateRange(DateTime fromDt, DateTime toDt)
        {
            return _uow.AccountRepository.GetLedgerByDateRange(fromDt, toDt);
        }

        public decimal CheckBalance(List<Transaction> ledger)
        {
            throw new NotImplementedException();
        }
    }
}
