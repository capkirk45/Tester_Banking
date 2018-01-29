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
        public void TestDepositTransactionCreate()
        {
            var t = MockTransaction(TransactionTypeEnum.Debit, 100);
            _acctMgr.RecordDepositOrWithdrawal(t);

            var ledger = _acctMgr.ViewLedgerByDateRange(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            var cnt = (from qry in ledger where qry.Id == t.Id select qry).Count();
            Assert.AreEqual(ledger.Count, 1);
        }

        [TestMethod]
        public void TestWithdrawalTransactionCreate()
        {
            var t = MockTransaction(TransactionTypeEnum.Credit, 50);
            _acctMgr.RecordDepositOrWithdrawal(t);

            var ledger = _acctMgr.ViewLedgerByDateRange(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            var cnt = (from qry in ledger where qry.Id == t.Id select qry).Count();
            Assert.AreEqual(ledger.Count, cnt);
        }

        [TestMethod]
        public void TestCalculateBalance()
        {

            var tdebit = MockTransaction(TransactionTypeEnum.Debit, 100);
            _acctMgr.RecordDepositOrWithdrawal(tdebit);

            var tcredit = MockTransaction(TransactionTypeEnum.Credit, 50);
            _acctMgr.RecordDepositOrWithdrawal(tcredit);

            var ledger = _acctMgr.ViewLedgerByDateRange(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
            Assert.AreEqual(ledger.Count, 2);

            var balance = _acctMgr.GetAccountBalance(ledger);
            Assert.AreEqual(balance, (tdebit.Amt = tcredit.Amt));
        }

        [TestMethod]
        public void TestCreateAndViewAllDeposits()
        {

            var tdeposit = MockTransaction(TransactionTypeEnum.Debit, 100);
            _acctMgr.RecordDepositOrWithdrawal(tdeposit);

            tdeposit = MockTransaction(TransactionTypeEnum.Debit, 50);
            _acctMgr.RecordDepositOrWithdrawal(tdeposit);

            tdeposit = MockTransaction(TransactionTypeEnum.Debit, 50);
            _acctMgr.RecordDepositOrWithdrawal(tdeposit);

            tdeposit = MockTransaction(TransactionTypeEnum.Debit, 230);
            _acctMgr.RecordDepositOrWithdrawal(tdeposit);

            tdeposit = MockTransaction(TransactionTypeEnum.Debit, 20);
            _acctMgr.RecordDepositOrWithdrawal(tdeposit);

            var deposits = _acctMgr.ViewAllDeposits();
            Assert.AreEqual(5, deposits.Count);

            var debitTotalAmt = (from qry in deposits
                                 select qry).Sum(t => t.Amt);
            Assert.AreEqual(450, debitTotalAmt);

        }

        [TestMethod]
        public void TestCreateAndViewAllWithdrawals()
        {

            var twithdrawal = MockTransaction(TransactionTypeEnum.Credit, 75);
            _acctMgr.RecordDepositOrWithdrawal(twithdrawal);

            twithdrawal = MockTransaction(TransactionTypeEnum.Credit, 100);
            _acctMgr.RecordDepositOrWithdrawal(twithdrawal);

            twithdrawal = MockTransaction(TransactionTypeEnum.Credit, 10);
            _acctMgr.RecordDepositOrWithdrawal(twithdrawal);

            twithdrawal = MockTransaction(TransactionTypeEnum.Credit, 200);
            _acctMgr.RecordDepositOrWithdrawal(twithdrawal);

            twithdrawal  = MockTransaction(TransactionTypeEnum.Credit, 80);
            _acctMgr.RecordDepositOrWithdrawal(twithdrawal);

            var withdrawals = _acctMgr.ViewAllWithdrawals();
            Assert.AreEqual(5, withdrawals.Count);

            var withdrawalTotalAmt = (from qry in withdrawals
                                        select qry).Sum(t => t.Amt);
            Assert.AreEqual(465, withdrawalTotalAmt);
        }

    }
}