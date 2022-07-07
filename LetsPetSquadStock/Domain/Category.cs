using System;
using System.ComponentModel;

namespace Stock.Domain
{
    public enum Category
    {
        [Description("Shampoo")]
        Shampoo,
        [Description("Condicionador")]
        Conditioner,
        [Description("Perfume")]
        Perfume,
    }
}
