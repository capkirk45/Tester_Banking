using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Common.Enums;

namespace Core.Tests
{
    [TestClass]
    public class TestAccountManager : TestBase
    {
        [TestMethod]
        public void TestDebitTransactionCreate()
        {
            var t = MockTransaction(TransactionTypeEnum.Debit, 100);
            _acctMgr.RecordDepositOrCredit(t);

            var ledger = _acctMgr.ViewLedgerByDateRange(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            var cnt = (from qry in ledger where qry.Id == t.Id select qry).Count();
            Assert.AreEqual(ledger.Count, 1);
        }

        [TestMethod]
        public void TestCreditTransactionCreate()
        {
            var t = MockTransaction(TransactionTypeEnum.Credit, 50);
            _acctMgr.RecordDepositOrCredit(t);

            var ledger = _acctMgr.ViewLedgerByDateRange(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            var cnt = (from qry in ledger where qry.Id == t.Id select qry).Count();
            Assert.AreEqual(ledger.Count, cnt);
        }


        [TestMethod]
        public void TestCalculateBalance()
        {

            var tdebit = MockTransaction(TransactionTypeEnum.Debit, 100);
            _acctMgr.RecordDepositOrCredit(tdebit);

            var tcredit = MockTransaction(TransactionTypeEnum.Credit, 50);
            _acctMgr.RecordDepositOrCredit(tcredit);

            var ledger = _acctMgr.ViewLedgerByDateRange(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            Assert.AreEqual(ledger.Count, 2);

            var balance = _acctMgr.GetAccountBalance(ledger);
            Assert.AreEqual(balance, (tdebit.Amt = tcredit.Amt));

        }
    }
}