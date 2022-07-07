using Stock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain
{
    public static class CatConditionerConsumption
    {
        public static int newCurrentVolume;
        public static int VolumeSpentOnService(Service currentService)
        {
            int comsuption = 0;

            if (currentService.usage == Usage.General) //Condicionador Comum
            {
                comsuption = 15;
            }
            else if (currentService.usage == Usage.Special) //Condicionador Especial
            {
                comsuption = 10;
            }
            else
            {
                comsuption = 0;
            }
            return comsuption;

        }
    }
}
