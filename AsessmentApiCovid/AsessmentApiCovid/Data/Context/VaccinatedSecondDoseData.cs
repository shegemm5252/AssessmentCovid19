using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsessmentApiCovid.Data.Context
{
    public class VaccinatedSecondDoseData
    {
        public string areaType { get; set; }
        public string areaName { get; set; }
        public string areaCode { get; set; }
        public string date { get; set; }
        public dynamic newPeopleVaccinatedSecondDoseByPublishDate { get; set; }
        public dynamic cumPeopleVaccinatedSecondDoseByPublishDate { get; set; }
    }
}
