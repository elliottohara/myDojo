using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace myDojo.Web.Models.Schools
{
    public class CreateSchoolForm
    {
        public CreateSchoolForm()
        {
            Id = Guid.NewGuid();
        }
        [Required]
        [Display(AutoGenerateField = true,Name = "Name",Order = 1,Prompt = "Name")]
        public string Name { get; set; }
        [Key]
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
        [Display(AutoGenerateField = true, Name = "Street Number", Order = 2, Prompt = "Street Number")]
        public string StreetNumber { get; set; }
        [Display(AutoGenerateField = true, Name = "Street", Order = 3, Prompt = "Street")]
        public string StreetName { get; set; }
        [Required]
        [Display(AutoGenerateField = true, Name = "City", Order = 4, Prompt = "City")]
        public string City { get; set; }
        [Required]
        [Display(AutoGenerateField = true, Name = "State", Order = 5, Prompt = "State")]
        public string State { get; set; }
        [Display(AutoGenerateField = true, Name = "PostalCode", Order = 6, Prompt = "PostalCode")]
        public string PostalCode { get; set; }
        [Display(Name = "Description",Order = 7)]
        [DataType(DataType.Html)]
        public string Description { get; set; }
    }
}