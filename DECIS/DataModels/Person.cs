using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DECIS.DataModels
{
    public class Person
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int AgeRange { get; set; }
        public string AgeGroup { get; set; }
        public int Gender { get; set; }
        public int Race { get; set; }
        public int Ethnicity { get; set; }
        public int HouseholdSize { get; set; }
        public int Adult { get; set; }
        public int HSStudent { get; set; }
        public int K8Student { get; set; }
        public int Preschool { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}