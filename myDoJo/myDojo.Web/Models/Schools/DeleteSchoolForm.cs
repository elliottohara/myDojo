using System;
using System.Web.Mvc;

namespace myDojo.Web.Models.Schools
{
    public class DeleteSchoolForm
    {
        public DeleteSchoolForm(){}
        public DeleteSchoolForm(Guid id)
        {
            SchoolId = id;
        }
        [HiddenInput(DisplayValue = false)]
        public Guid SchoolId { get; set; }
    }
}