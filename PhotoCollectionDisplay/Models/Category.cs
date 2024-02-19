namespace PhotoCollectionDisplay.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; } = string.Empty;

        //Our Category can have a list of photos
        public List<Photo> Photos { get; set; } = default!;
    }
}
