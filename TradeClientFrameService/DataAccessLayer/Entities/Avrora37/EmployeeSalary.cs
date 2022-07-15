using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Entities.Avrora37
{
    [Keyless]
    public class EmployeeSalary
    {
        [Column("Магазин")]
        public int NumberStore { get; set; }
        [Column("Продажі по магазину, грн")]
        public decimal SalesStore { get; set; }
        [Column("Премія по магазину, грн")]
        public decimal BonusStore { get; set; }
        [Column("Відпрацьовані години по магазину, грн")]
        public decimal HoursWorkedStore { get; set; }
        [Column("Коефіцієнт за годину, грн")]
        public decimal RatioPerHour { get; set; }
        [Column("Код Службовця")]
        public int CodeEmployee { get; set; }
        [Column("ПІБ Службовця")]
        public string NameEmployee { get; set; }
        [Column("Посада")]
        public string Position { get; set; }     
        [Column("Ставка за годину, грн")]
        public decimal HourlyRate { get; set; }
        [Column("Відпрацьовано, год")]
        public decimal WorkedOut { get; set; }
        [Column("Ставка, грн")]
        public decimal TotalRate { get; set; }
        [Column("Премія від продажу, грн")]
        public decimal BonusSales { get; set; }
        [Column("Загальна зарплата, грн")]
        public decimal TotalSalary { get; set; }
    }
}
