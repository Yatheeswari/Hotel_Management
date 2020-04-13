using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TruYumMVCExercise.Models
{
    public class Cart
    {
        [Key]

       public int CartId { get; set; }
        public string ItemName { get; set; }
        public bool FreeDelivery { get; set; }
        public int Price { get; set; }
        public MenuItem MenuItem{ get; set; }
        //public Category category { get; set; }
    }
}