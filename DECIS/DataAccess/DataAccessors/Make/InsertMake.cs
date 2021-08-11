using MySql.Data.MySqlClient;
using System.Data;

namespace DECIS.DataAccess.DataAccessors.Make
{
    public class InsertMake : DataSupport, IData
    {
        public InsertMake()
        {
            CommandText = "InsertMake";
            CommandType = CommandType.StoredProcedure;
        }

        public int ExecuteCommand(string make)
        {


            Parameters = new MySqlParameter[1] {
                new MySqlParameter("Make", make),

            };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteNonQuery(this); //Run the command
        }
    }
}