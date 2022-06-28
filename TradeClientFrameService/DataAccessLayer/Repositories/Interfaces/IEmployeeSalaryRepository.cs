using DataAccessLayer.Entities.Avrora37;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IEmployeeSalaryRepository
    {
        public Task<List<EmployeeSalary>> getEmployeeSalary(int stockId, DateTime dateTime);
    }
}
