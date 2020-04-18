using System;
using System.Collections.Generic;

namespace P4_Projekt.Models
{
    public partial class OrderSubtotals
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
