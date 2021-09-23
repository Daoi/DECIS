using DECIS.DataModels;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.PersonView
{
    public class CreatePerson
    {
        public static Person Create(Page pg, int PersonID)
        {
            
            
            Person p = new Person()
            {
                PersonID = PersonID,
                FirstName = (FindControl.Find("tbFirstName", pg) as TextBox).Text,
                LastName = (FindControl.Find("tbLastName", pg) as TextBox).Text,
                Phone = (FindControl.Find("tbPhone", pg) as TextBox).Text,
                Email = (FindControl.Find("tbEmail", pg) as TextBox).Text,
                ZipCode = (FindControl.Find("tbZipcode", pg) as TextBox).Text,
                Race = int.Parse((FindControl.Find("ddlRace", pg) as DropDownList).SelectedValue),
                Gender = int.Parse((FindControl.Find("ddlRace", pg) as DropDownList).SelectedValue),
                Ethnicity = int.Parse((FindControl.Find("ddlRace", pg) as DropDownList).SelectedValue),
                AgeRangeID = int.Parse((FindControl.Find("ddlAgeRange", pg) as DropDownList).SelectedValue),
                HSStudent = int.Parse((FindControl.Find("tbHSStudent", pg) as TextBox).Text),
                K8Student = int.Parse((FindControl.Find("tbK8", pg) as TextBox).Text),
                Preschool = int.Parse((FindControl.Find("tbPreschool", pg) as TextBox).Text),
                Adult = int.Parse((FindControl.Find("tbAdult", pg) as TextBox).Text),
            };

            p.HouseholdSize = p.Adult + p.HSStudent + p.K8Student + p.Preschool;

            return p;
        }
    }
}