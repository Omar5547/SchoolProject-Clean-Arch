using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Domain.Entities
{
    public class Student
    {
        public int  id { get; set; }
        public string name { get; set; }

        public DateTime Birthdate { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }
        
        public int ParentId { get; set; }
        public Parent Parent { get; set; }

        public ICollection<Grade> grades { get; set; }



    }
}
