using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager_RazorPages.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManager_RazorPages.Pages.Security
{
    [Authorize]
    public class SignOutModel : PageModel
    {
        private readonly SignInManager<AppIdentityUser> signInManager;

        public SignOutModel(SignInManager<AppIdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("/EmployeeManager/Index");
        }

    }
}
