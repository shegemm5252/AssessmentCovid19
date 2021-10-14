using AsessmentApiCovid.Data.Context;
using AsessmentApiCovid.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsessmentApiCovid.Wrapper.Interface
{
    public interface IRepositoryVaccinatedAreaWrapper: IRepository<VaccinatedArea>
    {
    }

    public interface IRepositoryVaccinatedFirstDoseDataWrapper : IRepository<VaccinatedFirstDoseData>
    {
    }

    public interface IRepositoryVaccinatedFirstDoseNationWrapper : IRepository<VaccinatedFirstDoseData>
    {
    }

    public interface IRepositoryVaccinatedSecondDoseDataWrapper : IRepository<VaccinatedSecondDoseData>
    {
    }

    public interface IRepositoryVaccinatedSecondDoseNationWrapper : IRepository<VaccinatedSecondDoseData>
    {
    }
}
