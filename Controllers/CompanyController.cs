using CommercialApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CommercialApp.Controllers
{
    public class CompanyController : Controller
    {

        #region Constructor
        private readonly CAppDbContext _context;
        private IHttpContextAccessor acessor { get; set; }

        public CompanyController(CAppDbContext context, IHttpContextAccessor a)
        {
            _context = context;
            acessor = a;
        }
        #endregion

        //Acessing a list of all companies registered is only available for the user "admin"
        #region Index
        // GET: Company
        public async Task<IActionResult> Index()
        {

            if (acessor.HttpContext.Session.GetString("user") == "admin")
            {
                var cAppDbContext = await _context.Company.ToListAsync();
                return View(cAppDbContext);
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        //Acessing details of Company information is only available for the user "admin"
        #region Details
        // GET: Company/Details/5
        public async Task<IActionResult> Details(int id)
        {

            if (acessor.HttpContext.Session.GetString("user") == "admin")
            {

                var company = await _context.Company
                .FirstOrDefaultAsync(m => m.PeopleId == id);
                if (company == null)
                {
                    return NotFound();
                }

                return View(company);
            }
            return RedirectToAction("Index", "Home");
        }
        #endregion

        //Creating new Company registration is only available for the user "admin"
        #region Create
        // GET: Company/Create
        public IActionResult Create()
        {
            if (acessor.HttpContext.Session.GetString("user") == "admin")
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        

        
        // POST: Company/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company)
        {
            if (ModelState.IsValid)
            {

                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }
        #endregion

        //Editing Company information is only accessible for the user "admin" or by the Company itself
        #region Edit
        // GET: Company/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var company = await _context.Company.FindAsync(id);
            if (acessor.HttpContext.Session.GetString("user") == "admin" || this.HttpContext.Session.GetString("user") == company.Name)
            {
                if (company == null)
                {
                    return NotFound();
                }
                return View(company);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompanyId,NIPC,PeopleId,Name,Email,Username,Password,PhoneNumber,Address,PostalCode,City")] Company company)
        {
            if (id != company.PeopleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.PeopleId))
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
            return View(company);
        }
        #endregion

        //Deleting Companies is only available for the user "admin"
        #region Delete
        // GET: Company/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (acessor.HttpContext.Session.GetString("user") == "admin")
            {
                var company = await _context.Company
                .FirstOrDefaultAsync(m => m.PeopleId == id);
                if (company == null)
                {
                    return NotFound();
                }

                return View(company);
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _context.Company.FindAsync(id);
            _context.Remove(company);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region CompanyExists
        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.PeopleId == id);
        }
        #endregion

    }
}
