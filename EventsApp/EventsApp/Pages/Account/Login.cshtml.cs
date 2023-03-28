using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventsApp.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

/*
 * Login Page of the Event Web Application. 
 * Allows the admin user only (prototype simpler version) to enter the credentials to login.
 * Creates an authentication cookie for the user.
 * Redirects admin user to the secured Index Page, that allows him to create new events and see registration for all upcoming events. 
 */

namespace EventsApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Users User { get; set; }

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

                return RedirectToPage("/Account/Index");

           }

            return Page();
        }
    }
}
