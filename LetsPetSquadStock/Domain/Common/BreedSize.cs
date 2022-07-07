using System;
using System.ComponentModel;

namespace Stock.Domain.Common
{
    public enum BreedSize
    {
        [Description("Pequeno")]
        Small = 1,
        [Description("Grande")]
        Big = 2,
    }
}
