using BusinessLogicLayer.Models.Response;
using BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class getEmployeeSalariesController : ControllerBase
    {
        private IEmployeeSalaryService _employeeSalaryService;

        public getEmployeeSalariesController(IEmployeeSalaryService employeeSalaryService)
        {
            _employeeSalaryService = employeeSalaryService;
        }

        [HttpGet]
        public async Task<EmployeeSalaryResponseModel> getEmployeeSalary(int stockId, DateTime date)
        {
            EmployeeSalaryResponseModel employeeSalaryResponseModel = await _employeeSalaryService.getEmployeeSalary(stockId, date);

            return employeeSalaryResponseModel;
        }
    }
}
