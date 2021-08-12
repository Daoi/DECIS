using DECIS.DataAccess.DataAccessors.Assets;
using System.Data;

namespace DECIS.DataAccess.DataAccessors.Organization
{
    public class UpdateOrg : DataSupport, IData
    {
        public UpdateOrg(DataModels.Organization org)
        {
            CommandText = "UpdateOrganization";
            CommandType = CommandType.StoredProcedure;
            Parameters = new UpdateOrgParameters().Fill(org);
        }

        public int ExecuteCommand()
        {
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteNonQuery(this);
        }
    }
}