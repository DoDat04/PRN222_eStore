﻿using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Product
{
    public int ProductId { get; set; }

    public int? CategoryId { get; set; }

    public string? ProductName { get; set; }

    public string? Weight { get; set; }

    public decimal? UnitPrice { get; set; }

    public int UnitsInStock { get; set; }

    public string? ImageUrl { get; set; }

    public double Discount { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
