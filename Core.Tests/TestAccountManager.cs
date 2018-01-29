using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Common.Entities;
using Core.Common.Enums;
using Core.Common.Interfaces;
using Core.Business;
using Core.Business.Factories;
using Core.DataAccess;
using System.Collections.Generic;
using Core.DataAccess.Extensions;

namespace Core.Tests
{
    [TestClass]
    public class TestAccountManager : TestBase
    {
        [TestMethod]
        public void TestDebitTransactionCreate()
        {
            var id = _uow.AccountRepository.CreateId();
            var t = new Transaction()
            {
                Id = id,
                Amt = 100,
                TransactionDate = DateTime.UtcNow,
                TransactionDateUtcOffset = DateTimeOffset.UtcNow,
                Type = TransactionTypeEnum.Debit
            };

            _acctMgr.RecordDepositOrCredit(t);
            var ledger = _acctMgr.ViewLedgerByDateRange(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            var cnt = (from qry in ledger where qry.Id == id select qry).Count();
            Assert.AreEqual(ledger.Count, 1);
        }

        [TestMethod]
        public void TestCreditTransactionCreate()
        {
            var id = _uow.AccountRepository.CreateId();
            var tranDt = DateTime.UtcNow;
            var tranUtcOffset = DateTimeOffset.UtcNow;
            var t = new Transaction()
            {
                Id = id,
                Amt = 50,
                TransactionDate = DateTime.UtcNow,
                TransactionDateUtcOffset = DateTimeOffset.UtcNow,
                Type = TransactionTypeEnum.Credit
            };

            _acctMgr.RecordDepositOrCredit(t);
            var ledger = _acctMgr.ViewLedgerByDateRange(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            var cnt = (from qry in ledger where qry.Id == id select qry).Count();
            Assert.AreEqual(ledger.Count, cnt);
        }


        [TestMethod]
        public void TestCalculateBalance()
        {
            //Create a debit transaction
            var id = _uow.AccountRepository.CreateId();
            var tDebit = new Transaction()
            {
                Id = id,
                Amt = 100,
                TransactionDate = DateTime.UtcNow,
                TransactionDateUtcOffset = DateTimeOffset.UtcNow,
                Type = TransactionTypeEnum.Debit
            };
            _acctMgr.RecordDepositOrCredit(tDebit);

            //Create a Credit transaction
            id = _uow.AccountRepository.CreateId();
            var tCredit = new Transaction()
            {
                Id = id,
                Amt = 50,
                TransactionDate = DateTime.UtcNow,
                TransactionDateUtcOffset = DateTimeOffset.UtcNow,
                Type = TransactionTypeEnum.Credit
            };
            _acctMgr.RecordDepositOrCredit(tCredit);
            var ledger = _acctMgr.ViewLedgerByDateRange(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            var cnt = (from qry in ledger select qry).Count();
            Assert.AreEqual(ledger.Count, cnt);


            var balance = _acctMgr.CheckBalance(ledger);
            Assert.AreEqual(balance, (tDebit.Amt = tCredit.Amt));

        }
    }
}