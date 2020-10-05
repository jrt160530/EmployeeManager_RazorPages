using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager_RazorPages.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EmployeeManager_RazorPages.Pages.EmployeeManager
{
    [Authorize(Roles = "Manager")]
    public class InsertModel : PageModel
    {
        private readonly AppDbContext db = null;
        public string Message { get; set; }

        [BindProperty]
        public Employee Employee { get; set; }
        public List<SelectListItem> Countries { get; set; }

        public InsertModel(AppDbContext db)
        {
            this.db = db;
        }

        public void FillCountries()
        {
            List<SelectListItem> countries =
                (from c in db.Countries
                 select new SelectListItem()
                 { Text = c.Name,
                     Value = c.Name }).ToList();
            this.Countries = countries;
        }
        

        public void OnGet()
        {
            FillCountries();
        }

        public void OnPost()
        {
            FillCountries();

            if(ModelState.IsValid)
            {
                try
                {
                    db.Add(Employee);
                    db.SaveChanges();
                    Message = "Employee inserted successfully";
                }
                catch (DbUpdateConcurrencyException ex1)
                {
                    Message = ex1.Message;
                    if(ex1.InnerException!=null)
                    {
                        Message += " : " + ex1.InnerException.Message;
                    }
                }
                
            }
        }
    }
}
