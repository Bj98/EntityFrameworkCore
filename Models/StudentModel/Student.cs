using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Models.StudentModel
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Class { get; set; }
    }
}
