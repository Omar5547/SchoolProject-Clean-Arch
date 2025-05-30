using SchoolApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Application.Services
{
    public class StudentService : IStudentService
    {
        public Task AddAsync(Student item)
        {
            throw new NotImplementedException();
        }

        public Task AddStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public void Delete(Student item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Student item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
