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
    
    public partial class LoginDetail
    {
        public int UserId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public Nullable<int> BranchId { get; set; }
        public System.DateTime LastLoginDate { get; set; }
        public System.DateTime LastLoginTime { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime LastLoginUpdatedDate { get; set; }
        public System.DateTime LastLoginUpdatedTime { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
