using System;
using Banking.Core.Common.Entities;
using Banking.Core.Business.Interfaces;
using Banking.Core.Common.Interfaces;
using System.Collections.Generic;

namespace Banking.Core.Business
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

        public void RecordDepositOrWithdrawal(Transaction t)
        {
            if (t == null) throw new Exception("The transaction is not valid");
            _uow.AccountRepository.DebitOrCreditAccount(t);
        }

   
        public IEnumerable<Transaction> ViewLedgerByDateRange(DateTime fromDt, DateTime toDt)
        {
            //Force an actual date so we don't fetch too much data and bog system down  
            if (fromDt == null) throw new Exception("A valid date range is needed");
            if (toDt == null) toDt = DateTime.UtcNow;
            return _uow.AccountRepository.GetLedgerByDateRange(fromDt, toDt);
        }

        public decimal GetAccountBalance(IEnumerable<Transaction> ledger)
        {
            return _uow.AccountRepository.GetDebitTotalAmt() - _uow.AccountRepository.GetCreditTotalAmt();
        }

        public IEnumerable<Transaction> ViewAllDeposits()
        {
            return _uow.AccountRepository.GetAllDebits();
        }
        
        public IEnumerable<Transaction> ViewAllWithdrawals()
        {
            return _uow.AccountRepository.GetAllCredits();
        }

    }
}
