using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommercialApp.Models
{
    [Table("Company")]
    public sealed class Company : People
    {
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Fiscal number is required.")]
        [RegularExpression(@"^[0-9]{9,20}$", ErrorMessage = "A fiscal number is required. It must be 20 characters max")]
        public string NIPC { get; init; }        
        
        public IEnumerable<Product>? Products { get; set; }

        public string GetIdentificationNumber()
        {
            return NIPC;
        }
    }
}

