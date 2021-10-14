using AsessmentApiCovid.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsessmentApiCovid.IServices
{
    public interface ICore
    {
        public Task<Responses<object>> SummaryFirstDose();

        public Task<Responses<object>> SummaryDailyFirstDose(DateTime date);

        public Task<Responses<object>> SummaryDailySecondDose(DateTime date);

        public Task<Responses<object>> SummaryMonthFirstDose(int month, int year);

        public Task<Responses<object>> SummaryMonthSecondDose(int month, int year);

        public Task<Responses<object>> SummaryFirstDoseByNation(string nationID);

        public Task<Responses<object>> SummarySecondDoseByNation(string nationID);

        public Task<Responses<object>> SummarySecondDose();

        public Task<Responses<object>> ListFirstDose();

        public Task<Responses<object>> ListSecondDose();

        public Task<Responses<object>> GetArea();

    }
}
