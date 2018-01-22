using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Common.Entities;
using Core.Common.Enums;
using Core.Business;


namespace AltSourceInterviewProject
{
    [TestClass]
    public class TestAccountManager
    {
        [TestMethod]
        public void RecordADeposit()
        {
            var acctMgr = new AccountManager(new PrimaryAccount());
            var t = new Transaction()
            {
                Id = 1,
                Amt = 100,
                TransactionDate = DateTime.UtcNow,
                TransactionDateUtcOffset = DateTimeOffset.UtcNow,
                Type = TransactionTypeEnum.Debit
            };
            acctMgr.RecordDeposit(t);
        }
    }
}
