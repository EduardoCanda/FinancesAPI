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
            CreatedDate = DateTime.Now;
            UpdatedDate = null;
        }

        [Key]
        public int Id { get; set;}

        [Required(ErrorMessage = "A categoria é obrigatória")]
        public ECategory Category { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório")]
        public decimal Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

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