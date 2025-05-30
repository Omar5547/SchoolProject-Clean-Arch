using SchoolApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.Services
{
    public interface IClassService
    {
        Task<IEnumerable <List<ClassViewModel>>> GetAllClassesAsync();
        Task<Class> GetClassByIdAsync(int id);
        Task AddClassAsync(Class classEntity);
        Task UpdateClassAsync(Class classEntity);
        Task DeleteClassAsync(int id);
    }
}
