using Stock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain
{
    public static class CatShampooConsumption
    {
        public static int newCurrentVolume;
        public static int VolumeSpentOnService(Service currentService)
        {
            int comsuption;
            if (currentService.usage == Usage.General) //Shampoo Comum
            {
                comsuption= 50;
            }
            else if (currentService.usage == Usage.Special) //Shampoo Especial
            {
                comsuption = 20;
            }
            else
            {
                comsuption = 0;
            }

            
            return comsuption;


        }
    }
}
