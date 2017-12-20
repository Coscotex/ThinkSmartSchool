using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThinkSmartSchools.Models;
using Microsoft.AspNetCore.Identity;
using Sakura.AspNetCore;

namespace ThinkSmartSchools.Areas.StaffUsers.Controllers
{
    [Area("StaffUsers")]
    public class StudentsController : Controller
    {
        private readonly ForSchoolsDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudentsController(ForSchoolsDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: StaffUsers/Students
        public async Task<IActionResult> Index(string search, string searchBy, int? page, string sortBy, string noPerPage)
        {
            Staff Staff = await StaffUserAsync();
            var forSchoolsDBContext = _context.Student.Where(s => s.InstitutionId == Staff.InstitutionId).Include(s => s.Class).Include(s => s.Institution).Include(s => s.Parent).Include(s => s.School);
            ViewData["SortFirstNameParameter"] = string.IsNullOrEmpty(sortBy) ? "FirstName desc" : "";
            ViewData["SortLastNameParameter"] = sortBy == "LastName" ? "LastName desc" : "LastName";
            ViewData["SortClassParameter"] = sortBy == "Class" ? "Class desc" : "Class";

            var students = forSchoolsDBContext.AsQueryable();

            if (searchBy == "Parent Name")
            {
                students = students.Where(e => e.Parent.LastName.Contains(search) || e.Parent.FirstName.Contains(search) || search == null);
            }
            else
            {
                students = students.Where(e => e.LastName.Contains(search) || e.FirstName.Contains(search) || search == null);
            }

            switch (sortBy)
            {
                case "FirstName desc":
                    students = students.OrderByDescending(x => x.LastName);
                    break;
                case "Class desc":
                    students = students.OrderByDescending(x => x.Class.Name);
                    break;
                case "Class":
                    students = students.OrderBy(x => x.Class.Name);
                    break;
                case "LastName":
                    students = students.OrderBy(x => x.LastName);
                    break;
                case "LastName desc":
                    students = students.OrderByDescending(x => x.LastName);
                    break;
                default:
                    students = students.OrderBy(x => x.LastName);
                    break;
            }
            int? pageNo = Convert.ToInt32(noPerPage);
            return PartialView(await students.ToPagedListAsync(page ?? 1, pageNo < 1 ? 3 : Convert.ToInt32(pageNo)));
        }

        [HttpGet]
        public async Task<JsonResult> GetStudentsAsync(string term)
        {
            Staff Staff = await StaffUserAsync();
            List<string> students = _context.Student.Where(q => q.InstitutionId == Staff.InstitutionId).Where(x => x.FirstName.StartsWith(term) || x.LastName.StartsWith(term))
                                        .Select(y => y.FirstName).ToList();
            return Json(students);
        }

        // GET: StaffUsers/Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Staff Staff = await StaffUserAsync();
            List<int> IdList = (_context.Student.Where(f => f.InstitutionId == Staff.InstitutionId).Select(f => f.Id)).ToList();
            if (id == null || !IdList.Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Class)
                .Include(s => s.Institution)
                .Include(s => s.Parent)
                .Include(s => s.School)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: StaffUsers/Students/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name");
            ViewData["InstitutionId"] = new SelectList(_context.Institution, "Id", "Name");
            ViewData["ParentId"] = new SelectList(_context.Parent, "Id", "Address");
            ViewData["SchoolId"] = new SelectList(_context.School, "Id", "Logo");
            return View();
        }

        // POST: StaffUsers/Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,OtherNames,ClassId,Guid,Sex,Address,ParentId,Dob,SchoolId,Status,InstitutionId")] Student student)
        {
            student.Guid = "None";
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction("Register", "Account", new { area = "", id = student.Id, returnUrl = Url.Action("Student", "Index", new { area = "StaffUsers" }) });
            }
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", student.ClassId);
            ViewData["InstitutionId"] = new SelectList(_context.Institution, "Id", "Name", student.InstitutionId);
            ViewData["ParentId"] = new SelectList(_context.Parent, "Id", "Address", student.ParentId);
            ViewData["SchoolId"] = new SelectList(_context.School, "Id", "Logo", student.SchoolId);
            return View(student);
        }

        // GET: StaffUsers/Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            Staff Staff = await StaffUserAsync();
            List<int> IdList = (_context.Student.Where(f => f.InstitutionId == Staff.InstitutionId).Select(f => f.Id)).ToList();
            if (id == null || !IdList.Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var student = await _context.Student.SingleOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", student.ClassId);
            ViewData["InstitutionId"] = new SelectList(_context.Institution, "Id", "Name", student.InstitutionId);
            ViewData["ParentId"] = new SelectList(_context.Parent, "Id", "Address", student.ParentId);
            ViewData["SchoolId"] = new SelectList(_context.School, "Id", "Logo", student.SchoolId);
            return View(student);
        }

        // POST: StaffUsers/Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,OtherNames,ClassId,Guid,Sex,Address,ParentId,Dob,SchoolId,Status,InstitutionId")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.Id))
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
            ViewData["ClassId"] = new SelectList(_context.Class, "Id", "Name", student.ClassId);
            ViewData["InstitutionId"] = new SelectList(_context.Institution, "Id", "Name", student.InstitutionId);
            ViewData["ParentId"] = new SelectList(_context.Parent, "Id", "Address", student.ParentId);
            ViewData["SchoolId"] = new SelectList(_context.School, "Id", "Logo", student.SchoolId);
            return View(student);
        }

        // GET: StaffUsers/Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            Staff Staff = await StaffUserAsync();
            List<int> IdList = (_context.Student.Where(f => f.InstitutionId == Staff.InstitutionId).Select(f => f.Id)).ToList();
            if (id == null || !IdList.Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }

            var student = await _context.Student
                .Include(s => s.Class)
                .Include(s => s.Institution)
                .Include(s => s.Parent)
                .Include(s => s.School)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: StaffUsers/Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Staff Staff = await StaffUserAsync();
            List<int> IdList = (_context.Student.Where(f => f.InstitutionId == Staff.InstitutionId).Select(f => f.Id)).ToList();
            if (!IdList.Contains(Convert.ToInt32(id)))
            {
                return NotFound();
            }
            var student = await _context.Student.SingleOrDefaultAsync(m => m.Id == id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.Id == id);
        }

        private async Task<Staff> StaffUserAsync()
        {
            ApplicationUser user = await _userManager.GetUserAsync(User);
            Staff Staff = await _context.Staff.SingleOrDefaultAsync(x => x.Guid == user.Id);
            return Staff;
        }
    }
}
