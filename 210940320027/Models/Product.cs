using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _210940320027.Models
{
    public class Product
    {
        [Required(ErrorMessage ="Please Enter valid ProductId")]
        public int ProductId { get; set; }


        [Required(ErrorMessage ="Please enter valid ProductName")]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }


        [Required(ErrorMessage = "Please enter valid Rate")]
        [Range(20,3000,ErrorMessage ="Rate of Product should be between 20 and 3000")]
        [DataType(DataType.Currency)]
        public decimal Rate { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter valid Description")]
        [MaxLength(200,ErrorMessage ="Desciption Should be less than 200 characters")]
        public string Description { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter valid Category")]
        [MaxLength(20,ErrorMessage ="Category name must be less than 50 characters")]
        public string CategoryName { get; set; }
    }
}