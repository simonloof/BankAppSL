using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimonsBankApp.Bank;
using SimonsBankApp.Business;

namespace SimonsBankApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountLogic _accountLogic;
        BankRepository _bankRepository = BankRepository.Instance;

        public AccountController()
        {
            _accountLogic = new AccountLogic(_bankRepository);
        
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Withdrawal(int accountNo, int sum)
        {
            var viewModel = _accountLogic.WithDrawal(accountNo, sum);
            return PartialView("_AccountDetails",viewModel);
        }

        public IActionResult Deposit(int accountNo, int sum)
        {
            var viewModel = _accountLogic.Deposit(accountNo, sum);
            return PartialView("_AccountDetails", viewModel);
        }
    }
}