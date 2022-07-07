using System;
using System.ComponentModel;

namespace Stock.Domain.Common
{
    public enum Species
    {
        [Description("Cachorro")]
        Dog = 1,
        [Description("Gato")]
        Cat = 2,
    }
}
