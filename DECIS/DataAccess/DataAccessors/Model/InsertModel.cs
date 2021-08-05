using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace DECIS.DataAccess.DataAccessors.Model
{
    public class InsertModel : DataSupport, IData
    {
        public InsertModel()
        {
            CommandText = "InsertModel";
            CommandType = CommandType.StoredProcedure;
        }

        public DataTable ExecuteCommand(DataModels.Model mdl)
        {


            Parameters = new MySqlParameter[4] {
                new MySqlParameter("IntakeDate", date),
                new MySqlParameter("IntakeDonorOrg", ido),
                new MySqlParameter("IntakeNotes", notes),
                new MySqlParameter("IntakeNotes", notes)
            };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteAdapter(this); //Run the command
        }
    }
}