using AutoMapper;
using BusinessLogicLayer.Models;
using BusinessLogicLayer.Models.Response;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities.Avrora37;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class EmployeeSalaryService : IEmployeeSalaryService
    {
        private readonly IEmployeeSalaryRepository _employeeSalaryRepository;
        private readonly IMapper _mapper;
        public EmployeeSalaryService(IEmployeeSalaryRepository employeeSalaryRepository, IMapper mapper)
        {
            _employeeSalaryRepository = employeeSalaryRepository;
            _mapper = mapper;
        }   

        public async Task<EmployeeSalaryResponseModel> getEmployeeSalary(int stockId, DateTime datetime)
        {
            EmployeeSalaryResponseModel employeeSalaryResponseModel = new EmployeeSalaryResponseModel();

            List<EmployeeSalary> employeeSalaries = await _employeeSalaryRepository.getEmployeeSalary(stockId, datetime);

            if (employeeSalaries.Count == 0)
            {
                employeeSalaryResponseModel.NumberStore = stockId;
                return employeeSalaryResponseModel;
            }

            if (employeeSalaries.Count != 0)
            {
                employeeSalaryResponseModel.NumberStore = employeeSalaries[0].NumberStore;
                employeeSalaryResponseModel.SalesStore = String.Format("{0:0.00}", employeeSalaries[0].SalesStore);
                employeeSalaryResponseModel.HoursWorkedStore = String.Format("{0:0.00}", employeeSalaries[0].HoursWorkedStore);
                employeeSalaryResponseModel.RatioPerHour = String.Format("{0:0.000}", employeeSalaries[0].RatioPerHour);
                employeeSalaryResponseModel.BonusStore = String.Format("{0:0.00}", employeeSalaries[0].BonusStore);

                employeeSalaryResponseModel.employeeSalaries = _mapper.Map<List<EmployeeSalary>, List<EmployeeSalaryModel>>(employeeSalaries);

                foreach (EmployeeSalaryModel employeeSalaryModel in employeeSalaryResponseModel.employeeSalaries)
                {
                    employeeSalaryModel.HourlyRate = String.Format("{0:0.00}", Decimal.Parse(employeeSalaryModel.HourlyRate));
                    employeeSalaryModel.WorkedOut = String.Format("{0:0.00}", Decimal.Parse(employeeSalaryModel.WorkedOut));
                    employeeSalaryModel.TotalRate = String.Format("{0:0.00}", Decimal.Parse(employeeSalaryModel.TotalRate));
                    employeeSalaryModel.BonusSales = String.Format("{0:0.00}", Decimal.Parse(employeeSalaryModel.BonusSales));
                    employeeSalaryModel.TotalSalary = String.Format("{0:0.00}", Decimal.Parse(employeeSalaryModel.TotalSalary));
                }
            }
            return employeeSalaryResponseModel;
        }
    }
}
