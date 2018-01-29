using System;
using Core.Common.Entities;
using Core.Business.Interfaces;
using Core.Common.Interfaces;
using System.Collections.Generic;
using Core.Common.Enums;

namespace Core.Business
{
    /// <summary>
    /// Domain / Business logical processing
    /// </summary>
    public class AccountManager : IAccountManager
    {
        private IAccount _account;
        private IUnitOfWork _uow;

        public AccountManager(IAccount account, IUnitOfWork uow)
        {
            _account = account;
            _uow = uow;
        }

        public void RecordDepositOrCredit(Transaction t)
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
            decimal debits = 0;
            decimal credits = 0;
            foreach (Transaction t in ledger)
            {
                if (t.Type == TransactionTypeEnum.Debit)
                    debits = debits + t.Amt;
                else
                    credits = credits + t.Amt;
            }
            return debits - credits;
        }

    }
}
