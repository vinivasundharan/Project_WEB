using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjectCMC_Web.Models
{
    public class Node
    {
        public int NodeID { get; set; }
        [Display(Name = "Node Name")]
        public string NodeName { get; set; }
        [Display(Name = "Node Description")]
        public String NodeDescription { get; set; }
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        [Display(Name = "Modified On")]
        public DateTime ModifiedOn { get; set; }
        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
        [Display(Name = "Modified By")]
        public string ModifiedBy { get; set; }

        public int WindMillID { get; set; }
        public virtual WindMill WindMill { get; set; }
        //dfgdhdfhd
        

    }
}