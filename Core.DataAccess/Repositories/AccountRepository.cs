using Banking.AppCore.Common.Entities;
using Banking.AppCore.Common.Enums;
using System.Collections.Generic;
using System.Linq;
using System;
using Banking.AppCore.Common.Interfaces;
using MoreLinq;

namespace Banking.AppCore.DataAccess
{
    /// <summary>
    /// Purpose:  CRUD processing against Data Store
    /// </summary>
    public class AccountRepository : IAccountRepository, IDisposable
    {
        private bool _disposed = false;
        private UnitOfWork _uow;

        public AccountRepository(IUnitOfWork uow)
        {
            _uow = uow as UnitOfWork;
            _uow.MasterLedger.SetLedger();
        }

        public IEnumerable<Transaction> GetLedgerByDateRange(DateTime fromDt, DateTime toDt)
        {
            return (from qry in _uow.MasterLedger.Ledger
                    where qry.TransactionDate > fromDt && qry.TransactionDate < toDt
                        select qry).OrderBy(t => t.TransactionDate).ToList();
        }

        public int TransactionCount()
        {
            return _uow.MasterLedger.Ledger.Count();
        }

        public IEnumerable<Transaction> GetAllDebits()
        {
            return (from qry in _uow.MasterLedger.Ledger
                    where qry.Type == TransactionTypeEnum.Debit
                        select qry).OrderBy(t => t.TransactionDate).ToList();
        }   

        public IEnumerable<Transaction> GetAllCredits()
        {
            return (from qry in _uow.MasterLedger.Ledger
                    where qry.Type == TransactionTypeEnum.Credit
                        select qry).OrderBy(t => t.TransactionDate).ToList();
        }

        public void DebitOrCreditAccount(Transaction t)
        {
            _uow.MasterLedger.Ledger.Add(t);
        }

        public int CreateId()
        {
            if (_uow.MasterLedger.Ledger.Count == 0)
            {
                return 1;
            }
            else
            {
                var max = _uow.MasterLedger.Ledger.MaxBy(i => i.Id);
                return ++max.Id;
            }
        }

        public decimal GetDebitTotalAmt()
        {
            return (from qry
                    in _uow.MasterLedger.Ledger
                    where qry.Type == TransactionTypeEnum.Debit 
                        select qry).Sum(c => c.Amt);
        }

        public decimal GetCreditTotalAmt()
        {
            return (from qry
                    in _uow.MasterLedger.Ledger
                    where qry.Type == TransactionTypeEnum.Credit
                    select qry).Sum(c => c.Amt);
        }
        


        #region IDisposable members
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    //do not dispose the connection here as it was passed in and should be disposed via the uow
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
