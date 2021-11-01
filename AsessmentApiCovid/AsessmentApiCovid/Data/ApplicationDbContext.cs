using AsessmentApiCovid.Data.Context;
using AsessmentApiCovid.Data.DBContext;
using AsessmentApiCovid.Data.DBSet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsessmentApiCovid.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DBSet<VaccinatedArea> VaccinatedArea_tbl { get; set; }

        public DBSet<VaccinatedFirstDoseData> VaccinatedFirstDoseData_tbl { get; set; }

        public DBSet<VaccinatedSecondDoseData> VaccinatedSecondDoseData_tbl { get; set; }

        public DBSet<VaccinatedFirstDoseData> VaccinatedFirstDoseNation_tbl { get; set; }

        public DBSet<VaccinatedSecondDoseData> VaccinatedSecondDoseNation_tbl { get; set; }

        public DBSet<VaccinatedData> VaccinatedFirstDose_tbl { get; set; }

        public DBSet<VaccinatedData> VaccinatedSecondDose_tbl { get; set; }

        public DBSet<Nation> Nation_tbl { get; set; }

    }


}
