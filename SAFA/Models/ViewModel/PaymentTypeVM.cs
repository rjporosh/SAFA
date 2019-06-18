﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAFA.Models.ViewModel
{
    public class PaymentTypeVM
    {
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public bool IsActive { get; set; }

        public virtual Administrator Administrator { get; set; }
        public virtual Administrator Administrator1 { get; set; }
    }
}