using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string StaffName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string StaffLastName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string StaffImage { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}