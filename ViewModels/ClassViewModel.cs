using SchoolApp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2025.ViewModels
{
    public class ClassViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Class name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please select a teacher")]
        public int TeacherId { get; set; }
        public string? TeacherName { get; set; }
    }
}
