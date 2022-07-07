using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain
{
   public class Consumption
    {
        private int newCurrentVolume;
        public virtual int ReturnNewVolume(Service currentService)
        {
            return newCurrentVolume;
        }
    }
}
