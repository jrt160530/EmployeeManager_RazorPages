using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager_RazorPages.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManager_RazorPages.Pages.EmployeeManager
{
    [Authorize(Roles = "Manager")]
    public class IndexModel : PageModel
    {
        private readonly AppDbContext db = null;

        public List<Employee> Employees { get; set; }
        
        public IndexModel(AppDbContext db)
        {
            this.db = db;
        }
        
        
        public void OnGet()
        {
            this.Employees = 
                (from e in db.Employees 
                 orderby e.EmployeeID 
                 select e).ToList();
        }
    }
}
