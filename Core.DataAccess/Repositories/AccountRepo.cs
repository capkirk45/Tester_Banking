using Core.Common.Entities;
using Core.Common.Enums;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using Core.Common.Interfaces;
using MoreLinq;

namespace Core.DataAccess
{
    /// <summary>
    /// Purpose:  CRUD processing against Data Store
    /// </summary>
    public class AccountRepo : IAccountRepo, IDisposable
    {
        private bool _disposed = false;
        private UnitOfWork _uow;

        public AccountRepo(IUnitOfWork uow)
        {
            _uow = uow as UnitOfWork;
            _uow.MasterLedger.SetLedger();
        }

        public List<Transaction> GetLedgerByDateRange(DateTime fromDt, DateTime toDt)
        {
            return (from qry in _uow.MasterLedger.Ledger
                    where qry.TransactionDate > fromDt && qry.TransactionDate < toDt
                    select qry).OrderBy(t => t.TransactionDate).ToList();
        }

        public int TransactionCount()
        {
            return _uow.MasterLedger.Ledger.Count();
        }

        public List<Transaction> GetLedgerByDateRange()
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAllDebits()
        {
            return (from qry in _uow.MasterLedger.Ledger
                    where qry.Type == TransactionTypeEnum.Debit
                    select qry).OrderBy(t => t.TransactionDate).ToList();
        }

        public List<Transaction> GetAllCredits()
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
                return max.Id + 1;
            }
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
