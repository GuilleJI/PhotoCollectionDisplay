using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhotoCollectionDisplay.Data;
using PhotoCollectionDisplay.Models;

namespace PhotoCollectionDisplay.Pages
{
    public class DisplayPhotoModel : PageModel
    {
        private readonly PhotoCollectionDisplay.Data.PhotoCollectionDisplayContext _context;

        public Photo Photo { get; set; } = default!;

        // Constructor
        public DisplayPhotoModel(PhotoCollectionDisplayContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.Photo.FirstOrDefaultAsync(m => m.PhotoId == id);

            if (photo == null)
            {
                return NotFound();
            }
            else
            {
                Photo = photo;
            }
            return Page();
        }
    }
}
