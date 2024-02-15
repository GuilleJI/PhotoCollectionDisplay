namespace PhotoCollectionDisplay.Models
{
    public class Photo
    {
        public int PhotoId { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty; 


        //Creating a published date for our uploaded photos
        public DateTime PublishDate { get; set; }

    }
}
