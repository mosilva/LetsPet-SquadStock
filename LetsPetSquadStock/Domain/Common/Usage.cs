using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain.Common
{
    public enum Usage
    {
        [Description("Geral")]
        General,
        [Description("Especial")]
        Special,
    }
}
