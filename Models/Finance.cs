using System;
using System.ComponentModel.DataAnnotations;
using FinancesAPI.Models.Enums;

namespace FinancesAPI.Models
{
    public class Finance
    {
        public Finance(ECategory category, decimal value)
        {
            Category = category;
            Value = value;
            Date = DateTime.Now;
        }

        [Key]
        public int Id { get; }

        [Required(ErrorMessage = "A categoria é obrigatória")]
        public ECategory Category { get; private set; }

        [Required(ErrorMessage = "O valor é obrigatório")]
        public decimal Value { get; private set; }
        public DateTime Date { get; }

        public void SetValue(decimal value)
        {
            Value = value;
        }

        public void SetCategory(ECategory category)
        {
            Category = category;
        }

    }
}