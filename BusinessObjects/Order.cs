﻿using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Order
{
    public int OrderId { get; set; }

    public int MemberId { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime? RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public decimal? Freight { get; set; }

    public bool IsPaid { get; set; }

    public DateTime? PaidAt { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
