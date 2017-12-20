using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThinkSmartSchools.Models;
using Microsoft.AspNetCore.Identity;

namespace ThinkSmartSchools.Areas.StaffUsers.Controllers
{
    [Area("StaffUsers")]
    public class ClassesController : Controller
    {
        private readonly ForSchoolsDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ClassesController(ForSchoolsDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: StaffUsers/Classes
        public async Task<IActionResult> Index()
        {
            Staff Staff = await StaffUserAsync();
            var forSchoolsDBContext = _context.Class.Where(g => g.InstitutionId == Staff.InstitutionId).Include(g => g.School).Include(g => g.Staff);
            return View(await forSchoolsDBContext.ToListAsync());
        }

        // GET: StaffUsers/Classes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Staff Staff = await StaffUserAsync();
            List<int> IdList = (_context.Class.Where(f => f.InstitutionId == Staff.InstitutionId).Select(f => f.Id)).ToList();
            if (id == null || !IdList.Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var @class = await _context.Class
                .Include(g => g.School)
                .Include(g => g.Staff)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // GET: StaffUsers/Classes/Create
        public IActionResult Create()
        {
            ViewData["SchoolId"] = new SelectList(_context.School, "Id", "Logo");
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Address");
            return View();
        }

        // POST: StaffUsers/Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SchoolId,StaffId")] Class @class)
        {
            Staff Staff = await StaffUserAsync();
            @class.InstitutionId = Staff.InstitutionId;
            if (ModelState.IsValid)
            {
                _context.Add(@class);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Configurations");
            }
            ViewData["SchoolId"] = new SelectList(_context.School, "Id", "Logo", @class.SchoolId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Address", @class.StaffId);
            return View(@class);
        }

        // GET: StaffUsers/Classes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Staff Staff = await StaffUserAsync();
            List<int> IdList = (_context.Class.Where(f => f.InstitutionId == Staff.InstitutionId).Select(f => f.Id)).ToList();
            if (id == null || !IdList.Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var @class = await _context.Class.SingleOrDefaultAsync(m => m.Id == id);
            if (@class == null)
            {
                return NotFound();
            }
            ViewData["SchoolId"] = new SelectList(_context.School, "Id", "Logo", @class.SchoolId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Address", @class.StaffId);
            return View(@class);
        }

        // POST: StaffUsers/Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SchoolId,StaffId")] Class @class)
        {
            if (id != @class.Id)
            {
                return NotFound();
            }

            Staff Staff = await StaffUserAsync();
            @class.InstitutionId = Staff.InstitutionId;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(@class.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Configurations");
            }
            ViewData["SchoolId"] = new SelectList(_context.School, "Id", "Logo", @class.SchoolId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Address", @class.StaffId);
            return View(@class);
        }

        // GET: StaffUsers/Classes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Staff Staff = await StaffUserAsync();
            List<int> IdList = (_context.Class.Where(f => f.InstitutionId == Staff.InstitutionId).Select(f => f.Id)).ToList();
            if (id == null || !IdList.Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var @class = await _context.Class
                .Include(g => g.School)
                .Include(g => g.Staff)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // POST: StaffUsers/Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Staff Staff = await StaffUserAsync();
            List<int> IdList = (_context.Class.Where(f => f.InstitutionId == Staff.InstitutionId).Select(f => f.Id)).ToList();
            if (!IdList.Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }
            var @class = await _context.Class.SingleOrDefaultAsync(m => m.Id == id);
            _context.Class.Remove(@class);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Configurations");
        }

        private bool ClassExists(int id)
        {
            return _context.Class.Any(e => e.Id == id);
        }

        private async Task<Staff> StaffUserAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            Staff Staff = await _context.Staff.SingleOrDefaultAsync(x => x.Guid == user.Id);
            return Staff;
        }
    }
}
