using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommercialApp.Models
{
    [Table("Singular")]
    public sealed class Singular : People
    {
        public int SingularId { get; set; }
        [Required(ErrorMessage = "Fiscal number is required.")]
        [RegularExpression(@"^[0-9]{9,20}$", ErrorMessage = "A fiscal number is required. It must be 20 characters max")]
        public string NIF { get; init; }

        public IEnumerable<Transaction> Purchases { get; set; }

        public string GetIdentificationNumber()
        {
            return NIF;
        }
    }
}
