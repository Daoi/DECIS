using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using DECIS.DataModels;

namespace DECIS.DataAccess.DataAccessors.Intake
{
    public class InsertIntake : DataSupport, IData
    {
        public InsertIntake()
        {
            CommandText = "InsertIntake";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand(DataModels.Intake it)
        {
            string date = it.IntakeDate;
            string notes = it.IntakeNotes;
            int ido = it.IntakeDonorOrganization;

            Parameters = new MySqlParameter[3] {
                new MySqlParameter("IntakeDate", date),
                new MySqlParameter("IntakeDonorOrg", ido),
                new MySqlParameter("IntakeNotes", notes)
            };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}