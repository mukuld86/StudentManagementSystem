using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class SearchRequest
    {
        public int? RegistrationNumber { get; set;}
        [EmailAddress(ErrorMessage ="Please enter a valid email address!")]
        public string? Email { get; set; }
    }
}
