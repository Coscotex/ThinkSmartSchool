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
    public class TermsController : Controller
    {
        private readonly ForSchoolsDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TermsController(ForSchoolsDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: StaffUsers/Terms
        public async Task<IActionResult> Index()
        {
            Staff Staff = await StaffUserAsync();
            var forSchoolsDBContext = _context.Term.Where(t => t.InstitutionId == Staff.InstitutionId);
            return View(await forSchoolsDBContext.ToListAsync());
        }

        // GET: StaffUsers/Terms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Staff Staff = await StaffUserAsync();
            List<int> IdList = (_context.Term.Where(f => f.InstitutionId == Staff.InstitutionId).Select(f => f.Id)).ToList();
            if (id == null || !IdList.Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var term = await _context.Term
                .SingleOrDefaultAsync(m => m.Id == id);
            if (term == null)
            {
                return NotFound();
            }
            return View(term);
        }

        // GET: StaffUsers/Terms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffUsers/Terms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status,DateStart,DateEnd")] Term term)
        {
            Staff Staff = await StaffUserAsync();
            term.InstitutionId = Staff.InstitutionId;
            if (ModelState.IsValid)
            {
                if (term.Status)
                {
                    var entries = _context.Term.Where(x => x.Status == true);
                    if (entries != null)
                    {
                        foreach (var entry in entries) { entry.Status = false; _context.Update(entry); }
                    }
                }
                _context.Add(term);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Configurations"); ;
            }
            return View(term);
        }

        // GET: StaffUsers/Terms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Staff Staff = await StaffUserAsync();
            List<int> IdList = (_context.Term.Where(f => f.InstitutionId == Staff.InstitutionId).Select(f => f.Id)).ToList();
            if (id == null || !IdList.Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var term = await _context.Term.SingleOrDefaultAsync(m => m.Id == id);
            if (term == null)
            {
                return NotFound();
            }
            return View(term);
        }

        // POST: StaffUsers/Terms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status,DateStart,DateEnd")] Term term)
        {
            if (id != term.Id)
            {
                return NotFound();
            }

            Staff Staff = await StaffUserAsync();
            term.InstitutionId = Staff.InstitutionId;
            if (ModelState.IsValid)
            {
                try
                {
                    if (term.Status)
                    {
                        var entries = _context.Term.Where(x => x.Status == true);
                        if (entries != null)
                        {
                            foreach (var entry in entries) { entry.Status = false; _context.Update(entry); }
                        }
                    }
                    _context.Update(term);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TermExists(term.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Configurations"); ;
            }
            return View(term);
        }

        // GET: StaffUsers/Terms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Staff Staff = await StaffUserAsync();
            List<int> IdList = (_context.Term.Where(f => f.InstitutionId == Staff.InstitutionId).Select(f => f.Id)).ToList();
            if (id == null || !IdList.Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var term = await _context.Term
                .SingleOrDefaultAsync(m => m.Id == id);
            if (term == null)
            {
                return NotFound();
            }

            return View(term);
        }

        // POST: StaffUsers/Terms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Staff Staff = await StaffUserAsync();
            List<int> IdList = (_context.Term.Where(f => f.InstitutionId == Staff.InstitutionId).Select(f => f.Id)).ToList();
            if (!IdList.Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }
            var term = await _context.Term.SingleOrDefaultAsync(m => m.Id == id);
            _context.Term.Remove(term);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Configurations"); ;
        }

        private bool TermExists(int id)
        {
            return _context.Term.Any(e => e.Id == id);
        }

        private async Task<Staff> StaffUserAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            Staff Staff = await _context.Staff.SingleOrDefaultAsync(x => x.Guid == user.Id);
            return Staff;
        }
    }
}
