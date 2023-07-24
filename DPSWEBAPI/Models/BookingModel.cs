using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DPSWEBAPI.Models
{
    public class BookingModel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public string TypeofGoods { get; set; }
        public decimal Weight { get; set; }
        public string AssignDriver { get; set; }
        public string DeliverDate { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }

}
