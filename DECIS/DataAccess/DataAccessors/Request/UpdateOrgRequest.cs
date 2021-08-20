using System.Data;
using DECIS.DataModels;

namespace DECIS.DataAccess.DataAccessors.Request
{
    public class UpdateOrgRequest : DataSupport, IData
    {
        public UpdateOrgRequest(OrgRequest req)
        {
            CommandText = "UpdateOrgRequest";
            CommandType = CommandType.StoredProcedure;
            Parameters = new OrgRequestParameters().Fill(req);
        }

        public int ExecuteCommand()
        {
            ExecuteQuery eq = new ExecuteQuery();
            return eq.ExecuteNonQuery(this);
        }
    }
}