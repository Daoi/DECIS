using DECIS.DataAccess.DataAccessors.Location;
using DECIS.DataAccess.DataAccessors.Make;
using DECIS.DataAccess.DataAccessors.Model;
using DECIS.DataAccess.DataAccessors.Status;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic
{
    public class DDLDataBind
    {

        private static Dictionary<string, Action<DropDownList>> bindings = new Dictionary<string, Action<DropDownList>>()
        { { "ddlAssetMake", AssetMake}, { "ddlAssetModel", AssetModel}, { "ddlLocation", AssetLocation},
          { "ddlLocationDescription", AssetLocationDescription}, { "ddlAssetStatus", AssetStatus}
        };

        public static void ddlBind(List<DropDownList> ddls, int makeID = -1)
        {
            if(makeID > -1)
            {
                DropDownList model = ddls.First(ddl => ddl.ID == "ddlAssetModel") as DropDownList;
                AssetModel(model, makeID);
                ddls.Remove(model);
            }
            foreach(DropDownList ddl in ddls)
            {
                string name = ddl.ID;
                bindings[name].Invoke(ddl);
            }
        }

        //Should probably do this with an interface and seperate classes instead of these methods

        private static void AssetModel(DropDownList ddl)
        {
            DataTable modelDT = new GetAllModel().ExecuteCommand();
            ddl.DataSource = modelDT;
            ddl.DataTextField = "Model";
            ddl.DataValueField = "ModelID";
            ddl.DataBind();
        }

        private static void AssetModel(DropDownList ddl, int makeID)
        {
            DataTable modelDT = new GetAllModel().ExecuteCommand();
            ddl.DataSource = modelDT.AsEnumerable().Where(r => r.Field<int>("Make") == makeID).CopyToDataTable();
            ddl.DataTextField = "Model";
            ddl.DataValueField = "ModelID";
            ddl.DataBind();
        }

        private static void AssetMake(DropDownList ddl)
        {
            DataTable makeDT = new GetAllMake().ExecuteCommand();

            ddl.DataSource = makeDT;
            ddl.DataTextField = "Make";
            ddl.DataValueField = "MakeID";
            ddl.DataBind();
        }

        private static void AssetStatus(DropDownList ddl)
        {
            DataTable statusDT = new GetAllStatus().ExecuteCommand();

            ddl.DataSource = statusDT;
            ddl.DataTextField = "Status";
            ddl.DataValueField = "StatusID";
            ddl.DataBind();
        }

        private static void AssetLocation(DropDownList ddl)
        {
            DataTable locationDT = new GetAllLocation().ExecuteCommand();

            ddl.DataSource = locationDT;
            ddl.DataTextField = "Location";
            ddl.DataValueField = "LocationID";
            ddl.DataBind();
        }

        private static void AssetLocationDescription(DropDownList ddl)
        {
            DataTable locationDT = new GetAllLocation().ExecuteCommand();

            ddl.DataSource = locationDT;
            ddl.DataTextField = "LocationDescription";
            ddl.DataValueField = "LocationDescriptionID";
            ddl.DataBind();
        }

    }



}