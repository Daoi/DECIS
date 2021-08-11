using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECIS.DataModels
{
    public class Request
    {
        public int OrgID { get; set; }
        public string RequestorsName { get; set; }
        public string RequestorsPhoneNumber { get; set; }
        public string RequestorsEmailAddress { get; set; }
        public string Purpose { get; set; }
        public string ItemsRequested { get; set; }
        public bool FirstRequest { get; set; }
        public string Referer { get; set; }
        public string Timeline { get; set; }
    }
}