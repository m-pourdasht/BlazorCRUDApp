using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BlazorCRUDApp.Shared.Shared
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [DefaultValue(0.0)]
        public decimal Price { get; set; }
        public int CategoryId{ get; set; }
        public Category? Category { get; set; }
    }
}
