using Microsoft.EntityFrameworkCore;

namespace PhotoCollectionDisplay.Models
{
    [Index(nameof(UserName), IsUnique=true)]
    public class User
    {
        
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; }= string.Empty;
        
        // Just like we did in Categories, we can import the list of photos to our User model
        public List<Photo> Photos { get; set; } = new();
    }
}
