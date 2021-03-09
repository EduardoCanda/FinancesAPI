using System;
using System.ComponentModel.DataAnnotations;
using FinancesAPI.Models.Enums;

namespace FinancesAPI.Models
{
    public class Finance
    {
        public Finance(ECategory category, decimal value, DateTime date)
        {
            Category = category;
            Value = value;
            Date = date;
        }

        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "A categoria é obrigatória")]
        public ECategory Category { get; set; }
        
        [Required(ErrorMessage = "O valor é obrigatório")]
        public decimal Value { get; set; }
        public DateTime Date { get; set; }

    }
}