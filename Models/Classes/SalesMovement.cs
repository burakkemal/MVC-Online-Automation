using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class SalesMovement
    {
        [Key]
        public int SaleId { get; set; }
        public DateTime Date { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public int ProductId { get; set; }
        public int CurrentId { get; set; }
        public int StaffId { get; set; }
        public virtual Product Product  { get; set; }
        public virtual Current Current { get; set; }
        public virtual Staff Staff { get; set; }
    }
}