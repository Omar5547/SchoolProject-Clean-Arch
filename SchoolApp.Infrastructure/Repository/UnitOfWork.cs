
using SchoolApp.Application.interfaces;
using SchoolApp.Domain.Entities;
using SchoolApp.Infrastructure.Data;
using SchoolApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork , IDisposable
    {
        private readonly SchoolAppDbContext _dbcontext;

        public IGenericRepository<Student> Students { get; set ; }
        public IGenericRepository<Teacher> Teachers { get ; set ; }
        public IGenericRepository<Parent> Parents { get ; set ; }
        public IGenericRepository<Class> Classes { get ; set ; }
        public IGenericRepository<Grade> Grades { get ; set; }
        public UnitOfWork(SchoolAppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            Students = new GenericRepository<Student>(dbcontext);
            Teachers = new GenericRepository<Teacher>(dbcontext);
            Parents = new GenericRepository<Parent>(dbcontext);
            Classes = new GenericRepository<Class>(dbcontext);
            Grades = new GenericRepository<Grade>(dbcontext);
        }

        public async Task<int> CompleteAsync()
        {
           return await _dbcontext.SaveChangesAsync();
        }

        public  void Dispose()
        {
            _dbcontext.Dispose();
        }
    }
}
