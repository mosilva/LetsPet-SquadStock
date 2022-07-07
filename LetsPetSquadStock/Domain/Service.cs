using Stock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain
{
    public class Service
    {
        public Species species { get; set; }//*
        public BreedSize breedSize { get; set; }//*
        public Usage usage { get; set; }
        public bool Lotion { get; set; }
        public ServiceType serviceType { get; set; }

        public Service()
        {

        }

        public Service(Species species, BreedSize breedSize, Usage usage, bool lotion, ServiceType serviceType)
        {
            this.species = species;
            this.breedSize = breedSize;
            this.usage = usage;
            this.Lotion = lotion;
            this.serviceType = serviceType;
        }
    }
}
