using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager_RazorPages.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager_RazorPages.Pages.EmployeeManager
{
    [Authorize(Roles = "Manager")]
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext db = null;

        [BindProperty]
        public Employee Employee { get; set; }

        public bool dataFound { get; set; }
        public string Message { get; set; }

        public DeleteModel(AppDbContext db)
        {
            this.db = db; 
        }

        public void OnGet(int id)
        {
            Employee = db.Employees.Find(id);

            if(Employee == null)
            {
                this.dataFound = false;
                this.Message = "EmployeeID NOT FOUND";
            }
            else
            {
                this.dataFound = true;
                this.Message = "";
            }
        }

        public IActionResult OnPost()
        {
            Employee emp = db.Employees.Find(Employee.EmployeeID);
            try
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
                TempData["Message"]="Employee deleted successfully";
                return RedirectToPage("/EmployeeManager/Index");
            }
            catch (DbUpdateException ex1)
            {
                Message = ex1.Message;
                if(ex1.InnerException != null)
                {
                    Message += " : " + ex1.InnerException;
                    Message += " : " + ex1.InnerException;
                }
            }
            catch(Exception ex2)
            {
                Message = ex2.Message;
            }
            return Page();
        }
    }
}
