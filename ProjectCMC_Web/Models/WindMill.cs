using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProjectCMC_Web.Models
{
    public class WindMill
    {
        public int WindMillID { get; set; }
        [Display(Name = "Wind Park Name")]
        public string WindMillName { get; set; }
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        [Display(Name = "Modified On")]
        public DateTime ModifiedOn { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

        public int WindParkID { get; set; }
        public WindPark Windpark { get; set; }
        //sdgsdgdgdg

    }
}