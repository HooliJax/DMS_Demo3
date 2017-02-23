using System.ComponentModel.DataAnnotations;
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace testDMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DONATION
    {
        public int DonationId { get; set; }
        public int DonorId { get; set; }
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        [Display(Name = "Type")]
        public string TypeOf { get; set; }
        [Display(Name = "Received")]
        public System.DateTime DateRecieved { get; set; }
        [Display(Name = "Method")]
        public string GiftMethod { get; set; }
        [Display(Name = "Date Made")]
        public System.DateTime DateGiftMade { get; set; }
        public Nullable<int> CodeId { get; set; }
        public byte[] ImageUpload { get; set; }
        [Display(Name = "Restrictions")]
        public string GiftRestrictions { get; set; }
        public string NOTES { get; set; }
    
        public virtual CODE CODE { get; set; }
        public virtual DONOR DONOR { get; set; }
    }
}
