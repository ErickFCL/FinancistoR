using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancistoR.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Type { get; set; }
        //[MinLength(10)]
        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        public string Name { get; set; }
        public string Currency { get; set; }
        [Required]
        public decimal Amount { get; set; }

    }
}
