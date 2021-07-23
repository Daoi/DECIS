using DECIS.DataAccess.DataAccessors.Assets.Types;
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

namespace DECIS.CotrolLogic
{
    public class DDLDataBind
    {

        private static Dictionary<string, Func<DropDownList, DataTable>> bindings = new Dictionary<string, Func<DropDownList, DataTable>>()
        { { "ddlAssetMake", AssetMake}, { "ddlAssetModel", AssetModel}, { "ddlLocation", AssetLocation},
          { "ddlLocationDescription", AssetLocationDescription}, { "ddlAssetStatus", AssetStatus},
          { "ddlAssetType", AssetType}
        };

        /// <summary>
        /// Provide a list of datatables to call a method to bind them to a datatable
        /// </summary>
        /// <param name="ddls">List of the DDLs to bind</param>
        /// <param name="makeID">Optional parameter for Make where a model is already chosen to filter items put into list</param>
        /// <returns>A list of the data tables used for binding. Index should match the order of ddls in list.</returns>
        public static List<DataTable> ddlBind(List<DropDownList> ddls, int makeID = -1)
        {
            List<DataTable> dts = new List<DataTable>();
            if (makeID > -1)
            {
                DropDownList model = ddls.First(ddl => ddl.ID == "ddlAssetModel") as DropDownList;
                AssetModel(model, makeID);
                ddls.Remove(model);
            }
            foreach(DropDownList ddl in ddls)
            {
                string name = ddl.ID;
                dts.Add(bindings[name].Invoke(ddl));
            }

            return dts;
        }

        //Should probably do this with an interface and seperate classes instead of these methods

        private static DataTable AssetModel(DropDownList ddl)
        {
            DataTable modelDT = new GetAllModel().ExecuteCommand();
            ddl.DataSource = modelDT;
            ddl.DataTextField = "Model";
            ddl.DataValueField = "ModelID";
            ddl.DataBind();

            return modelDT;
        }

        private static DataTable AssetModel(DropDownList ddl, int makeID)
        {
            DataTable modelDT = new GetAllModel().ExecuteCommand();
            ddl.DataSource = modelDT.AsEnumerable().Where(r => r.Field<int>("Make") == makeID).CopyToDataTable();
            ddl.DataTextField = "Model";
            ddl.DataValueField = "ModelID";
            ddl.DataBind();

            return modelDT;
        }

        private static DataTable AssetMake(DropDownList ddl)
        {
            DataTable makeDT = new GetAllMake().ExecuteCommand();

            ddl.DataSource = makeDT;
            ddl.DataTextField = "Make";
            ddl.DataValueField = "MakeID";
            ddl.DataBind();

            return makeDT;
        }

        private static DataTable AssetStatus(DropDownList ddl)
        {
            DataTable statusDT = new GetAllStatus().ExecuteCommand();

            ddl.DataSource = statusDT;
            ddl.DataTextField = "Status";
            ddl.DataValueField = "StatusID";
            ddl.DataBind();

            return statusDT;
        }

        private static DataTable AssetLocation(DropDownList ddl)
        {
            DataTable locationDT = new GetAllLocation().ExecuteCommand();

            ddl.DataSource = locationDT;
            ddl.DataTextField = "Location";
            ddl.DataValueField = "LocationID";
            ddl.DataBind();

            return locationDT;
        }

        private static DataTable AssetLocationDescription(DropDownList ddl)
        {
            DataTable locationDT = new GetAllLocation().ExecuteCommand();

            ddl.DataSource = locationDT;
            ddl.DataTextField = "LocationDescription";
            ddl.DataValueField = "LocationDescriptionID";
            ddl.DataBind();

            return locationDT;
        }

        private static DataTable AssetType(DropDownList ddl)
        {
            DataTable typeDT = new GetAllAssetTypes().ExecuteCommand();

            ddl.DataSource = typeDT;
            ddl.DataTextField = "AssetType";
            ddl.DataValueField = "AssetTypeID";
            ddl.DataBind();

            return typeDT;
        }

    }



}