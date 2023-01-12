using System.ComponentModel.DataAnnotations;

namespace CommercialApp.Models
{
    public class TransactionDetail
    {
        public int TransactionDetailId { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int TransactionId { get; set; }

        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "UnitPrice is required.")]
        public decimal UnitPrice { get; set; }


    }
}
