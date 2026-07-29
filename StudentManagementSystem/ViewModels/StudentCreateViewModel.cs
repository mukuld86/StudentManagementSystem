using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.ViewModels
{
    public class StudentCreateViewModel
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Course { get; set; } = string.Empty;

        [Range(18, 60)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
