using DECIS.DataAccess.DataAccessors.Account;
using DECIS.DataAccess.DataAccessors.Assets.Types;
using DECIS.DataAccess.DataAccessors.Location;
using DECIS.DataAccess.DataAccessors.Make;
using DECIS.DataAccess.DataAccessors.Model;
using DECIS.DataAccess.DataAccessors.Organization;
using DECIS.DataAccess.DataAccessors.Person.AgeRange;
using DECIS.DataAccess.DataAccessors.Person.Ethnicity;
using DECIS.DataAccess.DataAccessors.Person.Gender;
using DECIS.DataAccess.DataAccessors.Person.Race;
using DECIS.DataAccess.DataAccessors.Recycle.RecycleOrg;
using DECIS.DataAccess.DataAccessors.Recycle.RecycleStatus;
using DECIS.DataAccess.DataAccessors.Request.RequestStatus;
using DECIS.DataAccess.DataAccessors.Status;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace DECIS.CotrolLogic.DDL
{
    public class DDLDataBind
    {
        //Key = Name to check for - Value = Method to use for binding - If your DDL is using the wrong binding its name is most likely conflicting 
        private static Dictionary<Func<string, bool>, Func<DropDownList, DataTable>> bindings = new Dictionary<Func<string, bool>, Func<DropDownList, DataTable>>()
        { { name => name == "ddlAssetMake", AssetMake},
          { name => name == "ddlAssetModel", AssetModel},
          { name => name == "ddlLocation", AssetLocation},
          { name => name == "ddlLocationDescription", AssetLocationDescription},
          { name => name == "ddlRecycleStatus", RecycleStatus},
          { name => name == "ddlRecycleOrg", RecycleOrg},
          { name => name == "ddlRequestStatus", RequestStatus},
          { name => name == "ddlAssetStatus", AssetStatus},
          { name => name == "ddlAssetType", AssetType},
          { name => name == "ddlOrganization", Organization},
          { name => name == "ddlRace", Race},
          { name => name == "ddlGender", Gender},
          { name => name == "ddlEthnicity", Ethnicity},
          { name => name == "ddlAgeRange", AgeRange},
          { name => name == "ddlRole", Role}
        };

        /// <summary>
        /// Provide a list of datatables to call a method to bind them to a datatable
        /// </summary>
        /// <param name="ddls">List of the DDLs to bind</param>
        /// <param name="makeID">Optional parameter for Make where a model is already chosen to filter items put into list</param>
        /// <returns>A list of the data tables used for binding. Index should match the order of ddls in list.</returns>
        public static DataSet Bind(List<DropDownList> ddls, int makeID = -1)
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

        private static DataTable Organization(DropDownList ddl)
        {
            DataTable orgDT = new GetAllOrgs().ExecuteCommand();
            orgDT.TableName = "Org";
            ddl.DataSource = orgDT;
            ddl.DataTextField = "OrgName";
            ddl.DataValueField = "OrgID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("Not Listed", "-1"));

            return orgDT;
        }

        private static DataTable RecycleOrg(DropDownList ddl)
        {
            DataTable orgDT = new GetAllRecycleOrg().ExecuteCommand();
            orgDT.TableName = "RecycleOrg";
            ddl.DataSource = orgDT;
            ddl.DataTextField = "RecycleOrgName";
            ddl.DataValueField = "RecycleOrgID";
            ddl.DataBind();
            return orgDT;
        }

        private static DataTable RequestStatus(DropDownList ddl)
        {
            DataTable rsDT = new GetAllRequestStatus().ExecuteCommand();
            rsDT.TableName = "RequestStatus";
            ddl.DataSource = rsDT;
            ddl.DataTextField = "RequestStatus";
            ddl.DataValueField = "RequestStatusID";
            ddl.DataBind();

            return rsDT;
        }
        private static DataTable RecycleStatus(DropDownList ddl)
        {
            DataTable rsDT = new GetAllRecycleStatus().ExecuteCommand();
            rsDT.TableName = "RecycleStatus";
            ddl.DataSource = rsDT;
            ddl.DataTextField = "RecycleStatus";
            ddl.DataValueField = "RecycleStatusID";
            ddl.DataBind();

            return rsDT;
        }

        private static DataTable Race(DropDownList ddl)
        {
            DataTable raceDT = new GetAllRace().ExecuteCommand();
            raceDT.TableName = "Race";
            ddl.DataSource = raceDT;
            ddl.DataTextField = "Race";
            ddl.DataValueField = "RaceID";
            ddl.DataBind();

            return raceDT;
        }

        private static DataTable Gender(DropDownList ddl)
        {
            DataTable genderDT = new GetAllGender().ExecuteCommand();
            genderDT.TableName = "Gender";
            ddl.DataSource = genderDT;
            ddl.DataTextField = "Gender";
            ddl.DataValueField = "GenderID";
            ddl.DataBind();

            return genderDT;
        }

        private static DataTable Ethnicity(DropDownList ddl)
        {
            DataTable ethnicityDT = new GetAllEthnicity().ExecuteCommand();
            ethnicityDT.TableName = "Ethnicity";
            ddl.DataSource = ethnicityDT;
            ddl.DataTextField = "Ethnicity";
            ddl.DataValueField = "EthnicityID";
            ddl.DataBind();

            return ethnicityDT;
        }

        private static DataTable AgeRange(DropDownList ddl)
        {
            DataTable ageDT = new GetAllAgeRange().ExecuteCommand();
            ageDT.TableName = "AgeRange";
            ddl.DataSource = ageDT;
            ddl.DataTextField = "Description";
            ddl.DataValueField = "AgeRangeID";
            ddl.DataBind();

            return ageDT;
        }

        private static DataTable Role(DropDownList ddl)
        {
            DataTable roleDT = new GetRoles().ExecuteCommand();
            roleDT.TableName = "Role";
            ddl.DataSource = roleDT;
            ddl.DataTextField = "Role";
            ddl.DataValueField = "RoleID";
            ddl.DataBind();

            return roleDT;
        }
    }



}