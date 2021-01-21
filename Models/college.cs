using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace binary_transaction_in_asp.net_mvc_core.Models
{
    public class College
    {
        [Key]
        public int clgId { get; set; }
        public string StudentName { get; set; }
        public string StudentCity { get; set; }
        public string EmpName { get; set; }
        public string EmpSalary { get; set; }
    }
}
