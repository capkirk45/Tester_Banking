using System;
using Microsoft.Extensions.Logging;
using Banking.NETCore.API.Controllers;
using Banking.AppCore.Common.DTOs;
using Banking.AppCore.Common.Enums;

namespace Banking.NETCore.API.Validation
{
    public static class BankAccountValidation
    {
        public static bool VerifyInputFromDate(ILogger<AccountController> logger, DateTime date)
        {
            if (date == null)
            {
                logger.LogCritical($"A valid date From Date value was not included.  Date parameters:  Invalid FromDate passed: {date}");
                return false;
            }
            return true;
        }
        public static DateTime VerifyInputToDate(ILogger<AccountController> logger, DateTime date)
        {
            if (date == null)
            {
                logger.LogInformation($"No To Date was included.  Setting value to current date");
                return DateTime.Now;
            }
            return date;
        }

        public static bool VerifyInputForDeposit(ILogger<AccountController> logger, TransactionDTO t)
        {
            if (t.Type != null || t.Type == TransactionTypeEnum.Credit || t.Type == TransactionTypeEnum.Debit)
            {
                return true;
            }
            logger.LogCritical($"A valid deposit type was not included:  Invalid deposit type passed:  {t.Type}");
            return false;
        }

    }
}
