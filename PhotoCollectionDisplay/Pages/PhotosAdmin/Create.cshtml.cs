using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PhotoCollectionDisplay.Data;
using PhotoCollectionDisplay.Models;

namespace PhotoCollectionDisplay.Pages.PhotosAdmin
{
    public class CreateModel : PageModel
    {
        private readonly PhotoCollectionDisplayContext _context;
        private readonly IHostEnvironment _environment;

        [BindProperty]
        public Photo Photo { get; set; } = default!;


        [BindProperty]
        [DisplayName("Upload Photo")]
        public IFormFile FileUpload { get; set; }



        public CreateModel(PhotoCollectionDisplayContext context, IHostEnvironment environment)
        {
            _context = context;
            _environment = environment; //initialize environment 
        }


        public IActionResult OnGet()
        {
            return Page();
        }  


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Set the publish date for the photo
            Photo.PublishDate = DateTime.Now;

            //
            // Upload file to server
            //

            //Make a unique filename
            string filename = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + FileUpload.FileName;

            //Upload Photo object to include the photo filename 
            Photo.FileName  = filename;

            //Save the file 
            string projectRootPath = _environment.ContentRootPath;
            string fileSavePath = Path.Combine(projectRootPath, "wwwroot", "uploads", filename);

            //we use a "using" to ensure the filestream is disposed of when we're done with it
            using (FileStream fileStream = new FileStream(fileSavePath, FileMode.Create))
            {
                FileUpload.CopyTo(fileStream);
            }


            //update the .net contex
            _context.Photo.Add(Photo);

            //Sync the .net context with database (execute insert command)
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
