using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommercialApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }

        [Required(ErrorMessage = "A name is required.")]
        [RegularExpression(@"^[a-zA-Z0-9_ ]{5,100}$", ErrorMessage = "Can only contain letters nad numbers.It must be between 5 and 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A description is required.")]
        [RegularExpression(@"^[a-zA-Z0-9_ ]{5,200}$", ErrorMessage = "Can only contain letters nad numbers.It must be between 4 and 200 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A price is required")]
        public decimal UnitPrice { get; set; }

        public int TaxRate { get; set; }
        [Required(ErrorMessage = "A picture of the product is required")]
        public byte[] Image { get; set; }


        public ICollection<TransactionDetail>? TransactionDetails { get; set; }

        public decimal GetPriceWithTax() 
        {
            decimal priceWithTax = (UnitPrice + ((TaxRate * UnitPrice) / 100));

            return priceWithTax;
        }
    }
}
