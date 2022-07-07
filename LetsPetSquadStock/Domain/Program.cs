using Stock.Domain;
using Stock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain
{
    public class Program
    {
        public static void Main()
        {
            Stock storage = new();
            Reports reports = new(storage);
            ProductRegistration registry = new ProductRegistration(storage);
            //ProductInUse productInUse = new();
            ProductMenu productMenu = new ProductMenu(storage, reports, registry/*, productInUse*/);
            /* Testes de produtos e serviços */
            productMenu.TestCreatedStock();
            Service servico = new Service(Species.Dog, BreedSize.Big, Usage.General, true, ServiceType.Banho);
            ProductInUse.ExpendProductAfterService(servico, storage);
            productMenu.PrintOpenProducts();
            /*----------------------------- */

            productMenu.BeginProgram();
        }
    }
}

