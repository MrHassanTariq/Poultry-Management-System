using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PoultaryForm.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 4)]
        [DisplayName("Vehicle Number")]
        public string Number { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 4)]
        [DisplayName("Driver Name")]
        public string Driver { get; set; }
        [Required]
        [StringLength(11,MinimumLength =11)]
        [DisplayName("Driver Contact Number ")]
        public string PhoneNumber { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public int WorkerID { get; set; }
        public virtual Worker worker { get; set; }
    }
}