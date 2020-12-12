using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using AutoLotDAL.Models.Base;

namespace AutoLotDAL.Models
{

    public partial class Orders:EntityBase
    {
      //  [Key]
     //   public int CustomerID { get; set; }

        public int CustomerID { get; set; }

        public int CarID { get; set; }
        [ForeignKey (nameof(CustomerID))]

        public virtual Customers Customer { get; set; }

        [ForeignKey (nameof(CarID))]
        public virtual Test Car { get; set; }
    }
}
