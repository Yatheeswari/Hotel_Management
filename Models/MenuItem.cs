using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TruYumMVCExercise.Models
{
    public class MenuItem
    {
        [Key]

        public int ItemId { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please fill out the Title!!!")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "Please fill out the Price!!!")]
        public int Price { get; set; }

        public bool Active { get; set; }
        
        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [Display(Name = "Date Of Launch")]

        public DateTime DateOfLaunch { get; set; }

        [Display(Name = "Category Name")]

        public string CategoryName { get; set; }

        [Display(Name = "Free Delivery")]
        public bool FreeDelivery { get; set; }

       // public Category category { get; set; }
       //public virtual IEnumerable<Cart> Cart { get; set; }

    }
}