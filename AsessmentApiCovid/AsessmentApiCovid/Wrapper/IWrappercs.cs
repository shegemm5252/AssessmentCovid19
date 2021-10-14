using AsessmentApiCovid.Wrapper.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsessmentApiCovid.Wrapper
{
   public interface IWrappers
    {
        public IRepositoryVaccinatedAreaWrapper VaccinatedArea { get; }

        public IRepositoryVaccinatedFirstDoseDataWrapper VaccinatedFirstDoseData { get; }

        public IRepositoryVaccinatedFirstDoseNationWrapper VaccinatedFirstDoseNation { get; }

        public IRepositoryVaccinatedSecondDoseDataWrapper VaccinatedSecondDoseData { get; }

        public IRepositoryVaccinatedSecondDoseNationWrapper VaccinatedSecondDoseNation { get; }
    }
}
