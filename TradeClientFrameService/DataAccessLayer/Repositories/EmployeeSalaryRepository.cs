using DataAccessLayer.AppContext;
using DataAccessLayer.Entities.Avrora37;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class EmployeeSalaryRepository : IEmployeeSalaryRepository
    {
        private readonly Avrora37Context _avrora37Context;

        public EmployeeSalaryRepository(Avrora37Context avrora37Context)
        {
            _avrora37Context = avrora37Context;
        }

        public async Task<List<EmployeeSalary>> getEmployeeSalary(int stockId, DateTime dateTime)
        {
            List<EmployeeSalary> employeeSalaries = await _avrora37Context.EmployeeSalary.FromSqlRaw($"exec web.EmployeeSalary_ByShop @Date='{dateTime.Year}{dateTime.Month.ToString("00")}{dateTime.Day.ToString("00")}', @StockID = {stockId}").ToListAsync();

            return employeeSalaries;
        }
    }
}
