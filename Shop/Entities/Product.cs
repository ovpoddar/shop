﻿using System.Collections.Generic;

namespace Shop.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public double WholesalePrice { get; set; }
        public double StockLevel { get; set; }
        public double OrderLevel { get; set; }
        public double MinimumWholesaleOrder { get; set; }
        public double BarCode { get; set; }
        public int BrandId { get; set; }
        public int CategoriesId { get; set; }
        public virtual Category Categories { get; set; }
        public virtual Brand Brand { get; set; }
        public List<ProductWholeSale> ProductWholeSales { get; set; }
    }
}
