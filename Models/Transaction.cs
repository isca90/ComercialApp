using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommercialApp.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int SingularId { get; set; }
        public Singular? Singular { get; set; }        

        [Required(ErrorMessage = "Date is required.")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; }

        [Required(ErrorMessage = "ChangedBy is required.")]
        public string ChangedBy { get; set; }

        [Required(ErrorMessage = "Total is required.")]
        public decimal Total { get; set; }



        public ICollection<TransactionDetail>? TransactionDetails { get; set; }

    }
}
