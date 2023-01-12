using CommercialApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CommercialApp.Controllers
{
    public class SingularController : Controller
    {

        #region Contructor
        private readonly CAppDbContext _context;
        private IHttpContextAccessor acessor { get; set; }
        public SingularController(CAppDbContext context, IHttpContextAccessor a)
        {
            _context = context;
            acessor = a;
        }
        #endregion

        //Acessing the list of all Singular users is only acessible for the user "admin"
        #region Index
        // GET: Singular
        public async Task<IActionResult> Index()
        {
            if (acessor.HttpContext.Session.GetString("user") == "admin")
            {
                var cAppDbContext = await _context.Singular.ToListAsync();
                return View(cAppDbContext);
            }
            return RedirectToAction("Index", "Home");

        }
        #endregion

        //Acessing the detailed information of any Singular user is only available for the user "admin"
        #region Details
        // GET: Singular/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (acessor.HttpContext.Session.GetString("user") == "admin")
            {

                var singular = await _context.Singular
                .FirstOrDefaultAsync(m => m.PeopleId == id);
                if (singular == null)
                {
                    return NotFound();
                }

                return View(singular);
            }
            return RedirectToAction("Index", "Home");

        }
        #endregion

        //Creating a new Singular user is only available is there is no user logged (Register) or for the user "admin"
        #region Create
        // GET: Singular/Create
        public IActionResult Create()
        {
            if (acessor.HttpContext.Session.GetString("user") == null || acessor.HttpContext.Session.GetString("user") == "admin")
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Singular/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Singular singular)
        {
            if (ModelState.IsValid)
            {

                _context.Add(singular);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(singular);
        }
        #endregion

        //Editing information of the user is only available for the user itself or for the user "admin"
        #region Edit
        // GET: Singular/Edit/5
        public async Task<IActionResult> Edit(int id)
        {


            var singular = await _context.Singular.FindAsync(id);
            if (singular == null)
            {
                return NotFound();
            }
            if (acessor.HttpContext.Session.GetString("user") == singular.Name || acessor.HttpContext.Session.GetString("user") == "admin")
            {
                return View(singular);
            }
            return RedirectToAction("Index", "Home");

        }

        // POST: Singular/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Singular singular)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(singular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SingularExists(singular.PeopleId))
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
            return View(singular);
        }
        #endregion

        //Only the user "admin" can delete users
        #region Delete
        // GET: Singular/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            if (acessor.HttpContext.Session.GetString("user") == "admin")
            {
                var singular = await _context.Singular
                .FirstOrDefaultAsync(m => m.PeopleId == id);
                if (singular == null)
                {
                    return NotFound();
                }

                return View(singular);
            }
            return RedirectToAction("Index", "Home");

        }

        // POST: Singular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var singular = await _context.Singular.FindAsync(id);
            _context.Remove(singular);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region SingularExists
        private bool SingularExists(int id)
        {
            return _context.Singular.Any(e => e.PeopleId == id);
        }
        #endregion

    }
}
