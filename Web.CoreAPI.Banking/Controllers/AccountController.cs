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
using Banking.NETCore.API.Validation;
using AutoMapper;
using Banking.AppCore.Common.Entities;

namespace Banking.NETCore.API.Controllers
{
    public class AccountController: Controller
    {
        private ILogger<AccountController> _logger;
        private IAccountManager _acctMgr;

        public AccountController(ILogger<AccountController> logger, IAccountManager acctMgr)
        {
            _logger = logger;
            _acctMgr = acctMgr;
        }

        [HttpPost]
        [Route("banking/account/primarychecking")]
        public IActionResult CreatePrimaryCheckingDeposit([FromBody] TransactionDTO transaction)
        {
            try
            {
                if (BankAccountValidation.VerifyInputForDeposit(_logger, transaction) == false)
                {
                    return BadRequest("The deposit type is not known");
                }

                //note:  wrapping the uow into a using block to approximate true data access against a DB, per best practices
                using (IUnitOfWork uow = new UnitOfWork())
                {
                    var acctFactory = new AccountFactory();
                    var primaryChecking = acctFactory.CreateInstance(AccountTypeEnum.PrimaryChecking);

                    IAccountManager acctMgr = new AccountManager(primaryChecking, uow);
                    var transactionEntity = Mapper.Map<Transaction>(transaction);
                    acctMgr.RecordDepositOrWithdrawal(transactionEntity);

                    return StatusCode(201);
                }
            }

            catch (Exception ex)
            {
                _logger.LogCritical($"Exception thrown in the AccountController.  Message details:  {ex.Message}");
                return StatusCode(500, "An error was detected in the Account Controller.  View message log for details.");
            }
        }


        [HttpGet]
        [Route("banking/account/primarychecking/{fromDt}/{toDt}")]
        public IActionResult GetPrimaryCheckingTransactionHistory(DateTime? fromDt, DateTime? toDt)
        {
            try
            {
                if (BankAccountValidation.VerifyInputFromDate(_logger, fromDt.Value) == false)
                    return BadRequest("The To Date input value is not valid");

                toDt = BankAccountValidation.VerifyInputToDate(_logger, toDt.Value);


                //note:  wrapping the uow into a using block to approximate true data access against a DB, per best practices
                using (IUnitOfWork uow = new UnitOfWork())
                {
                    var acctFactory = new AccountFactory();
                    var primaryChecking = acctFactory.CreateInstance(AccountTypeEnum.PrimaryChecking);

                    IAccountManager acctMgr = new AccountManager(primaryChecking, uow);
                    primaryChecking.Ledger = acctMgr.ViewLedgerByDateRange(fromDt.Value, toDt.Value);
                    var results = Mapper.Map<IEnumerable<TransactionDTO>>(primaryChecking.Ledger);

                    return Ok(results);
                }
            }

            catch (Exception ex)
            {
                _logger.LogCritical($"Exception thrown in the AccountController.  Message details:  {ex.Message}");
                return StatusCode(500, "An error was detected in the Account Controller.  View message log for details.");
            }
        }


        [HttpGet]
        [Route("banking/account/secondarychecking/{fromDt}/{toDt}")]
        public IActionResult GetSecondaryCheckingTransactionHistory(DateTime? fromDt, DateTime? toDt)
        {
            try
            {
                if (BankAccountValidation.VerifyInputFromDate(_logger, fromDt.Value) == false)
                    return BadRequest("The To Date input value is not valid");

                toDt = BankAccountValidation.VerifyInputToDate(_logger, toDt.Value);

                //note:  wrapping the uow into a using block to approximate true data access against a DB, per best practices
                using (IUnitOfWork uow = new UnitOfWork())
                {
                    var acctFactory = new AccountFactory();
                    var secondaryChecking = acctFactory.CreateInstance(AccountTypeEnum.SecondaryChecking);

                    IAccountManager acctMgr = new AccountManager(secondaryChecking, uow);
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
