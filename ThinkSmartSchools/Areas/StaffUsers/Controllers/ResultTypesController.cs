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
    public class ResultTypesController : Controller
    {
        private readonly ForSchoolsDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ResultTypesController(ForSchoolsDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: StaffUsers/ResultTypes
        public async Task<IActionResult> Index()
        {
            var forSchoolsDBContext = await GetAllByInstitutionAsync();
            return View(await forSchoolsDBContext.ToListAsync());
        }

        // GET: StaffUsers/ResultTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var All = await GetAllByInstitutionAsync();
            if (id == null || !All.Select(x => x.Id).Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var resultType = await _context.ResultType
                .Include(r => r.AssessmentType)
                .Include(r => r.School)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (resultType == null)
            {
                return NotFound();
            }

            return View(resultType);
        }

        // GET: StaffUsers/ResultTypes/Create
        public IActionResult Create()
        {
            ViewData["AssessmentTypeId"] = new SelectList(_context.AssessmentType, "Id", "Name");
            ViewData["SchoolId"] = new SelectList(_context.School, "Id", "Logo");
            return View();
        }

        // POST: StaffUsers/ResultTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssessmentTypeId,SchoolId,MaxScore,NoOfItems")] ResultType resultType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Configurations");
            }
            ViewData["AssessmentTypeId"] = new SelectList(_context.AssessmentType, "Id", "Name", resultType.AssessmentTypeId);
            ViewData["SchoolId"] = new SelectList(_context.School, "Id", "Logo", resultType.SchoolId);
            return View(resultType);
        }

        // GET: StaffUsers/ResultTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var All = await GetAllByInstitutionAsync();
            if (id == null || !All.Select(x => x.Id).Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var resultType = await _context.ResultType.SingleOrDefaultAsync(m => m.Id == id);
            if (resultType == null)
            {
                return NotFound();
            }
            ViewData["AssessmentTypeId"] = new SelectList(_context.AssessmentType, "Id", "Name", resultType.AssessmentTypeId);
            ViewData["SchoolId"] = new SelectList(_context.School, "Id", "Logo", resultType.SchoolId);
            return View(resultType);
        }

        // POST: StaffUsers/ResultTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssessmentTypeId,SchoolId,MaxScore,NoOfItems")] ResultType resultType)
        {
            if (id != resultType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultTypeExists(resultType.Id))
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
            ViewData["AssessmentTypeId"] = new SelectList(_context.AssessmentType, "Id", "Name", resultType.AssessmentTypeId);
            ViewData["SchoolId"] = new SelectList(_context.School, "Id", "Logo", resultType.SchoolId);
            return View(resultType);
        }

        // GET: StaffUsers/ResultTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var All = await GetAllByInstitutionAsync();
            if (id == null || !All.Select(x => x.Id).Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var resultType = await _context.ResultType
                .Include(r => r.AssessmentType)
                .Include(r => r.School)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (resultType == null)
            {
                return NotFound();
            }

            return View(resultType);
        }

        // POST: StaffUsers/ResultTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var All = await GetAllByInstitutionAsync();
            if (!All.Select(x => x.Id).Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }
            var resultType = await _context.ResultType.SingleOrDefaultAsync(m => m.Id == id);
            _context.ResultType.Remove(resultType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Configurations");
        }

        private bool ResultTypeExists(int id)
        {
            return _context.ResultType.Any(e => e.Id == id);
        }

        private async Task<Staff> StaffUserAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            Staff Staff = await _context.Staff.SingleOrDefaultAsync(x => x.Guid == user.Id);
            return Staff;
        }

        private async Task<IQueryable<ResultType>> GetAllByInstitutionAsync()
        {
            List<ResultType> All = new List<ResultType>();
            // Get current user
            Staff Staff = await StaffUserAsync();
            //Get all Schools in the User's Institution and then combine all the list of subjects from the individual schools into one list
            await _context.School.Where(g => g.InstitutionId == Staff.InstitutionId).ForEachAsync(g => All.AddRange(g.ResultType));
            return All.AsQueryable().Include(d => d.School);
        }
    }
}
