using System.Collections.Generic;

namespace BusinessLogicLayer.Models.Response
{
    public class EmployeeSalaryResponseModel
    {
        /// <summary>
        /// Магазин
        /// </summary>
        public int NumberStore { get; set; }
        /// <summary>
        /// Продажі по магазину, грн
        /// </summary>
        public string SalesStore { get; set; }
        /// <summary>
        /// Продажі на дату, грн
        /// </summary>
        public string SalesOnDate { get; set; }
        /// <summary>
        /// Премія по магазину, грн
        /// </summary>
        public string BonusStore { get; set; }
        /// <summary>
        /// Відпрацьовані години по магазину, грн
        /// </summary>
        public string HoursWorkedStore { get; set; }
        /// <summary>
        /// Коефіцієнт за годину, грн
        /// </summary>
        public string RatioPerHour { get; set; }
        /// <summary>
        /// Заробітна плата співробітників
        /// </summary>

        public List<EmployeeSalaryModel> employeeSalaries { get; set; }
        public EmployeeSalaryResponseModel()
        {
            employeeSalaries = new List<EmployeeSalaryModel>();
        }
    }
}
