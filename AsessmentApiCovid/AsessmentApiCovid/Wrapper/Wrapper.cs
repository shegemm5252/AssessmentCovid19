using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsessmentApiCovid.Data;
using AsessmentApiCovid.Wrapper.Base;
using AsessmentApiCovid.Wrapper.Interface;

namespace AsessmentApiCovid.Wrapper
{
    public class Wrappers : IWrappers
    {
        private ApplicationDbContext _context;

        IRepositoryVaccinatedAreaWrapper _VaccinatedArea;

        IRepositoryVaccinatedFirstDoseDataWrapper _VaccinatedFirstDoseData;

        IRepositoryVaccinatedFirstDoseNationWrapper _VaccinatedFirstDoseNation;

        IRepositoryVaccinatedSecondDoseDataWrapper _VaccinatedSecondDoseData;

        IRepositoryVaccinatedSecondDoseNationWrapper _VaccinatedSecondDoseNation;
        IRepositoryNationWrapper _Nation;

        IRepositoryVaccinatedFirstDoseWrapper _VaccinationFirstDose;
        IRepositoryVaccinatedSecondDoseWrapper _VaccinationSecondDose;

        public Wrappers(ApplicationDbContext context)
        {
            _context = context;
        }
        public IRepositoryVaccinatedAreaWrapper VaccinatedArea {
            get {
                if(_VaccinatedArea == null){

                    _VaccinatedArea = new VaccinatedAreaBase(_context);
                }

                return _VaccinatedArea;
            }
            
            
        }

        public IRepositoryVaccinatedFirstDoseDataWrapper VaccinatedFirstDoseData
        {
            get
            {
                if (_VaccinatedFirstDoseData == null)
                {

                    _VaccinatedFirstDoseData = new VaccinatedFirstDoseDataBase(_context);
                }

                return _VaccinatedFirstDoseData;
            }


        }
        public IRepositoryVaccinatedFirstDoseNationWrapper VaccinatedFirstDoseNation
        {
            get
            {
                if (_VaccinatedFirstDoseNation == null)
                {

                    _VaccinatedFirstDoseNation = new VaccinatedFirstDoseNationBase(_context);
                }

                return _VaccinatedFirstDoseNation;
            }


        }
        public IRepositoryVaccinatedSecondDoseDataWrapper VaccinatedSecondDoseData
        {
            get
            {
                if (_VaccinatedSecondDoseData == null)
                {

                    _VaccinatedSecondDoseData = new VaccinatedSecondDoseDataBase(_context);
                }

                return _VaccinatedSecondDoseData;
            }


        }

        public IRepositoryVaccinatedSecondDoseNationWrapper VaccinatedSecondDoseNation
        {
            get
            {
                if (_VaccinatedSecondDoseNation == null)
                {

                    _VaccinatedSecondDoseNation = new VaccinatedSecondDoseNationBase(_context);
                }

                return _VaccinatedSecondDoseNation;
            }


        }

        public IRepositoryNationWrapper VaccinatedNation
        {
            get
            {
                if (_Nation == null)
                {

                    _Nation = new NationBase(_context);
                }

                return _Nation;
            }


        }

        public IRepositoryVaccinatedFirstDoseWrapper VaccinatedFirstDose
        {
            get
            {
                if (_VaccinationFirstDose == null)
                {

                    _VaccinationFirstDose = new VaccinatedFirstDoseBase(_context);
                }

                return _VaccinationFirstDose;
            }


        }

        public IRepositoryVaccinatedSecondDoseWrapper VaccinatedSecondDose
        {
            get
            {
                if (_VaccinationSecondDose == null)
                {

                    _VaccinationSecondDose = new VaccinatedSecondDoseBase(_context);
                }

                return _VaccinationSecondDose;
            }


        }

    }
}
