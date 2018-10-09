using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoultaryForm.Models
{
    public class FarmHouse
    {
        public int FarmHouseID { get; set; }
        [Required]
        [DisplayName("Farm Name")]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [DisplayName("Farm Address")]
        [StringLength(60, MinimumLength = 3)]
        public string Address { get; set; }
        [Required]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime orderDate { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

    public class PoultaryFarm : DbContext
    {
        public DbSet<Order> order { get; set; }
        public DbSet<FarmHouse> farmhouse { get; set; }
        public DbSet<Vehicle> vehicle { get; set; }
        public DbSet<Worker> worker { get; set; }
        public DbSet<Reatiler> retailer { get; set; }

        public System.Data.Entity.DbSet<PoulltaryFarm.Models.Report> Reports { get; set; }
    }
}