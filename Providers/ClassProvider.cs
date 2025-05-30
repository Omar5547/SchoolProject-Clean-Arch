using SchoolApp.Domain.Entities;
using WebApplication2025.ViewModels;

namespace WebApplication2025.Providers
{
    public static class ClassProvider
    {

        /// /////////////// Converts a Class entity to a ClassViewModel

        public static ClassViewModel ToViewModel(Class classes)
        {
            var classviewmodel =  new ClassViewModel
            {
                Id = classes.Id,
                Name = classes.Name,
                TeacherId = classes.TeacherId,
                TeacherName = classes.Teacher.Name
            };
            return classviewmodel;
        }

        public static Class ToEntity(ClassViewModel viewModel)
        { 
            var classes = new Class
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                TeacherId = viewModel.TeacherId
            };
            return classes;

        }
    }
}
