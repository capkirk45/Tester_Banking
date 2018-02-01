using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Banking.AppCore.Common.Interfaces;
using Banking.AppCore.Common.Enums;
using Banking.AppCore.Common.DTOs;
using Banking.AppCore.Business;
using Banking.AppCore.Business.Interfaces;
using Banking.AppCore.Business.Factories;
using Banking.AppCore.DataAccess;
using AutoMapper;

namespace Banking.NETCore.API.Controllers
{
    public class AccountController: Controller
    {
        private ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("banking/account/primarychecking/{fromDt}/{toDt}")]
        public IActionResult GetPrimaryCheckingTransactionHistory(DateTime? fromDt, DateTime? toDt)
        {
            try
            {
                if (fromDt == null || toDt == null)
                {
                    _logger.LogError($"A valid date range was not included.  Date parameters:  From Date: {fromDt} To Date: {toDt}");
                    return NotFound();
                }

                //note:  wrapping the uow into a using block to approximate true data access against a DB, per best practices
                using (IUnitOfWork uow = new UnitOfWork())
                {
                    var acctFactory = new AccountFactory();
                    var primaryChecking = acctFactory.CreateInstance(AccountTypeEnum.PrimaryChecking);

                    IAccountManager acctMgr = new AccountManager(primaryChecking, uow);
                    var ledger = acctMgr.ViewLedgerByDateRange(fromDt.Value, toDt.Value);
                    var results = Mapper.Map<IEnumerable<TransactionDTO>>(ledger);
                    return Ok(results);
                }
            }

            catch (Exception ex)
            {
                _logger.LogCritical($"Exception thrown in the AccountController.  Message details:  {ex.Message}");
                return StatusCode(500, "An error was detected in the Account Controller.  View message log for details.");
            }
        }

    }
}
