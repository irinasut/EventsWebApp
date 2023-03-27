using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventsApp.Data;
using EventsApp.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace EventsApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Users User { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
           if (!ModelState.IsValid)
           {
              return Page();
           }

           if (User.UserName == "dummy" && User.UserPassword == "dumdum")
           {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "admin")
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");

           }

            return Page();
        }
    }
}
