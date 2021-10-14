using AsessmentApiCovid.Data;
using AsessmentApiCovid.Data.Context;
using AsessmentApiCovid.Repository;
using AsessmentApiCovid.Wrapper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsessmentApiCovid.Wrapper.Base
{
    public class VaccinatedAreaBase : Repository<VaccinatedArea>, IRepositoryVaccinatedAreaWrapper
    {
        public VaccinatedAreaBase(ApplicationDbContext context) : base(context, "VaccinatedArea.json") { }
    }

    public class VaccinatedFirstDoseDataBase : Repository<VaccinatedFirstDoseData>, IRepositoryVaccinatedFirstDoseDataWrapper
    {
        public VaccinatedFirstDoseDataBase(ApplicationDbContext context) : base(context, "VaccinatedFirstDoseData.json") { }
    }

    public class VaccinatedFirstDoseNationBase : Repository<VaccinatedFirstDoseData>, IRepositoryVaccinatedFirstDoseNationWrapper
    {
        public VaccinatedFirstDoseNationBase(ApplicationDbContext context) : base(context, "VaccinatedFirstDoseNation.json") { }
    }

    public class VaccinatedSecondDoseDataBase : Repository<VaccinatedSecondDoseData>, IRepositoryVaccinatedSecondDoseDataWrapper
    {
        public VaccinatedSecondDoseDataBase(ApplicationDbContext context) : base(context, "VaccinatedSecondDoseData.json") { }
    }

    public class VaccinatedSecondDoseNationBase : Repository<VaccinatedSecondDoseData>, IRepositoryVaccinatedSecondDoseNationWrapper
    {
        public VaccinatedSecondDoseNationBase(ApplicationDbContext context) : base(context, "VaccinatedSecondDoseNation.json") { }
    }
}
