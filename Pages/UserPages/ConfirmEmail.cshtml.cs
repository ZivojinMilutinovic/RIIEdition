using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RIIEdition.Data;

namespace RIIEdition.Pages.UserPages
{
    public class ConfirmEmailModel : PageModel
    {
         private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
         public ConfirmEmailModel(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
         

        [BindProperty(SupportsGet=true)]
        public string Error{get;set;}="1";

        public async Task<IActionResult> OnGetAsync(string userId,string token)
        {
            if(userId==null || token==null)
            return Page();

            var user=await userManager.FindByIdAsync(userId);
            var result=await userManager.ConfirmEmailAsync(user,token);
            
            if(result.Succeeded)
            {
                return RedirectToPage("/Index");
            }
            else{
                Error="Desila se greska sa konfirmacijom mail.Molimo obratiti se adminisrtoru";
                return Page();
            }

        }
    }
}
