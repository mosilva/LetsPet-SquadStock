using Stock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain
{
    public static class DogConditionerConsumption
    {
        public static int newCurrentVolume;
        public static int VolumeSpentOnService(Service currentService)
        {
            int comsuption = 0;

            if (currentService.usage == Usage.General) //Condicionador Comum
            {
                if (currentService.breedSize == BreedSize.Big)
                {
                    comsuption = 50;
                }

                else if (currentService.breedSize == BreedSize.Small)
                {
                    comsuption = 25;
                }
            }
            else if (currentService.usage == Usage.Special) //Condicionador Especial
            {

                if (currentService.breedSize == BreedSize.Big)
                {
                    comsuption = 20;
                }

                else if (currentService.breedSize == BreedSize.Small)
                {
                    comsuption = 10;
                }
            }

            return comsuption;
           
        }
    }
}
