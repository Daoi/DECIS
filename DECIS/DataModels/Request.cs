﻿using System;
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
        public int Status { get; set; } //1 = New Item, 2 = Pending, 3 = Scheduled, 4 = Finished, 5 = Cancelled
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string DateSubmitted { get; set; }
        public string DateFinished { get; set; }
        public string Notes { get; set; }
        public int Keyboard { get; set; }
        public int Mice { get; set; }
        public int Wifi { get; set; }
        public int Webcam { get; set; }
        public string Docs { get; set; }

        public Request() { }
        public Request(DataRow dr)
        {
            RequestID = int.Parse(dr["RquestID"].ToString());
            OrgID = int.Parse(dr["OrgID"].ToString());
            Status = int.Parse(dr["Status"].ToString());
            Name = dr["Name"].ToString();
            Phone = dr["Phone"].ToString();
            Email = dr["Email"].ToString();
            DateSubmitted = string.Format("MM-dd-yyyy", dr["DateSubmitted"]);
            if(dr["DateFinished"] != DBNull.Value)
                DateFinished = string.Format("MM-dd-yyyy", dr["DateSubmitted"]);
            Keyboard = int.Parse(dr["Keyboard"].ToString());
            Mice = int.Parse(dr["Mice"].ToString());
            Wifi = int.Parse(dr["Wifi"].ToString());
            Webcam = int.Parse(dr["Webcam"].ToString());
            Notes = dr["Notes"].ToString();
            Docs = dr["Docs"].ToString();

        }
    }
}