using SchoolApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Student> Students { get; set; }  
        IGenericRepository<Teacher> Teachers { get; set; }
        IGenericRepository<Parent> Parents { get; set; }
        IGenericRepository<Class> Classes { get; set; }
        IGenericRepository<Grade> Grades { get; set; }

        Task<int> CompleteAsync();
        void Dispose();

    }
}
