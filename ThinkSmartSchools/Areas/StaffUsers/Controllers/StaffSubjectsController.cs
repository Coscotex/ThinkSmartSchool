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
    public class StaffSubjectsController : Controller
    {
        private readonly ForSchoolsDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public StaffSubjectsController(ForSchoolsDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: StaffUsers/StaffSubjects
        public async Task<IActionResult> Index()
        {
            var forSchoolsDBContext = await GetAllByInstitutionAsync();
            return View(forSchoolsDBContext);
        }

        // GET: StaffUsers/StaffSubjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var All = await GetAllByInstitutionAsync();
            if (id == null || !All.Select(x => x.Id).Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var staffSubject = await _context.StaffSubject
                .Include(s => s.Class)
                .Include(s => s.Staff)
                .Include(s => s.Subject)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (staffSubject == null)
            {
                return NotFound();
            }

            return View(staffSubject);
        }

        // GET: StaffUsers/StaffSubjects/Create
        public async Task<IActionResult> CreateAsync()
        {
            Staff Staff = await StaffUserAsync();
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name");
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Address");
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name");
            return View();
        }

        // POST: StaffUsers/StaffSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StaffId,SubjectId,ClassId")] StaffSubject staffSubject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffSubject);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Configurations");
            }
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", staffSubject.ClassId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Address", staffSubject.StaffId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name", staffSubject.SubjectId);
            return View(staffSubject);
        }

        // GET: StaffUsers/StaffSubjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var All = await GetAllByInstitutionAsync();
            if (id == null || !All.Select(x => x.Id).Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var staffSubject = await _context.StaffSubject.SingleOrDefaultAsync(m => m.Id == id);
            if (staffSubject == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", staffSubject.ClassId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Address", staffSubject.StaffId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name", staffSubject.SubjectId);
            return View(staffSubject);
        }

        // POST: StaffUsers/StaffSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StaffId,SubjectId,ClassId")] StaffSubject staffSubject)
        {
            if (id != staffSubject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffSubject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffSubjectExists(staffSubject.Id))
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
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", staffSubject.ClassId);
            ViewData["StaffId"] = new SelectList(_context.Staff, "Id", "Address", staffSubject.StaffId);
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name", staffSubject.SubjectId);
            return View(staffSubject);
        }

        // GET: StaffUsers/StaffSubjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var All = await GetAllByInstitutionAsync();
            if (id == null || !All.Select(x => x.Id).Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var staffSubject = await _context.StaffSubject
                .Include(s => s.Class)
                .Include(s => s.Staff)
                .Include(s => s.Subject)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (staffSubject == null)
            {
                return NotFound();
            }

            return View(staffSubject);
        }

        // POST: StaffUsers/StaffSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var All = await GetAllByInstitutionAsync();
            if (!All.Select(x => x.Id).Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }
            var staffSubject = await _context.StaffSubject.SingleOrDefaultAsync(m => m.Id == id);
            _context.StaffSubject.Remove(staffSubject);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Configurations");
        }

        private bool StaffSubjectExists(int id)
        {
            return _context.StaffSubject.Any(e => e.Id == id);
        }

        private async Task<Staff> StaffUserAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            Staff Staff = await _context.Staff.SingleOrDefaultAsync(x => x.Guid == user.Id);
            return Staff;
        }

        private async Task<List<StaffSubject>> GetAllByInstitutionAsync()
        {
            // Get current user
            Staff Staff = await StaffUserAsync();
            var StaffSubject = _context.StaffSubject.Where(g => g.InstitutionId == Staff.InstitutionId).Include(g => g.Class).Include(g => g.Staff).Include(g => g.Subject);
            return StaffSubject.ToList();
        }
    }
}
