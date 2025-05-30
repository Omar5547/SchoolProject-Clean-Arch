using SchoolApp.Domain.Entities;

namespace WebApplication2025.ViewModels
{
    public class GradeViewModel
    {
        public int Id { get; set; }

        public string Subject { get; set; }
        public double Score { get; set; }

        public int StudentId { get; set; }
        public string? Students { get; set; }
    }
}
