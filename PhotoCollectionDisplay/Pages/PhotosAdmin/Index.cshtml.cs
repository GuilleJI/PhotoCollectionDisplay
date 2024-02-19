using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhotoCollectionDisplay.Data;
using PhotoCollectionDisplay.Models;

namespace PhotoCollectionDisplay.Pages.PhotosAdmin
{
    public class IndexModel : PageModel
    {
        private readonly PhotoCollectionDisplay.Data.PhotoCollectionDisplayContext _context;

        
        public IndexModel(PhotoCollectionDisplay.Data.PhotoCollectionDisplayContext context)
        {
            _context = context;
        }
        


        public IList<Photo> Photos { get;set; } = default!;


        public async Task OnGetAsync()
        {
            // Add an Include() to join the Photo to Category when executing the SQL statement.
            Photos = await _context.Photo.Include("Category").ToListAsync();
            
        }
    }
}
