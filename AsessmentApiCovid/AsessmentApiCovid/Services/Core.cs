using AsessmentApiCovid.Data;
using AsessmentApiCovid.DTO;
using AsessmentApiCovid.IServices;
using AsessmentApiCovid.Wrapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsessmentApiCovid.Services
{
    public class Core : ICore
    {
        
        IWrappers _wrapper;
      
        
        private IConfiguration _config;
        public Core(IWrappers wrapper, IConfiguration config)
        {
            _wrapper = wrapper;
            _config = config;
        }

        public async Task<Responses<object>> GetArea()
        {
            var area = _wrapper.VaccinatedArea.GetAll();

            return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", area); 
        }

        public async Task<Responses<object>> ListFirstDose()
        {
            var list = _wrapper.VaccinatedFirstDoseData.GetAll();

            return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", list); 
        }

        public async Task<Responses<object>> ListSecondDose()
        {
            var list = _wrapper.VaccinatedSecondDoseData.GetAll();

            return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", list);
        }

        public async Task<Responses<object>> SummaryDailyFirstDose(DateTime date)
        {
            var item = _wrapper.VaccinatedFirstDoseData.FindByConditionAsync(x => DateTime.Parse(x.date).Date == date).FirstOrDefault();

           if(item !=  null){
                return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", new { FirstDoseSummary = item.cumPeopleVaccinatedFirstDoseByPublishDate });
            } else {
                return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", new { FirstDoseSummary = 0 });
            }

           
        }

        public async Task<Responses<object>> SummaryDailySecondDose(DateTime date)
        {
            var item = _wrapper.VaccinatedSecondDoseData.FindByConditionAsync(x => DateTime.Parse(x.date).Date == date).FirstOrDefault();

            if (item != null)
            {
                return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", new { SecondDoseSummary = item.cumPeopleVaccinatedSecondDoseByPublishDate });
            }
            else
            {
                return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", new { SecondDoseSummary = 0 });
            }
        }

        public async Task<Responses<object>> SummaryFirstDose()
        {

            var summaryList = _wrapper.VaccinatedFirstDoseData.GetAll();

            int total = 0;
            foreach (var item in summaryList)
            {
                total += item.cumPeopleVaccinatedFirstDoseByPublishDate;
            }

            return  Responses<object>.GetResponses("00", "Success", "Fetch Successfully", new { FirstDoseSummary = total }); 
        }

        public async Task<Responses<object>> SummaryFirstDoseByNation(string nationID)
        {
            var list = _wrapper.VaccinatedFirstDoseNation.FindByConditionAsync(x => x.areaCode.Equals(nationID)).ToList();

            int total = 0;
            foreach(var item in list){
                total += item.cumPeopleVaccinatedFirstDoseByPublishDate;
            }

            return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", new { FirstNationDoseSummary = total });
        }

        public async Task<Responses<object>> SummaryMonthFirstDose(int month, int year)
        {
            var list = _wrapper.VaccinatedFirstDoseData.FindByConditionAsync(x => DateTime.Parse(x.date).Month == month && DateTime.Parse(x.date).Year == year).ToList();
            int total = 0;
            foreach (var item in list)
            {
                total += item.cumPeopleVaccinatedFirstDoseByPublishDate;
            }
            return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", new { FirstDoseSummary = total });
        }

        public async Task<Responses<object>> SummaryMonthSecondDose(int month, int year)
        {
            var list = _wrapper.VaccinatedSecondDoseData.FindByConditionAsync(x => DateTime.Parse(x.date).Month == month && DateTime.Parse(x.date).Year == year).ToList();
            int total = 0;
            foreach (var item in list)
            {
                total += item.cumPeopleVaccinatedSecondDoseByPublishDate;
            }
            return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", new { SecondDoseSummary = total });
            
        }

        public async Task<Responses<object>> SummarySecondDose()
        {
            var summaryList = _wrapper.VaccinatedSecondDoseData.GetAll();

            int total = 0;
            foreach (var item in summaryList)
            {
                total += item.cumPeopleVaccinatedSecondDoseByPublishDate;
            }

            return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", new { SecondDoseSummary = total });
        }

        public async Task<Responses<object>> SummarySecondDoseByNation(string nationID)
        {
            var list = _wrapper.VaccinatedSecondDoseNation.FindByConditionAsync(x => x.areaCode.Equals(nationID)).ToList();

            int total = 0;
            foreach (var item in list)
            {
                total += item.cumPeopleVaccinatedSecondDoseByPublishDate;
            }

            return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", new { SecondNationDoseSummary = total });
        }
    }
}
