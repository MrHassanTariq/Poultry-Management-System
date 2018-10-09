using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PoultaryForm.Models
{
    public class Worker
    {
        public int WorkerID { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        [DisplayName("Worker Name")]
        public string Name { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 11)]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}