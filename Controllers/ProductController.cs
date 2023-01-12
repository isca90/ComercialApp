using CommercialApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CommercialApp.Controllers
{
    public class ProductController : Controller
    {

        #region Constructor
        private readonly CAppDbContext _context;
        private IHttpContextAccessor acessor { get; set; }
        public ProductController(CAppDbContext context, IHttpContextAccessor a)
        {
            _context = context;
            acessor = a;
        }
        #endregion

        //One action to return all products, wich is acessible to any Singular user
        //and another method to return only products of a specific Company to be acessible to any Company user
        #region Index
        // GET: Product
        public async Task<IActionResult> Index()
        {            
            if (acessor.HttpContext.Session.GetString("type") != "company")
            {
                var cAppDbContext = await _context.Product.Include(t=>t.Company).ToListAsync();
                return View(cAppDbContext);
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> IndexByCompany()
        {
            if (acessor.HttpContext.Session.GetString("type") == "company")
            {
                var cAppDbContext = await _context.Product.Where(t => t.CompanyId == Convert.ToInt32(acessor.HttpContext.Session.GetString("userId"))).Include(t => t.Company).ToListAsync();
                return View(cAppDbContext);

            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Details
        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        #endregion

        //Creating new products is only acessible for Companies or the user "admin"
        #region Create
        // GET: Product/Create
        public IActionResult Create()
        {
            if (acessor.HttpContext.Session.GetString("type") == "company" || acessor.HttpContext.Session.GetString("user") == "admin")
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile FormFile)
        {
            Stream stream = FormFile.OpenReadStream();

            var bytes = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);
            stream.Dispose();
            product.Image = bytes;
            product.CompanyId = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            Company company = await _context.Company.FirstOrDefaultAsync(m => m.PeopleId == Convert.ToInt32(this.HttpContext.Session.GetString("userId")));


            _context.Add(product);
            company.Products.Append(product);
            //if (ModelState.IsValid)
            //{

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
            //}
            //return View(product);
        }
        #endregion

        //Editing a product can only be done by its supplier of the user "admin"
        #region Edit
        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (acessor.HttpContext.Session.GetString("userId") == Convert.ToString(product.CompanyId) || acessor.HttpContext.Session.GetString("user") == "admin")
            {
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product, IFormFile FormFile)
        {
            Stream stream = FormFile.OpenReadStream();

            var bytes = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, bytes.Length);
            stream.Dispose();
            product.CompanyId = Convert.ToInt32(this.HttpContext.Session.GetString("userId"));
            product.Image = bytes;


            //if (ModelState.IsValid)
            //{
            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            //}
            return View(product);
        }
        #endregion

        //Deleting a product can only be done by its supplier of the user "admin"
        #region Delete
        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {


            var product = await _context.Product.FirstOrDefaultAsync(m => m.ProductId == id);
            if (acessor.HttpContext.Session.GetString("userId") == Convert.ToString(product.CompanyId) || acessor.HttpContext.Session.GetString("user") == "admin")
            {

                if (product == null)
                {
                    return NotFound();
                }

                return View(product);

            }
            return RedirectToAction("Index", "Home");

        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region ProductExists
        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
        #endregion

    }
}
