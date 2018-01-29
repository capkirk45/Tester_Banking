using Core.Business;
using Core.Business.Factories;
using Core.Common.Entities;
using Core.Common.Enums;
using Core.Common.Interfaces;
using Core.DataAccess;
using System;
using System.Collections.Generic;

namespace Core.Tests
{
    public class TestBase
    {
        internal IUnitOfWork _uow;
        internal IAccount _primaryChecking;
        internal AccountManager _acctMgr;
        internal AccountFactory _acctFactory;
         
        public TestBase()
        {
            _acctFactory = new AccountFactory();
            _primaryChecking = _acctFactory.CreateInstance(AccountTypeEnum.PrimaryChecking);
            _primaryChecking.Ledger = new List<Transaction>();

            _uow = new UnitOfWork();
            _acctMgr = new AccountManager(_primaryChecking, _uow);
        }

        protected Transaction MockTransaction(TransactionTypeEnum type, decimal amt)
        {
            var id = _uow.AccountRepository.CreateId();
            if (id == 0) throw new Exception("A valid ID could not be created");
            var t = new Transaction()
            {
                Id = id,
                Amt = amt,
                TransactionDate = DateTime.UtcNow,
                TransactionDateUtcOffset = DateTimeOffset.UtcNow,
                Type = type
            };
            return t;
        }

    }
}
