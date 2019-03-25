using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class OrderLog
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public string LogText { get; set; }

        public virtual Order Order { get; set; }
    }
}
