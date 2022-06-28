using BusinessLogicLayer.Models.Response;
using System;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public  interface IEmployeeSalaryService
    {
        public Task<EmployeeSalaryResponseModel> getEmployeeSalary(int stockId, DateTime datetime);
    }
}
