using DECIS.DataAccess.DataAccessors.Intake;
using DECIS.DataAccess.DataAccessors.Organization;
using DECIS.DataAccess.Utilities;
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

        public static Intake ImportIntake(DataRow dr)
        {
            DataTable orgDT = new GetAllOrgs().ExecuteCommand();

            int orgID = FindIDWithWhere.FindID(orgDT, dr, "OrgName", "Donor's Organization", "OrgID");

            if (orgID == -1)
            {
                Organization newOrg = Organization.ImportOrg(dr);
                orgID = RetrieveLastInsertedID.RetrieveID(new InsertOrg(newOrg).ExecuteCommand());
            }

            Intake newIntake = new Intake()
            {
                IntakeDate = dr["Date"].ToString(),
                IntakeDonorOrganization = orgID,
                IntakeNotes = $"Provided Contact Info: {dr["Contact Person"].ToString()} Phone: {dr["Phone Number"].ToString()} Email: {dr["Email Address"].ToString()} "
            };

            try
            {
                newIntake.IntakeID = RetrieveLastInsertedID.RetrieveID(new InsertIntake().ExecuteCommand(newIntake));
            }
            catch (Exception e)
            {
                throw e;
            }

            return newIntake;
        }

    }
}