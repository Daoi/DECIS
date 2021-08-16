using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataModels
{
    public class Request
    {
        public int RequestID { get; set; }
        public int OrgID { get; set; }
        public int Status { get; set; } //0 = New Item, 1 = Pending, 2 = Finished, 3 = Cancelled
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Purpose { get; set; }
        public string ItemsRequested { get; set; }
        public string Timeline { get; set; }
        public string DateSubmitted { get; set; }
        public string DateFinished { get; set; }
        public string Notes { get; set; }
        int Keyboard { get; set; }
        int Mice { get; set; }
        int Wifi { get; set; }
        int Webcam { get; set; }

        public Request() { }
        public Request(DataRow dr)
        {
            RequestID = int.Parse(dr["RquestID"].ToString());
            OrgID = int.Parse(dr["OrgID"].ToString());
            Status = int.Parse(dr["Status"].ToString());
            Name = dr["Name"].ToString();
            Phone = dr["Phone"].ToString();
            Email = dr["Email"].ToString();
            ContactName = dr["ContactName"].ToString();
            ContactPhone = dr["ContactPhone"].ToString();
            ContactEmail = dr["ContactEmail"].ToString();
            Purpose = dr["Purpose"].ToString(); 
            ItemsRequested = dr["ItemsRequested"].ToString();
            Timeline = dr["Timeline"].ToString();
            DateSubmitted = string.Format("MM-dd-yyyy", dr["DateSubmitted"]);
            if(dr["DateFinished"] != DBNull.Value)
                DateFinished = string.Format("MM-dd-yyyy", dr["DateSubmitted"]);
            Keyboard = int.Parse(dr["Keyboard"].ToString());
            Mice = int.Parse(dr["Mice"].ToString());
            Wifi = int.Parse(dr["Wifi"].ToString());
            Webcam = int.Parse(dr["Webcam"].ToString());
            Notes = dr["Notes"].ToString();

        }
    }
}