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
    
    public partial class FILES
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public Nullable<int> DonationId { get; set; }
        public Nullable<int> DonorId { get; set; }
    
        public virtual DONATION DONATION { get; set; }
    }
}
