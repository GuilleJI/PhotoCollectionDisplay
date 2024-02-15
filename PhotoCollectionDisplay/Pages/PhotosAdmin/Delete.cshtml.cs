﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly PhotoCollectionDisplay.Data.PhotoCollectionDisplayContext _context;

        public DeleteModel(PhotoCollectionDisplay.Data.PhotoCollectionDisplayContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Photo Photo { get; set; } = default!;

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var photo = await _context.Photo.FindAsync(id);
            if (photo != null)
            {
                Photo = photo;
                _context.Photo.Remove(Photo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}