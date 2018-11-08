using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimonsBankApp.Bank;
using SimonsBankApp.Models;

namespace SimonsBankApp.Controllers
{
    public class HomeController : Controller
    {
        BankRepository _bankRepository = BankRepository.Instance;

        
        public IActionResult Index()
        {
            var customers = _bankRepository.Customers;
            return View(customers);
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
