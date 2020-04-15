using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WVC.Models
{
    public class mvcEmployeeModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage="Harus Diisi ")]
        public string Name { get; set; }
        public string Position { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<int> Salary { get; set; }
    }
}