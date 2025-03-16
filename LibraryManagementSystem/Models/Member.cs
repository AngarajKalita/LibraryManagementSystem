using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace LibraryManagementSystem.Models
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public DateTime MembershipStartDate { get; set; }
    }
}
