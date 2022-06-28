namespace BusinessLogicLayer.Models
{
    public class EmployeeSalaryModel
    {
        /// <summary>
        /// Код Службовця
        /// </summary>
        public int CodeEmployee { get; set; }
        /// <summary>
        /// ПІБ Службовця
        /// </summary>
        public string NameEmployee { get; set; }
        /// <summary>
        /// Посада
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Ставка за годину, грн
        /// </summary>
        public string HourlyRate { get; set; }
        /// <summary>
        /// Відпрацьовано, год
        /// </summary>
        public string WorkedOut { get; set; }
        /// <summary>
        /// Ставка, грн
        /// </summary>
        public string TotalRate { get; set; }
        /// <summary>
        /// Премія від продажу, грн
        /// </summary>
        public string BonusSales { get; set; }
        /// <summary>
        /// Загальна зарплата, грн
        /// </summary>
        public string TotalSalary { get; set; }
    }
}
