using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using AutoLotDAL.Models.Base;

namespace AutoLotDAL.Models
{

  //  [Table("Test")]
    public partial class Test:EntityBase
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Test()
        //{
        //}

        //[Key]
        //public int CarID { get; set; }

        [StringLength(50)]
        public string Make { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [StringLength(50)]
        public string PetName { get; set; }

        public virtual ICollection<Orders> Orders { get; set; } = new HashSet<Orders>();
    }
}
