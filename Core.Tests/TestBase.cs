using Core.Business;
using Core.Business.Factories;
using Core.Common.Entities;
using Core.Common.Enums;
using Core.Common.Interfaces;
using Core.DataAccess;
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
    }
}
