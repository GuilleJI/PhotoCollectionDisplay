using BCrypt.Net;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhotoCollectionDisplay.Data;
using PhotoCollectionDisplay.Models;
using System.Security.Claims;

namespace PhotoCollectionDisplay.Pages.Users
{
    public class LoginModel : PageModel
    {
        private readonly PhotoCollectionDisplayContext _context;

        [BindProperty]
        public string UserName { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public LoginModel (PhotoCollectionDisplayContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }

        public async Task <IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }

            // Find the input username in the database
            User? userDb = await _context.User.SingleOrDefaultAsync(m => m.UserName == UserName);

            if (userDb == null)
            {
                //Invalid username
                return Page(); 
            }

            // Verify the password entered 
            bool validPassword = BCrypt.Net.BCrypt.Verify(Password, userDb.Password);

            if (validPassword)
            {
                // to-do: Initialize cookie with session

                //
                // Initialize user session
                //
                // Create claims, 1 custom one
                List<Claim> claims = new List<Claim>{
                    new Claim(ClaimTypes.Name, userDb.UserId.ToString()),
                    new Claim(ClaimTypes.Role, "Member"),
                    new Claim("FullName", userDb.FirstName + " " +userDb.LastName)
                };

                // Create Claims Identity
                ClaimsIdentity claimsidentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsidentity),
                    new AuthenticationProperties());


                return RedirectToPage("/PhotosAdmin/Index");
            }
            else
            {
                //Invalid password
                return Page();
            }
            
        }
    }
}
