using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataModels
{
    public class Intake
    {
        public int IntakeID { get; set; }
        public string IntakeDate { get; set; }
        public int IntakeDonorOrganization { get; set; }
        public string IntakeNotes { get; set; }


        public Intake()
        {

        }

        public Intake(DataRow dr)
        {
            string id = dr["IntakeID"].ToString();
            int temp;

            if (int.TryParse(id, out temp))
                IntakeID = temp;
            else
                IntakeID = -1; //No ID assigned yet

            IntakeDate = dr["IntakeDate"].ToString();
            IntakeDonorOrganization = int.Parse(dr["IntakeDonorOrganization"].ToString());
            IntakeNotes = dr["IntakeNotes"].ToString();

        }
    }
}