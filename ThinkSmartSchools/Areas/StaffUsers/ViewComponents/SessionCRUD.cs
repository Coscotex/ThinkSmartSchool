using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinkSmartSchools.Models;

namespace ThinkSmartSchools.Areas.StaffUsers.ViewComponents
{
    public class SessionCRUD : ViewComponent
    {
        private readonly ForSchoolsDBContext _context;

        public SessionCRUD(ForSchoolsDBContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Session.ToListAsync());
        }
    }
}
