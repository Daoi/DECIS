using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DECIS.DataModels
{
    [Serializable]
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int AgeRangeID { get; set; }
        public string AgeGroup { get; set; }
        public int Gender { get; set; }
        public string GenderT { get; set; }
        public int Race { get; set; }
        public string RaceT { get; set; }
        public int Ethnicity { get; set; }
        public string EthnicityT { get; set; }
        public int HouseholdSize { get; set; }
        public int Adult { get; set; }
        public int HSStudent { get; set; }
        public int K8Student { get; set; }
        public int Preschool { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<string> Reasons { get; set; }

        public Person()
        { }

        public Person(DataRow dr)
        {
            FullName = dr["Name"].ToString();
            FirstName = dr["Name"].ToString().Split(' ')[0];
            LastName = dr["Name"].ToString().Split(' ')[1];
            AgeRangeID = int.Parse(dr["AgeRange"].ToString());
            AgeGroup = dr["ARDescription"].ToString();
            GenderT = dr["Gender"].ToString();
            RaceT = dr["Race"].ToString();
            EthnicityT = dr["Ethnicity"].ToString();
            HouseholdSize = int.Parse(dr["HouseholdSize"].ToString());
            HSStudent = int.Parse(dr["HSStudent"].ToString());
            Adult = int.Parse(dr["Adult"].ToString());
            Preschool = int.Parse(dr["Preschool"].ToString());
            K8Student = int.Parse(dr["HouseholdSize"].ToString());
            ZipCode = dr["Zipcode"].ToString();
            Phone = dr["Phone"].ToString();
            Email = dr["Email"].ToString();
            Reasons = new List<string>(dr["Reasons"].ToString().Split(','));
        }


    }
   
}