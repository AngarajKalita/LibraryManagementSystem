using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        [StringLength(100, ErrorMessage = "Author cannot be longer than 100 characters")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Genre is required")]
        [StringLength(50, ErrorMessage = "Genre cannot be longer than 50 characters")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Published Year is required")]
        [Range(1450, 2100, ErrorMessage = "Published Year must be between 1450 and 2100")]
        public int PublishedYear { get; set; }

        [Required(ErrorMessage = "Availability Status is required")]
        [StringLength(20, ErrorMessage = "Availability Status cannot be longer than 20 characters")]
        public string AvailabilityStatus { get; set; }
    }
}
