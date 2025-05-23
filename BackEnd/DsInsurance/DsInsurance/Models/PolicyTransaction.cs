﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DsInsurance.Models
{
    public class PolicyTransaction
    {
        [Key]
        public Guid TransactionId { get; set; }

        [ForeignKey("User")]
        public Guid? UserId { get; set; }

        [ForeignKey("PolicyAccount")]
        public Guid PolicyNo { get; set; }

        [ForeignKey("Installment")]
        public Guid? InstallmentId { get; set; }

        public string? PaymentMethod { get; set; }

        [Required]
        public string TransactionType { get; set; } // Enum: Issuance, Renewal, Cancellation, Refund

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public decimal Amount { get; set; }

        // Information Related to Policy Transaction 
        public string? Description { get; set; }

        public string? Status { get; set; }

        // Navigation Properties
        public PolicyAccount? PolicyAccount { get; set; }
    }
}
