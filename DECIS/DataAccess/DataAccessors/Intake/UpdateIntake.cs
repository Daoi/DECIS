using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace DECIS.DataAccess.DataAccessors.Intake
{
    public class UpdateIntake : DataSupport, IData
    {
        public UpdateIntake()
        {
            CommandText = "UpdateIntake";
            CommandType = CommandType.StoredProcedure;
        }

        public int ExecuteCommand(int id, string notes)
        {
            Parameters = new MySqlParameter[2] {
                new MySqlParameter("IntakeID", id),
                new MySqlParameter("IntakeNotes", notes)
            };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteNonQuery(this); //Run the command
        }
    }
}