using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ThinkSmartSchools.Models;
using ThinkSmartSchools.Models.Common;

namespace ThinkSmartSchools.Areas.StaffUsers.Controllers
{
    [Area("StaffUsers")]
    public class ConfigurationsController : Controller
    {
        private readonly ForSchoolsDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ConfigurationsController(ForSchoolsDBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ChoseResultType()
        {
            ResultTypeGradeViewModel rgViewModel = new ResultTypeGradeViewModel(_context);
            rgViewModel.ResultTypes = rgViewModel.ResultTypes.Where(x => x.SchoolId == 1);
            rgViewModel.Grades = rgViewModel.Grades.Where(x => x.SchoolId == 1);
            return View(rgViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ChoseResultTypeAsync(List<int> bravo, List<string> resultItemNames)
        {
            for (int i = 0; i < bravo.Count; i++)
            {
                ResultTypeItem item = new ResultTypeItem
                {
                    Name = resultItemNames.ElementAt(i),
                    ResultTypeId = bravo.ElementAt(i)
                };
                _context.ResultTypeItem.Add(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}