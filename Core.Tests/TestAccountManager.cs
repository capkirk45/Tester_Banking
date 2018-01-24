using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Common.Entities;
using Core.Common.Enums;
using Core.Common.Interfaces;
using Core.Business;
using Core.Business.Factories;
using Core.DataAccess;
using System.Collections.Generic;

namespace Core.Tests
{
    [TestClass]
    public class TestAccountManager: TestBase
    {
        [TestMethod]
        public void TestCreateDebitTransaction()
        {

            var t = new Transaction()
            {
                Id = 1,
                Amt = 100,
                TransactionDate = DateTime.UtcNow,
                TransactionDateUtcOffset = DateTimeOffset.UtcNow,
                Type = TransactionTypeEnum.Debit
            };

            _acctMgr.CreateDepositOrCredit(t);
            var ledger = _acctMgr.ViewLedgerByDateRange(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            Assert.AreEqual(ledger.Count, 1);
        }
    }
}
    