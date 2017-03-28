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
        [Display(Name = "Wind Mill Name")]
        public string WindMillName { get; set; }
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        [Display(Name = "Modified On")]
        public DateTime ModifiedOn { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }
        [Display(Name = "Manufacturer Name")]
        public string ManufacturerName { get; set; }
        public string Latitude { get; set; }
        public string Longtitude { get; set; }
        public int WindParkID { get; set; }
        public virtual WindPark WindPark { get; set; }
        
        //Foriegn Key for Node
        public virtual List<Node> Nodes { get; set; }

        public virtual List<Connection> Connections { get; set; }
    }
}