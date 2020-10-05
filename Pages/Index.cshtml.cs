using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManager_RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            string url = "/EmployeeManager";

            return Redirect(url);
        }
    }
}
