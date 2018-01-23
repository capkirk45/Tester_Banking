using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Common.Entities;
using Core.Common.Enums;
using Core.Common.Interfaces;
using Core.Business;
using Core.Business.Factories;

namespace Core.Tests
{
    [TestClass]
    public class TestAccountManager: TestBase
    {
        [TestMethod]
        public void TestCreateDebitTransaction()
        {
            var acctFactory = new AccountFactory();
            IAccount primaryChecking = acctFactory.CreateInstance(AccountTypeEnum.PrimaryChecking);

            var acctMgr = new AccountManager(primaryChecking);
            primaryChecking.Ledger = new DataAccess.AccountRepo();

            var t = new Transaction()
            {
                Id = 1,
                Amt = 100,
                TransactionDate = DateTime.UtcNow,
                TransactionDateUtcOffset = DateTimeOffset.UtcNow,
                Type = TransactionTypeEnum.Debit
            };

            acctMgr.CreateDepositOrCredit(t);

            Assert.AreEqual(primaryChecking.Ledger.TransactionCount(), 1);
        }
    }
}
