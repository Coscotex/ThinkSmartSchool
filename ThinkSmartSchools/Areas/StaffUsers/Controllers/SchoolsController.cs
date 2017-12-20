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
    public class SchoolsController : Controller
    {
        private readonly ForSchoolsDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SchoolsController(ForSchoolsDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: StaffUsers/Schools
        public async Task<IActionResult> Index()
        {
            Staff Staff = await StaffUserAsync();
            var forSchoolsDBContext = _context.School.Where(g => g.InstitutionId == Staff.InstitutionId);
            return View(await forSchoolsDBContext.ToListAsync());
        }

        // GET: StaffUsers/Schools/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Staff Staff = await StaffUserAsync();
            List<int> IdList = (_context.School.Where(f => f.InstitutionId == Staff.InstitutionId).Select(f => f.Id)).ToList();
            if (id == null || !IdList.Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var school = await _context.School
                .SingleOrDefaultAsync(m => m.Id == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // GET: StaffUsers/Schools/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffUsers/Schools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Logo")] School school)
        {
            Staff Staff = await StaffUserAsync();
            school.InstitutionId = Staff.InstitutionId;
            if (ModelState.IsValid)
            {
                _context.Add(school);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Configurations");
            }
            return View(school);
        }

        // GET: StaffUsers/Schools/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Staff Staff = await StaffUserAsync();
            List<int> IdList = (_context.School.Where(f => f.InstitutionId == Staff.InstitutionId).Select(f => f.Id)).ToList();
            if (id == null || !IdList.Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var school = await _context.School.SingleOrDefaultAsync(m => m.Id == id);
            if (school == null)
            {
                return NotFound();
            }
            return View(school);
        }

        // POST: StaffUsers/Schools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Logo")] School school)
        {
            if (id != school.Id)
            {
                return NotFound();
            }
            Staff Staff = await StaffUserAsync();
            school.InstitutionId = Staff.InstitutionId;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(school);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolExists(school.Id))
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
            return View(school);
        }

        // GET: StaffUsers/Schools/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Staff Staff = await StaffUserAsync();
            List<int> IdList = (_context.School.Where(f => f.InstitutionId == Staff.InstitutionId).Select(f => f.Id)).ToList();
            if (id == null || !IdList.Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var school = await _context.School
                .SingleOrDefaultAsync(m => m.Id == id);
            if (school == null)
            {
                return NotFound();
            }

            return View(school);
        }

        // POST: StaffUsers/Schools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Staff Staff = await StaffUserAsync();
            List<int> IdList = (_context.School.Where(f => f.InstitutionId == Staff.InstitutionId).Select(f => f.Id)).ToList();
            if (!IdList.Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }
            var school = await _context.School.SingleOrDefaultAsync(m => m.Id == id);
            _context.School.Remove(school);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Configurations");
        }

        private bool SchoolExists(int id)
        {
            return _context.School.Any(e => e.Id == id);
        }

        private async Task<Staff> StaffUserAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            Staff Staff = await _context.Staff.SingleOrDefaultAsync(x => x.Guid == user.Id);
            return Staff;
        }

    }
}
