using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PhotoCollectionDisplay.Data;
using PhotoCollectionDisplay.Models;
using System;

namespace PhotoCollectionDisplay.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PhotoCollectionDisplayContext _context;

        public IList<Photo> Photos { get; set; } = default!;

        public IndexModel(ILogger<IndexModel> logger, PhotoCollectionDisplayContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Photos = await _context.Photo.ToListAsync();
        }
    }
}
