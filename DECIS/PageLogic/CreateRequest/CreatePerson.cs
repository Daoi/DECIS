using DECIS.DataModels;
using DECIS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DECIS.PageLogic.CreateRequest
{
    public class CreatePerson
    {
        public static Person Create(Page pg)
        {
            string[] fn = (FindControl.FindNM("tbName", pg) as TextBox).Text.Split(' ');
            Person p = new Person()
            {
                FirstName = fn[0],
                LastName = fn[1],
                ZipCode = (FindControl.FindNM("tbZipcode", pg) as TextBox).Text,
                Phone = (FindControl.FindNM("tbPhone", pg) as TextBox).Text,
                Email = (FindControl.FindNM("tbEmail", pg) as TextBox).Text,
                Gender = int.Parse((FindControl.FindNM("ddlGender", pg) as DropDownList).SelectedValue),
                Race = int.Parse((FindControl.FindNM("ddlRace", pg) as DropDownList).SelectedValue),
                Ethnicity = int.Parse((FindControl.FindNM("ddlEthnicity", pg) as DropDownList).SelectedValue),
                Adult = int.Parse((FindControl.FindNM("tbNumOfAdults", pg) as TextBox).Text),
                HSStudent = int.Parse((FindControl.FindNM("tbNumOfHS", pg) as TextBox).Text),
                K8Student = int.Parse((FindControl.FindNM("tbYoungKids", pg) as TextBox).Text),
                Preschool = int.Parse((FindControl.FindNM("tbPreschool", pg) as TextBox).Text),
                AgeRangeID = int.Parse((FindControl.FindNM("ddlAgeRange", pg) as DropDownList).SelectedValue),
            };

            p.HouseholdSize = p.Adult + p.HSStudent + p.K8Student + p.Preschool;

            return p;
        }
    }
}