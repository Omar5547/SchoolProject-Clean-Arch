using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Infrastructure.Data
{
    public class SchoolAppDbContext : IdentityDbContext
    {
        public SchoolAppDbContext(DbContextOptions<SchoolAppDbContext> options)
            : base(options) 
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Grade> Grades { get; set; }
       
    }
}
