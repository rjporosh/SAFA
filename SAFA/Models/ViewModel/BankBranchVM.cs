using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAFA.Models.ViewModel
{
    public class BankBranchVM
    {
        public int BankId { get; set; }
        public string BankName { get; set; }
        public Nullable<int> BranchId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}