//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAFA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SMSSetting
    {
        public int SMSSettingsId { get; set; }
        public string MailServer { get; set; }
        public string From { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Port { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
