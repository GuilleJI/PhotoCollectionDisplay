using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhotoCollectionDisplay.Models;

namespace PhotoCollectionDisplay.Data
{
    public class PhotoCollectionDisplayContext : DbContext
    {
        public PhotoCollectionDisplayContext (DbContextOptions<PhotoCollectionDisplayContext> options)
            : base(options)
        {
        }

        public DbSet<PhotoCollectionDisplay.Models.Photo> Photo { get; set; } = default!; //Representation of our database :)
        public DbSet<PhotoCollectionDisplay.Models.Category> Category { get; set; } = default!;
    }
}
