using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace ProjectCMC_Web.Models
{
    public class Connection
    {
        public enum Status { Connected=1,NoConnection=0}
        public int ConnectionID { get; set; }
        [Display(Name ="Start time")]
        public DateTime StartTime { get; set; }
        [Display(Name = "End time")]
        public DateTime EndTime { get; set; }
        [Display(Name = "Last IP")]
        public string LastIP { get; set; }
        [Display(Name = "Connection Status")]
        public Status ConnectionStatus { get; set; }

    }
}