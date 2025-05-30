using SchoolApp.Domain.Entities;

namespace WebApplication2025.ViewModels
{
    public class StudentViewModel
    {
        public int id { get; set; }
        public string name { get; set; }

        public DateTime Birthdate { get; set; }

        public int ClassId { get; set; }
        public string Classes { get; set; }
      
      

        public int ParentId { get; set; }
        public string? Parents { get; set; }
    }
}
