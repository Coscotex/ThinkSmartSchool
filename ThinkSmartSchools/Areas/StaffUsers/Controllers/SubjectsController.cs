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
    public class SubjectsController : Controller
    {
        private readonly ForSchoolsDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SubjectsController(ForSchoolsDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: StaffUsers/Subjects
        public async Task<IActionResult> Index()
        {
            var forSchoolsDBContext = await GetAllByInstitutionAsync();
            return View(forSchoolsDBContext);
        }

        // GET: StaffUsers/Subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var All = await GetAllByInstitutionAsync();
            if (id == null || !All.Select(x => x.Id).Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .SingleOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: StaffUsers/Subjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffUsers/Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Configurations");
            }
            return View(subject);
        }

        // GET: StaffUsers/Subjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var All = await GetAllByInstitutionAsync();
            if (id == null || !All.Select(x => x.Id).Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var subject = await _context.Subject.SingleOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: StaffUsers/Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Subject subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.Id))
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
            return View(subject);
        }

        // GET: StaffUsers/Subjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var All = await GetAllByInstitutionAsync();
            if (id == null || !All.Select(x => x.Id).Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .SingleOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: StaffUsers/Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var All = await GetAllByInstitutionAsync();
            if (!All.Select(x => x.Id).Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }
            var subject = await _context.Subject.SingleOrDefaultAsync(m => m.Id == id);
            _context.Subject.Remove(subject);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Configurations");
        }

        private bool SubjectExists(int id)
        {
            return _context.Subject.Any(e => e.Id == id);
        }

        private async Task<Staff> StaffUserAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            Staff Staff = await _context.Staff.SingleOrDefaultAsync(x => x.Guid == user.Id);
            return Staff;
        }

        private async Task<List<Subject>> GetAllByInstitutionAsync()
        {
            // Get current user
            Staff Staff = await StaffUserAsync();
            var All = _context.Subject.Where(g => g.InstitutionId == Staff.InstitutionId);
            return All.ToList();
        }
    }
}
