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
    public class Display
    {
        public static void DisplayPerson(Page pg, Person p)
        {
            (FindControl.Find("tbFirstName" , pg) as TextBox).Text = p.FirstName;
            (FindControl.Find("tbLastName", pg) as TextBox).Text = p.LastName;
            (FindControl.Find("tbPhone", pg) as TextBox).Text = p.Phone;
            (FindControl.Find("tbEmail", pg) as TextBox).Text = p.Email;
            (FindControl.Find("tbZipcode", pg) as TextBox).Text = p.ZipCode;

            (FindControl.Find("ddlRace", pg) as DropDownList).SelectedValue = p.Race.ToString();
            (FindControl.Find("ddlGender", pg) as DropDownList).SelectedValue = p.Gender.ToString();
            (FindControl.Find("ddlEthnicity", pg) as DropDownList).SelectedValue = p.Ethnicity.ToString();
            (FindControl.Find("ddlAgeRange", pg) as DropDownList).SelectedValue = p.AgeRangeID.ToString();

            (FindControl.Find("tbAdult", pg) as TextBox).Text = p.Adult.ToString();
            (FindControl.Find("tbK8", pg) as TextBox).Text = p.K8Student.ToString();
            (FindControl.Find("tbHSStudent", pg) as TextBox).Text = p.HSStudent.ToString();
            (FindControl.Find("tbPreschool", pg) as TextBox).Text = p.Preschool.ToString();

            (FindControl.Find("lblTitle", pg) as Label).Text = $"Person ID: {p.PersonID.ToString()}";


        }
    }
}