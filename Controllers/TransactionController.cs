using AspNetCoreHero.ToastNotification.Abstractions;
using CommercialApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommercialApp.Controllers
{
    public class TransactionController : Controller
    {

        #region Constructor
        private readonly CAppDbContext _context;

        private readonly INotyfService _notyf;
        private IHttpContextAccessor acessor { get; set; }

        public TransactionController(CAppDbContext context, IHttpContextAccessor a, INotyfService notyf)
        {
            _context = context;
            acessor = a;
            _notyf = notyf;
        }
        #endregion

        //Three diferent actions to acess lists of transactions:
        //Index - wich is only available for the user "admin"
        //GetTransactionByCompany wich is only available for Companies
        //GetTransactionByCompany wich is only available for Singular users
        #region Index
        // GET: Transaction
        public async Task<IActionResult> Index()
        {
            if (acessor.HttpContext.Session.GetString("user") == "admin")
            {
                var cAppDbContext = await _context.Transaction.Include(t => t.Singular).ToListAsync();
                return View(cAppDbContext);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> GetTransactionByCompany()
        {
            if (acessor.HttpContext.Session.GetString("type") == "company")
            {
                int idx = Convert.ToInt32(acessor.HttpContext.Session.GetString("userId"));
                IEnumerable<Transaction> cAppDbContext = await _context.Transaction.Include(t => t.Singular).Include(t => t.TransactionDetails).ThenInclude(t => t.Product).ThenInclude(t => t.Company).ToListAsync();
                IEnumerable<TransactionDetail> tds = await _context.TransactionDetail.Include(t => t.Product).ToListAsync();
                List<Transaction> tByCompany = new List<Transaction>();


                foreach (TransactionDetail item in tds)
                {
                    if (item.Product.CompanyId == idx)
                    {
                        Transaction t = await _context.Transaction.Where(t => t.TransactionId == item.TransactionId).Include(t => t.TransactionDetails).ThenInclude(t => t.Product).ThenInclude(t => t.Company).FirstOrDefaultAsync();

                        tByCompany.Add(t);
                    }
                }

                return View(tByCompany);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> GetTransactionByUser(int id)
        {
            if (acessor.HttpContext.Session.GetString("type") == "singular")
            {
                List<Transaction> transactions = await _context.Transaction.Where(m => m.Singular.PeopleId == id).Include(m => m.TransactionDetails).ToListAsync();


                if (transactions.Count == 0)
                {
                    ViewBag.Error = "You have no orders registered";
                }

                return View(transactions);
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        //Three diferent actions to acess details of transactions:
        //Details - wich is only available for the user "admin"
        //DetailsCompany wich is only available for Companies
        //DetailsSingular wich is only available for Singular users
        #region Details
        // GET: Transaction/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var transaction = await _context.Transaction.Include(t => t.Singular).Include(t => t.TransactionDetails).ThenInclude(t => t.Product).FirstOrDefaultAsync(m => m.TransactionId == id);

            if (transaction == null)
            {
                return NotFound();
            }

            if (acessor.HttpContext.Session.GetString("user") == "admin")
            {
                return View(transaction);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> DetailsSingular(int id)
        {
            if (acessor.HttpContext.Session.GetString("type") == "singular")
            {
                var transaction = await _context.Transaction.Include(t => t.Singular).Include(t => t.TransactionDetails).ThenInclude(t => t.Product).ThenInclude(t => t.Company).FirstOrDefaultAsync(m => m.TransactionId == id);

                return View(transaction);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DetailsCompany(int id)
        {
            if (acessor.HttpContext.Session.GetString("type") == "company")
            {
                var transaction = await _context.Transaction.Include(t => t.Singular).Include(t => t.TransactionDetails).ThenInclude(t => t.Product).ThenInclude(t => t.Company).FirstOrDefaultAsync(m => m.TransactionId == id);

                return View(transaction);
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        //These actions will be used to manage the Transactions/ShoppingCart and are only acessible for Singular users
        #region Cart

        public async Task<IActionResult> AddToCart(int id)
        {
            if (acessor.HttpContext.Session.GetString("type") == "singular")
            {
                int idx = Convert.ToInt32(acessor.HttpContext.Session.GetString("userId"));

                Transaction transaction = await _context.Transaction.Where(u => u.SingularId.Equals(idx) && u.State == "Open").FirstOrDefaultAsync();
                Singular singular = await _context.Singular.Where(u => u.PeopleId.Equals(idx)).FirstOrDefaultAsync();

                if (transaction == null)
                {


                    Transaction newTransaction = new Transaction();
                    newTransaction.State = "Open";
                    newTransaction.DateCreated = DateTime.Now;
                    newTransaction.ChangedBy = acessor.HttpContext.Session.GetString("user");
                    newTransaction.SingularId = Convert.ToInt32(acessor.HttpContext.Session.GetString("userId"));
                    _context.Transaction.Add(newTransaction);
                    await _context.SaveChangesAsync();

                    TransactionDetail tdtl = new TransactionDetail();
                    tdtl.ProductId = id;
                    tdtl.Quantity = 1;
                    tdtl.TransactionId = newTransaction.TransactionId;

                    Product pdt = await _context.Product.FirstOrDefaultAsync(m => m.ProductId == tdtl.ProductId);
                    tdtl.Product = pdt;
                    tdtl.UnitPrice = pdt.UnitPrice;


                    _context.TransactionDetail.Add(tdtl);
                    await _context.SaveChangesAsync();
                    newTransaction.Total += tdtl.Product.GetPriceWithTax();
                    await _context.SaveChangesAsync();
                    _notyf.Custom("Item added to the cart", 10, "#907159", "fa fa-shopping-cart"); string tsId = Convert.ToString(tdtl.TransactionId);
                    this.HttpContext.Session.SetString("transactionId", tsId);


                    if (acessor.HttpContext.Session.GetString("cartCount") != "" && acessor.HttpContext.Session.GetString("cartCount") != "!")
                    {
                        int cart = Convert.ToInt32(acessor.HttpContext.Session.GetString("cartCount"));
                        int cartCountInt = cart + 1;
                        string cartCount = Convert.ToString(cartCountInt);
                        this.HttpContext.Session.SetString("cartCount", cartCount);
                    }
                    else
                        this.HttpContext.Session.SetString("cartCount", "1");


                    return RedirectToAction("Index", "Product");
                }


                if (acessor.HttpContext.Session.GetString("cartCount") != "" && acessor.HttpContext.Session.GetString("cartCount") != "!")
                {
                    int cart = Convert.ToInt32(acessor.HttpContext.Session.GetString("cartCount"));
                    int cartCountInt = cart + 1;
                    string cartCount = Convert.ToString(cartCountInt);
                    this.HttpContext.Session.SetString("cartCount", cartCount);
                }
                else
                    this.HttpContext.Session.SetString("cartCount", "1");

                TransactionDetail tdt = new TransactionDetail();
                tdt.ProductId = id;
                tdt.Quantity = 1;
                tdt.TransactionId = transaction.TransactionId;

                Product pd = await _context.Product.FirstOrDefaultAsync(m => m.ProductId == tdt.ProductId);
                tdt.Product = pd;
                tdt.UnitPrice = pd.UnitPrice;


                _context.TransactionDetail.Add(tdt);
                await _context.SaveChangesAsync();
                transaction.Total += tdt.Product.GetPriceWithTax();
                await _context.SaveChangesAsync();
                _notyf.Custom("Item added to the cart", 10, "#907159", "fa fa-shopping-cart"); string tId = Convert.ToString(tdt.TransactionId);
                this.HttpContext.Session.SetString("transactionId", tId);

                return RedirectToAction("Index", "Product");
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> RemoveProduct(int id)
        {
            if (acessor.HttpContext.Session.GetString("type") == "singular")
            {
                var transactionDetail = await _context.TransactionDetail.Where(t => t.TransactionDetailId == id).Include(t => t.Product).FirstOrDefaultAsync();
                int transactionId = Convert.ToInt32(acessor.HttpContext.Session.GetString("transactionId"));
                Transaction transaction = await _context.Transaction.Where(t => t.TransactionId == transactionId).FirstOrDefaultAsync();
                transaction.Total -= transactionDetail.Product.GetPriceWithTax();
                _context.TransactionDetail.Remove(transactionDetail);
                _context.Transaction.Update(transaction);

                await _context.SaveChangesAsync();


                int cart = Convert.ToInt32(acessor.HttpContext.Session.GetString("cartCount"));
                int cartCountInt = cart - 1;
                if (cartCountInt == 0)
                {
                    string cartCount = "!";
                    this.HttpContext.Session.SetString("cartCount", cartCount);
                }
                else
                {
                    string cartCount = Convert.ToString(cartCountInt);
                    this.HttpContext.Session.SetString("cartCount", cartCount);
                }
                _notyf.Custom("Item removed from the cart!", 10, "#907159", "fa fa-shopping-cart");
                var routeValues = new RouteValueDictionary { { "id", transactionId } };
                return RedirectToAction("DetailsSingular", "Transaction", routeValues);
            }
            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> AddAnotherProduct(int id)
        {
            if (acessor.HttpContext.Session.GetString("type") == "singular")
            {
                TransactionDetail td = new TransactionDetail();
                td.ProductId = id;
                td.Quantity = 1;
                int tId = Convert.ToInt32(acessor.HttpContext.Session.GetString("transactionId"));
                td.TransactionId = tId;
                Transaction t = _context.Transaction.Where(t => t.TransactionId == tId).FirstOrDefault();

                Product p = await _context.Product.FirstOrDefaultAsync(m => m.ProductId == td.ProductId);

                td.UnitPrice = p.UnitPrice;
                t.Total += p.GetPriceWithTax();
                _context.TransactionDetail.Add(td);
                await _context.SaveChangesAsync();
                _context.Transaction.Update(t);
                await _context.SaveChangesAsync();




                if (acessor.HttpContext.Session.GetString("cartCount") == "!" || acessor.HttpContext.Session.GetString("cartCount") == "")
                {
                    this.HttpContext.Session.SetString("cartCount", "0");
                }
                int cart = Convert.ToInt32(acessor.HttpContext.Session.GetString("cartCount"));
                int cartCountInt = cart + 1;
                string cartCount = Convert.ToString(cartCountInt);
                this.HttpContext.Session.SetString("cartCount", cartCount);
                string transactionId = acessor.HttpContext.Session.GetString("transactionId");
                _notyf.Custom("Item added to the cart!", 10, "#907159", "fa fa-shopping-cart");
                var routeValues = new RouteValueDictionary { { "id", transactionId } };
                return RedirectToAction("DetailsSingular", "Transaction", routeValues);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ChangeState(int id)
        {
            if (acessor.HttpContext.Session.GetString("type") == "singular")
            {
                var transaction = await _context.Transaction.Where(t => t.State == "Open").Include(t => t.Singular).Include(t => t.TransactionDetails).ThenInclude(t => t.Product).FirstOrDefaultAsync(m => m.TransactionId == id);

                transaction.State = "Awaiting treatment";
                transaction.ChangedBy = transaction.Singular.Username;
                _context.Transaction.Update(transaction);
                acessor.HttpContext.Session.SetString("cartCount", "");
                _notyf.Custom("Order registered!", 10, "#907159", "fa fa-shopping-cart");
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> ConfirmReception(int id)
        {
            if (acessor.HttpContext.Session.GetString("type") == "singular")
            {
                var transaction = await _context.Transaction.Where(t => t.State == "Awaiting treatment").Include(t => t.Singular).Include(t => t.TransactionDetails).ThenInclude(t => t.Product).FirstOrDefaultAsync(m => m.TransactionId == id);

                transaction.State = "Delivered";
                transaction.ChangedBy = transaction.Singular.Username;
                _context.Transaction.Update(transaction);
                acessor.HttpContext.Session.SetString("cartCount", "");
                _notyf.Custom("Reception Confirmed!", 10, "#907159", "fa fa-smile-o");
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        //This actions to manually edit the Transaction is only available for the user "admin"
        #region Edit
        // GET: Transaction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (acessor.HttpContext.Session.GetString("user") == "admin")
            {
                if (id == null)
                {
                    return NotFound();
                }

                var transaction = await _context.Transaction.Where(t=>t.TransactionId== id).Include(t=>t.TransactionDetails).FirstOrDefaultAsync();
                if (transaction == null)
                {
                    return NotFound();
                }

                return View(transaction);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Transaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,SingularId,CompanyId,DateCreated,State,ChangedBy,Total")] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.TransactionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(transaction);
        }
        #endregion

        //This action is only acessible for the Singular user associated with the transaction or by "admin
        #region Delete
        // GET: Transaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {


            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Singular)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }
            if (acessor.HttpContext.Session.GetString("user") == "admin" || Convert.ToInt64(acessor.HttpContext.Session.GetString("userId")) == transaction.SingularId)
                return View(transaction);
            return RedirectToAction("Index", "Home");
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            _context.Remove(transaction);
            await _context.SaveChangesAsync();
            this.HttpContext.Session.SetString("cartCount", "");
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region TransactionExists
        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.TransactionId == id);
        }
        #endregion

    }
}
