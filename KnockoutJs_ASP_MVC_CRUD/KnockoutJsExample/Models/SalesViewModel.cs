using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KnockoutJsExample.Models
{
        public class SalesViewModel
        {
            public int Id { get; set; }
            public Nullable<int> ProductId { get; set; }
            public Nullable<int> CustomerId { get; set; }
            public Nullable<int> StoreId { get; set; }

            public Nullable<System.DateTime> DateSold { get; set; }
            public string CName { get; set; }
            public string PName { get; set; }
            public string SName { get; set; }
        }
    }