using MySql.Data.MySqlClient;
using System.Data;

namespace DECIS.DataAccess.DataAccessors.Assets.Types
{
    public class InsertAssetType : DataSupport, IData
    {
        public InsertAssetType()
        {
            CommandText = "InsertAssetType";
            CommandType = CommandType.StoredProcedure;
        }

        public int ExecuteCommand(string at)
        {


            Parameters = new MySqlParameter[1] {
                new MySqlParameter("AssetType", at),

            };
            ExecuteQuery eq = new ExecuteQuery(); //Create instance of class that handles command obj
            return eq.ExecuteNonQuery(this); //Run the command
        }
    }
}