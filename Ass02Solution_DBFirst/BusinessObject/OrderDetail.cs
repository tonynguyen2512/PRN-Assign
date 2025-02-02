﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.DataAccess
{
    public partial class OrderDetail
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
