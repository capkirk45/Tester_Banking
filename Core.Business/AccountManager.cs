using System;
using Core.Common.Entities;
using Core.Business.Interfaces;
using Core.Common.Interfaces;
using System.Collections.Generic;

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
            //Force an actual date so we don't fetch too much data and bog system down  
            if (fromDt == null) throw new Exception("A valid date range is needed");
            if (toDt == null) toDt = DateTime.UtcNow;
            return _uow.AccountRepository.GetLedgerByDateRange(fromDt, toDt);
        }

        public decimal GetAccountBalance(List<Transaction> ledger)
        {
            return _uow.AccountRepository.GetDebitTotalAmt() - _uow.AccountRepository.GetCreditTotalAmt();
        }

        public List<Transaction> ViewAllDeposits()
        {
            return _uow.AccountRepository.GetAllDebits();
        }
        
        public List<Transaction> ViewAllWithdrawals()
        {
            return _uow.AccountRepository.GetAllCredits();
        }

    }
}
