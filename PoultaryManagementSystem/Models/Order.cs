using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoultaryForm.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        [Required]
        [Range(1, 10000)]
        [DisplayName("Weight Of chicken")]
        public int Weight { get; set; }
        [Required]
        [Range(1, 1000)]
        [DisplayName("Price per(Kg)")]
        public int unitPrice { get; set; }
        [Index(IsUnique = true)]
        [DisplayName("Order Number")]
        [StringLength(10, MinimumLength = 3)]
        public string OrderNumber { get; set; }
        [Required]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        public int? TotalWeightLeft { get; set; }
        public int? Total { get; set; }
        public int FarmHouseID { get; set; }
        public virtual FarmHouse FarmHouse { get; set; }
        public int VehicleID { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<Reatiler> Retailers { get; set; }
    }
}