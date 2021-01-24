using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectMVC.Models
{
    public class TransModel
    {
        [Key]
        public int id { get; set; }

        [Column(TypeName ="varchar(100)")]
        public string Name { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Date1 { get; set; }
        [Column(TypeName = "bit")]
        public bool Married { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Phone { get; set; }
        [Column(TypeName = "decimal")]
        public decimal Salary { get; set; }

      
    }
}
