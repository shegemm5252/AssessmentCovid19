using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public Task<Responses<object>> SummaryFirstDose(){
            return _Core.SummaryFirstDose();
        }

        [HttpGet]
        [Route("SummaryDailyFirstDose")]
        public Task<Responses<object>> SummaryDailyFirstDose(DateTime date)
        {
            return _Core.SummaryDailyFirstDose(date);
        }

        [HttpGet]
        [Route("SummaryDailySecondDose")]
        public Task<Responses<object>> SummaryDailySecondDose(DateTime date)
        {
            return _Core.SummaryDailySecondDose(date);
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
        public Task<Responses<object>> SummarySecondDose()
        {
            return _Core.SummarySecondDose();
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
        [Route("FirstDose")]
        public Task<Responses<object>> FirstDose()
        {
            return _Core.ListFirstDose();
        }

        [HttpGet]
        [Route("GetArea")]
        public Task<Responses<object>> GetArea()
        {
            return _Core.GetArea();
        }
    }
}