using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PhotoCollectionDisplay.Data;
using PhotoCollectionDisplay.Models;
using SQLitePCL;

namespace PhotoCollectionDisplay.Pages.Users
{
    public class RegisterModel : PageModel
    {
        private readonly PhotoCollectionDisplayContext _context;
        
        [BindProperty]
        public User _User { get; set; } = new();

        public RegisterModel(PhotoCollectionDisplayContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // First encrypt the user's password
            string encryptedPassword = BCrypt.Net.BCrypt.HashPassword(_User.Password);

            // Update password in _User to encrypted version
            _User.Password = encryptedPassword;

            // Save user to database
            _context.User.Add(_User);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Users/Login");
        }
    }
}

