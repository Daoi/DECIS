using System.Data;
using MySql.Data.MySqlClient;

namespace DECIS.DataAccess.DataAccessors.Location
{
    public class InsertLocation : DataSupport, IData
    {
        public InsertLocation()
        {
            CommandText = "InsertLocation";
            CommandType = CommandType.StoredProcedure;
        }

        public int ExecuteCommand(string location, string description, int status)
        {
            Parameters = new MySqlParameter[3] {
                new MySqlParameter("Location", location),
                new MySqlParameter("LocationDescription", description),
                new MySqlParameter("StatusID", status)
            };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteNonQuery(this); //Run the command
        }
    }
}