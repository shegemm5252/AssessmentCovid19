using AsessmentApiCovid.Data;
using AsessmentApiCovid.Data.Context;
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

        public async Task<Responses<object>> SummaryDailyFirstDose(string code, DateTime date)
        {
            var item = _wrapper.VaccinatedFirstDose.FindByConditionAsync(x => DateTime.Parse(x.date).Date == date && x.areaCode.Equals(code)).FirstOrDefault();

            if (item != null)
            {
                return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", new { FirstDoseSummary = item.cumPeopleVaccinatedFirstDoseByPublishDate });
            }
            else
            {
                return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", new { FirstDoseSummary = 0 });
            }


        }

        public async Task<Responses<object>> SummaryDailySecondDose(string code, DateTime date)
        {
            var item = _wrapper.VaccinatedSecondDoseData.FindByConditionAsync(x => DateTime.Parse(x.date).Date == date && x.areaCode.Equals(code)).FirstOrDefault();

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

            return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", new { FirstDoseSummary = total });
        }

        public async Task<Responses<object>> SummaryFirstDoseByNation(string nationID)
        {
            var list = _wrapper.VaccinatedFirstDoseNation.FindByConditionAsync(x => x.areaCode.Equals(nationID)).ToList();

            int total = 0;
            foreach (var item in list)
            {
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

        public async Task<Responses<List<Nation>>> Nation()
        {
            var list = _wrapper.VaccinatedNation.GetAll();

            return Responses<List<Nation>>.GetResponses("00", "Success", "Fetch Successfully", list);
        }

        public async Task<Responses<List<VaccinatedData>>> VaccinatedFirstByNation(string code)
        {
            var list = _wrapper.VaccinatedFirstDose.FindByConditionAsync(x => x.areaCode.Equals(code)).ToList();

            return Responses<List<VaccinatedData>>.GetResponses("00", "Success", "Fetch Successfully", list);
        }

        public async Task<Responses<List<VaccinatedData>>> VaccinatedSecondByNation(string code)
        {
            var list = _wrapper.VaccinatedSecondDose.FindByConditionAsync(x => x.areaCode.Equals(code)).ToList();

            return Responses<List<VaccinatedData>>.GetResponses("00", "Success", "Fetch Successfully", list);
        }


        public async Task<Responses<object>> SummaryFirstDose(string code)
        {
            var summaryList = (await VaccinatedFirstByNation(code)).Detail;

            int total = 0;
            foreach (var item in summaryList)
            {
                total += item.cumPeopleVaccinatedFirstDoseByPublishDate??0;
            }

            return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", new { FirstDoseSummary = total });
        }

        public async Task<Responses<object>> SummaryFirstDoseMonth(string code, DateTime date)
        {
            var summaryList = _wrapper.VaccinatedFirstDose.FindByConditionAsync(x => x.areaCode.Equals(code)).ToList();

            var data = summaryList.Where(x => DateTime.Parse(x.date).Month == date.Month).ToList();

            int total = 0;

            foreach (var item in data)
            {
                total += item.cumPeopleVaccinatedFirstDoseByPublishDate ?? 0;
            }

            return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", new { FirstDoseSummary = total });
        }

        public async Task<Responses<object>> SummarySecondDoseMonth(string code, DateTime date)
        {
            var summaryList = _wrapper.VaccinatedSecondDose.FindByConditionAsync(x => x.areaCode.Equals(code)).ToList();
            

            var data = summaryList.Where(x => DateTime.Parse(x.date).Month == date.Month).ToList();

            int total = 0;
            foreach (var item in data)
            {
                total += item.cumPeopleVaccinatedSecondDoseByPublishDate ?? 0;
            }

            return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", new { SecondDoseSummary = total });

            
        }

        public async Task<Responses<object>> SummarySecondDose(string code)
        {
            var summaryList = (await VaccinatedSecondByNation(code)).Detail;

            int total = 0;
            foreach (var item in summaryList)
            {
                total += item.cumPeopleVaccinatedSecondDoseByPublishDate??0;
            }

            return Responses<object>.GetResponses("00", "Success", "Fetch Successfully", new { SecondDoseSummary = total });
        }


    }
}
