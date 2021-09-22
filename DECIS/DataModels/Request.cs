using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataModels
{
    [Serializable]
    public class Request
    {
        public int RequestID { get; set; }
        public int OrgID { get; set; }
        public int Status { get; set; } //1 = New Item, 2 = Pending, 3 = Scheduled, 4 = Finished, 5 = Cancelled
        public string RequestStatus { get; set; }
        public string OrgName { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string DateSubmitted { get; set; }
        public string DateFinished { get; set; }
        public string DateScheduled { get; set; }
        public string Notes { get; set; }
        public int Keyboard { get; set; }
        public int Mice { get; set; }
        public int Wifi { get; set; }
        public int Webcam { get; set; }
        public int Headset { get; set; }
        public int Type { get; set; } //0 = Org, 1 = Personal

        public Request() { }
        public Request(DataRow dr)
        {
            RequestID = int.Parse(dr["RequestID"].ToString());
            OrgID = int.Parse(dr["OrgID"].ToString());
            Status = int.Parse(dr["Status"].ToString());
            RequestStatus = dr["RequestStatus"].ToString();
            OrgName = dr["OrgName"].ToString();
            Name = dr["Name"].ToString();
            Phone = dr["Phone"].ToString();
            Email = dr["Email"].ToString();
            DateSubmitted = DateTimeString.GetDateString(dr["DateSubmitted"].ToString());
            DateFinished = DateTimeString.GetDateString(dr["DateFinished"].ToString());
            DateScheduled = DateTimeString.GetDateString(dr["DateScheduled"].ToString());
            Keyboard = int.Parse(dr["Keyboard"].ToString());
            Mice = int.Parse(dr["Mice"].ToString());
            Wifi = int.Parse(dr["Wifi"].ToString());
            Webcam = int.Parse(dr["Webcam"].ToString());
            Headset = int.Parse(dr["Headset"].ToString());
            Notes = dr["Notes"].ToString();
            Type = int.Parse(dr["Type"].ToString());
        }
    }
}