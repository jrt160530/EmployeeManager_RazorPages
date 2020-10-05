using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManager_RazorPages.Models;
using EmployeeManager_RazorPages.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeeManager_RazorPages.Pages.Security
{
    public class SignInModel : PageModel
    {
        [BindProperty]
        public SignIn SignInData { get; set; }
        private readonly SignInManager<AppIdentityUser> signInManager;

        public SignInModel(SignInManager<AppIdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(SignInData.UserName,
                    SignInData.Password, SignInData.RememberMe, false);

                if(result.Succeeded)
                {
                    return RedirectToPage("/EmployeeManager/Index");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Login");
                }
            }
            return Page();
        }
    }

}
