using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace entity_course_ude.Models
{
    [Table("Tbl_Product")]
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }
        [Column("Product_Name")]
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description must be less than 500 characters")]
        [MaxLength(500)]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        //Not mapped on db
        [NotMapped]
        public int Age {get; set;}

        [Display(Name="User Address")]
        public string Address {get; set;}

        [Range(0.1, 10.0)]
        [DisplayFormat(ConvertEmptyStringToNull = true)]
    
        public double Grade {get; set;}
        [ForeignKey("Category")]
        public int Category_Id  {get; set;}
        public required Category Category { get; set;}

        //Relation Many To Many
        public required ICollection<ProductTag> ProductTag { get; set; }
    }
}