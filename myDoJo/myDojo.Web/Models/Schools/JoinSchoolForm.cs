using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace myDojo.Web.Models.Schools
{
    public class JoinSchoolForm
    {
        [HiddenInput(DisplayValue = false)]
        public Guid DojoId { get; set; }
    }
}