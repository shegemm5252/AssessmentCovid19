using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsessmentApiCovid.Data.Context;
using AsessmentApiCovid.DTO;
using AsessmentApiCovid.Services;
using AsessmentApiCovid.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AsessmentApiCovid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidTrackerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWrappers _wrapper;
        private readonly Core _Core;

        public CovidTrackerController(IConfiguration configuration, IWrappers wrapper){
            _configuration = configuration;
            _wrapper = wrapper;
            _Core = new Core(_wrapper, _configuration);
        }


        [HttpGet]
        [Route("SummaryForFirstDose")]
        public Task<Responses<object>> SummaryFirstDose(string code)
        {
            return _Core.SummaryFirstDose(code);
        }

        [HttpGet]
        [Route("SummaryDailyFirstDose")]
        public Task<Responses<object>> SummaryDailyFirstDose(string code,DateTime date)
        {
            return _Core.SummaryDailyFirstDose(code, date);
        }

        [HttpGet]
        [Route("SummaryDailySecondDose")]
        public Task<Responses<object>> SummaryDailySecondDose(string code,DateTime date)
        {
            return _Core.SummaryDailySecondDose(code, date);
        }

        [HttpGet]
        [Route("SummaryMonthFirstDose")]
        public Task<Responses<object>> SummaryMonthFirstDose(int year, int month)
        {
            return _Core.SummaryMonthFirstDose(month, year);
        }

        [HttpGet]
        [Route("SummaryMonthSecondDose")]
        public Task<Responses<object>> SummaryMonthSecondDose(int year, int month)
        {
            return _Core.SummaryMonthSecondDose(month, year);
        }

        [HttpGet]
        [Route("SummaryForSecondDose")]
        public Task<Responses<object>> SummarySecondDose(string code)
        {
            return _Core.SummarySecondDose(code);
        }


        [HttpGet]
        [Route("SummaryForFirstnationDose")]
        public Task<Responses<object>> SummaryFirstNationDose(string AreaCode)
        {
            return _Core.SummaryFirstDoseByNation(AreaCode);
        }

        [HttpGet]
        [Route("SummaryForSecondnationDose")]
        public Task<Responses<object>> SummaryForSecondnationDose(string AreaCode)
        {
            return _Core.SummarySecondDoseByNation(AreaCode);
        }

        [HttpGet]
        [Route("SecondDose")]
        public Task<Responses<object>> SecondDose()
        {
            return _Core.ListSecondDose();
        }

        [HttpGet]
        [Route("SummarySecondDoseMonth")]
        public Task<Responses<object>> SummarySecondDoseMonth(string code, DateTime date)
        {
            return _Core.SummarySecondDoseMonth(code, date);
        }

        [HttpGet]
        [Route("SummaryFirstDoseMonth")]
        public Task<Responses<object>> SummaryFirstDoseMonth(string code, DateTime date)
        {
            return _Core.SummaryFirstDoseMonth(code, date);
        }

        //[HttpGet]
        //[Route("SecondDose")]
        //public Task<Responses<object>> SecondDose()
        //{
        //    return _Core.ListSecondDose();
        //}

        [HttpGet]
        [Route("FirstDose")]
        public Task<Responses<object>> FirstDose()
        {
            return _Core.ListFirstDose();
        }

        [HttpGet]
        [Route("GetNation")]
        public Task<Responses<List<Nation>>> GetArea()
        {
            return _Core.Nation();
        }


        [HttpGet]
        [Route("GetVaccinatedDataFirsDose")]
        public async Task<Responses<List<VaccinatedData>>> vaccinatedDataFirstDose(string code)
        {
            return await _Core.VaccinatedFirstByNation(code);
        }

        [HttpGet]
        [Route("GetVaccinatedDataSecondDose")]
        public async Task<Responses<List<VaccinatedData>>> vaccinatedDataSecondDose(string code)
        {
            return await _Core.VaccinatedSecondByNation(code);
        }

        [HttpGet]
        [Route("GetSummaryVaccinatedDataFirstDose")]
        public async Task<Responses<object>> SummaryVaccinatedDatafirstDose(string code)
        {
            return await _Core.SummaryFirstDose(code);
        }

        [HttpGet]
        [Route("GetSummaryVaccinatedDataSecondDose")]
        public async Task<Responses<object>> SummaryVaccinatedDataSecondDose(string code)
        {
            return await _Core.SummarySecondDose(code);
        }
    }
}