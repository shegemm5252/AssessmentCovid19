using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsessmentApiCovid.Data.Context
{
    public class VaccinatedData
    {
        public string areaType { get; set; }
        public string areaName { get; set; }
        public string areaCode { get; set; }
        public string date { get; set; }
        public Nullable<int> newPeopleVaccinatedFirstDoseByPublishDate { get; set; }
        public Nullable<int> cumPeopleVaccinatedFirstDoseByPublishDate { get; set; }
        public Nullable<int> newPeopleVaccinatedSecondDoseByPublishDate { get; set; }
        public Nullable<int> cumPeopleVaccinatedSecondDoseByPublishDate { get; set; }
    }
}
