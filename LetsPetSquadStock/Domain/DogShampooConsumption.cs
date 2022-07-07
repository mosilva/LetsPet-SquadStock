using Stock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain
{
    public static class DogShampooConsumption
    {
        public static int newCurrentVolume;
        public static int VolumeSpentOnService(Service currentService)
        {
            int comsuption = 0;
            if (currentService.usage == Usage.General) //Shampoo Comum
            {
                if (currentService.breedSize == BreedSize.Big)
                {
                    comsuption = 200;
                }

                else if (currentService.breedSize == BreedSize.Small)
                {
                    comsuption = 100;
                }

            }
            else if (currentService.usage == Usage.Special) //Shampoo Especial
            { 

                if (currentService.breedSize == BreedSize.Big)
                {
                    comsuption = 150;
                }

                else if (currentService.breedSize == BreedSize.Small)
                {
                    comsuption = 75;
                }
            }

            return comsuption;

        }
    }
}
