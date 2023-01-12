using CommercialApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CommercialApp.Controllers
{
    public class HomeController : Controller
    {

        #region Constructor
        private readonly ILogger<HomeController> _logger;
        private readonly CAppDbContext _context;


        public HomeController(ILogger<HomeController> logger, CAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            string x = this.HttpContext.Session.GetString("user");
            return View();
        }
        #endregion

        #region Privacy
        public IActionResult Privacy()
        {
            return View();
        }
        #endregion

        #region Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion

        //Two actions for Login: - one for Singular users -another for Company users
        #region Login
        public async Task<IActionResult> LoginSingular()
        {           
                return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginSingular(Singular singular)
        {
            Singular userlogged = await _context.Singular.Where(c => c.Username == singular.Username && c.Password == singular.Password).FirstOrDefaultAsync();

            if (userlogged == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid acess!Please check your user and password");
                return View();
            }
            string logged = userlogged.Name;
            string loggedId = Convert.ToString(userlogged.PeopleId);
            this.HttpContext.Session.SetString("userId", loggedId);
            this.HttpContext.Session.SetString("user", logged);
            this.HttpContext.Session.SetString("type", "singular");
            this.HttpContext.Session.SetString("cartCount", "");

            try
            {
                Transaction transaction = await _context.Transaction.Where(u => u.State == "Open").Where(u => u.Singular.PeopleId.Equals(userlogged.PeopleId) && u.State == "Open").Include(m => m.TransactionDetails).FirstOrDefaultAsync();
                if (transaction != null)
                {
                    string transactionId = Convert.ToString(transaction.TransactionId);
                    List<TransactionDetail> TransactionDetails = await _context.TransactionDetail.Where(u => u.TransactionId == transaction.TransactionId).ToListAsync();
                    if (TransactionDetails.Count == 0 || TransactionDetails == null)
                        this.HttpContext.Session.SetString("cartCount", "");
                    else
                    {
                        string cartCount = Convert.ToString(transaction.TransactionDetails.Count());
                        this.HttpContext.Session.SetString("cartCount", cartCount);
                    }
                    this.HttpContext.Session.SetString("transactionId", transactionId);
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> LoginCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginCompany(Company company)
        {

            Company userlogged = await _context.Company.Where(c => c.Username == company.Username && c.Password == company.Password).FirstOrDefaultAsync();

            if (userlogged == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid acess!Please check your user and password");
                return View();
            }
            string logged = userlogged.Name;
            string loggedId = Convert.ToString(userlogged.PeopleId);
            this.HttpContext.Session.SetString("userId", loggedId);
            this.HttpContext.Session.SetString("type", "company");
            this.HttpContext.Session.SetString("user", logged);
            this.HttpContext.Session.SetString("cartCount", "");


            return RedirectToAction("Index");
        }
        #endregion

        #region Logout
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("user");
            HttpContext.Session.Remove("userId");
            HttpContext.Session.Remove("type");
            HttpContext.Session.Remove("cartCount");

            return RedirectToAction("Index", "Home");
        }
        #endregion

    }
}
