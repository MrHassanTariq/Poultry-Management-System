using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoultaryForm.Models
{
    public class Reatiler
    {
        public int ID { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 4)]
        [DisplayName("Retailer Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Weight")]
        [Range(1, 100000)]
        public int Weight { get; set; }
        [Required]
        [Range(1, 1000)]
        [DisplayName("Price Per Kg")]
        public int UnitPrice { get; set; }
        [Required]
        [DisplayName("Reatler Contact Number")]
        [StringLength(11, MinimumLength = 11)]
        public string PhoneNumber { get; set; }
        public int? Total { get; set; }
        [Required]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
    }
}