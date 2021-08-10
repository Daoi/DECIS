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
        //Key = Name to check for - Value = Method to use for binding
        private static Dictionary<Func<string, bool>, Func<DropDownList, DataTable>> bindings = new Dictionary<Func<string, bool>, Func<DropDownList, DataTable>>()
        { { name => name.ToLower().Contains("make"), AssetMake},
          { name => name.ToLower().Contains("model"), AssetModel},
          { name => name.ToLower().Contains("location"), AssetLocation},
          { name => name.ToLower().Contains("description"), AssetLocationDescription},
          { name => name.ToLower().Contains("status"), AssetStatus},
          { name => name.ToLower().Contains("type"), AssetType}
        };

        /// <summary>
        /// Provide a list of datatables to call a method to bind them to a datatable
        /// </summary>
        /// <param name="ddls">List of the DDLs to bind</param>
        /// <param name="makeID">Optional parameter for Make where a model is already chosen to filter items put into list</param>
        /// <returns>A list of the data tables used for binding. Index should match the order of ddls in list.</returns>
        public static DataSet ddlBind(List<DropDownList> ddls, int makeID = -1)
        {
            DataSet dts = new DataSet();
            if (makeID > -1)
            {
                DropDownList model = ddls.First(ddl => ddl.ID == "ddlAssetModel") as DropDownList;
                dts.Tables.Add(AssetModel(model, makeID));
                ddls.Remove(model);
            }
            foreach(DropDownList ddl in ddls)
            {
                try {
                    string name = ddl.ID;
                    var key = bindings.Keys.First(k => k(name));
                    dts.Tables.Add(bindings[key].Invoke(ddl));
                }
                catch(Exception ex)
                {
                    continue;
                }

            }

            return dts;
        }

        //Should probably do this with an interface and seperate classes instead of these methods?

        private static DataTable AssetModel(DropDownList ddl)
        {
            DataTable modelDT = new GetAllModel().ExecuteCommand();
            modelDT.TableName = "Model";
            ddl.DataSource = modelDT;
            ddl.DataTextField = "Model";
            ddl.DataValueField = "ModelID";
            ddl.DataBind();

            return modelDT;
        }

        private static DataTable AssetModel(DropDownList ddl, int makeID)
        {
            DataTable modelDT = new GetAllModel().ExecuteCommand();
            modelDT.TableName = "Model";
            ddl.DataSource = modelDT.AsEnumerable().Where(r => r.Field<int>("Make") == makeID).CopyToDataTable();
            ddl.DataTextField = "Model";
            ddl.DataValueField = "ModelID";
            ddl.DataBind();

            return modelDT;
        }

        private static DataTable AssetMake(DropDownList ddl)
        {
            DataTable makeDT = new GetAllMake().ExecuteCommand();
            makeDT.TableName = "Make";
            ddl.DataSource = makeDT;
            ddl.DataTextField = "Make";
            ddl.DataValueField = "MakeID";
            ddl.DataBind();

            return makeDT;
        }

        private static DataTable AssetStatus(DropDownList ddl)
        {
            DataTable statusDT = new GetAllStatus().ExecuteCommand();
            statusDT.TableName = "Status";
            ddl.DataSource = statusDT;
            ddl.DataTextField = "Status";
            ddl.DataValueField = "StatusID";
            ddl.DataBind();

            return statusDT;
        }

        private static DataTable AssetLocation(DropDownList ddl)
        {
            DataTable locationDT = new GetAllLocation().ExecuteCommand();
            locationDT.TableName = "Location";
            ddl.DataSource = locationDT;
            ddl.DataTextField = "Location";
            ddl.DataValueField = "LocationID";
            ddl.DataBind();

            return locationDT;
        }

        private static DataTable AssetLocationDescription(DropDownList ddl)
        {
            DataTable locationDT = new GetAllLocation().ExecuteCommand();
            locationDT.TableName = "Location";
            ddl.DataSource = locationDT;
            ddl.DataTextField = "LocationDescription";
            ddl.DataValueField = "LocationID";
            ddl.DataBind();

            return locationDT;
        }

        private static DataTable AssetType(DropDownList ddl)
        {
            DataTable typeDT = new GetAllAssetTypes().ExecuteCommand();
            typeDT.TableName = "AssetType";
            ddl.DataSource = typeDT;
            ddl.DataTextField = "AssetType";
            ddl.DataValueField = "AssetTypeID";
            ddl.DataBind();

            return typeDT;
        }

    }



}