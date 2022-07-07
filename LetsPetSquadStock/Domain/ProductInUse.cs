using Stock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain
{
    public static class ProductInUse
    {

        public static List<Product> OpenShampoo { get; private set; } = new();
        public static List<Product> OpenConditioner { get; private set; } = new();
        public static List<Product> OpenPerfume { get; private set; } = new();

        public static void ExpendProductAfterService(Service service, Stock storage)
        {
            #region Serviços de Cachorro
            if (service.species == Species.Dog)
            {
                if (service.serviceType == ServiceType.Banho)
                {
                    //shampoo 
                    ProductInUse.CheckOpenProductShampoo(service, storage);

                    //condicionador 
                    ProductInUse.CheckOpenProductConditioner(service, storage);

                    //Perfume 
                    ProductInUse.CheckOpenProductPerfume(service, storage);
                }

                else if (service.serviceType == ServiceType.Tosa)
                {
                    //Perfume
                    ProductInUse.CheckOpenProductPerfume(service, storage);
                }
                else
                {
                    Console.WriteLine(Messages.serviceNotRegistered);
                }
            }
            #endregion

            #region Serviços de gato
            else if (service.species == Species.Cat)
            {
                if (service.serviceType == ServiceType.Banho)
                {
                    //shampoo 
                    ProductInUse.CheckOpenProductShampoo(service, storage);

                    //condicionador 
                    ProductInUse.CheckOpenProductConditioner(service, storage);

                    //Perfume 
                    ProductInUse.CheckOpenProductPerfume(service, storage);

                }
                else if (service.serviceType == ServiceType.Tosa)
                {
                    //Perfume
                    ProductInUse.CheckOpenProductPerfume(service, storage);

                }
                else
                {
                    Console.WriteLine(Messages.serviceNotRegistered);
                }
            }
            #endregion

            #region Excecao
            else
            {
                Console.WriteLine(Messages.animalNotRegistered);
            }
            #endregion
        }

        public static void CheckOpenProductShampoo(Service service, Stock storage)
        {
            int consumption = (service.species == Species.Dog)? DogShampooConsumption.VolumeSpentOnService(service) : CatShampooConsumption.VolumeSpentOnService(service); 
            if (OpenShampoo.Count > 0)
            {
                for (int i = 0; i < OpenShampoo.Count; i++)
                {
                    if (OpenShampoo[i].Usage == service.usage)
                    {
                        if (OpenShampoo[i].CurrentVolume >= consumption)
                        {
                            Console.WriteLine(Messages.productStock);
                            OpenShampoo[i].CurrentVolume -= consumption;
                        }

                        else
                        {
                            Console.WriteLine(Messages.productNotEnoughStock);
                            consumption -= OpenShampoo[i].CurrentVolume;
                            OpenShampoo.RemoveAt(i);
                            ProductInUse.PopShampooStockToUse(service, storage, consumption);
                        }
                    }
                }
            }
            else
            {
                ProductInUse.PopShampooStockToUse(service, storage, consumption);
            }

        }

        public static void CheckOpenProductConditioner(Service service, Stock storage)
        {
            int consumption = (service.species == Species.Dog) ? DogConditionerConsumption.VolumeSpentOnService(service) : CatConditionerConsumption.VolumeSpentOnService(service);
            if (OpenConditioner.Count > 0)
            {
                for (int i = 0; i < OpenConditioner.Count; i++)
                {
                    if (OpenConditioner[i].Usage == service.usage)
                    {
                        if (OpenConditioner[i].CurrentVolume >= consumption)
                        {
                            Console.WriteLine(Messages.productStock);
                            OpenConditioner[i].CurrentVolume -= consumption;
                        }

                        else
                        {
                            Console.WriteLine(Messages.productNotEnoughStock);
                            consumption -= OpenConditioner[i].CurrentVolume;
                            OpenConditioner.RemoveAt(i);
                            ProductInUse.PopConditionerStockToUse(service, storage, consumption);
                        }
                    }
                }
            }
            else
            {
                ProductInUse.PopConditionerStockToUse(service, storage, consumption);
            }
        }

        public static void CheckOpenProductPerfume(Service service, Stock storage)
        {
            int consumption = 1; // 1 ml
            if (service.Lotion)            {

                if (OpenPerfume.Count != 0)
                {
                    for (int i = 0; i < OpenPerfume.Count; i++)
                    {
                        Console.WriteLine(OpenPerfume.Count);

                        if (OpenPerfume[i].Usage == service.usage)
                        {
                            if (OpenPerfume[i].CurrentVolume >= consumption)
                            {
                                Console.WriteLine(Messages.productStock);
                                OpenPerfume[i].CurrentVolume -= consumption;
                            }

                            else
                            {
                                Console.WriteLine(Messages.productNotEnoughStock);
                                consumption -= OpenPerfume[i].CurrentVolume;
                                OpenPerfume.RemoveAt(i);
                                ProductInUse.PopPerfumeStockToUse(service, storage, consumption);
                            }
                        }

                    }
                }
                else
                {
                    ProductInUse.PopPerfumeStockToUse(service, storage, consumption);
                }
            }
        }

        public static void PopShampooStockToUse(Service service, Stock storage, int consumption)
        {
            int indexStoredShampoo = storage.SearchWantedProduct(storage.StoredShampoo, service.usage, service.species);
            if (indexStoredShampoo >= 0)
            {
                Product product = storage.StoredShampoo[indexStoredShampoo];
                product.CurrentVolume -= consumption;
                OpenShampoo.Add(product);
                storage.ProductRemovalFromStock(indexStoredShampoo, Category.Shampoo);
                Console.WriteLine(Messages.productOpenStock);
            }
            else
            {
                Console.WriteLine(Messages.lackOfProduct);
            }
        }

        public static void PopConditionerStockToUse(Service service, Stock storage, int consumption)
        {
            int indexStoredConditioner = storage.SearchWantedProduct(storage.StoredCondicionador, service.usage, service.species);
            if (indexStoredConditioner >= 0)
            {
                Product product = storage.StoredCondicionador[indexStoredConditioner];
                product.CurrentVolume -= consumption;
                OpenConditioner.Add(product);
                storage.ProductRemovalFromStock(indexStoredConditioner, Category.Conditioner);
                Console.WriteLine(Messages.productOpenStock);
            }
            else
            {
                Console.WriteLine(Messages.lackOfProduct);
            }
        }

        public static void PopPerfumeStockToUse(Service service, Stock storage, int consumption)
        {
            int indexStoredPerfume = storage.SearchWantedProduct(storage.StoredPerfume, service.usage, service.species);
            if (indexStoredPerfume >= 0)
            {
                Product product = storage.StoredPerfume[indexStoredPerfume];
                product.CurrentVolume -= consumption;
                OpenConditioner.Add(product);
                storage.ProductRemovalFromStock(indexStoredPerfume, Category.Perfume);
                Console.WriteLine(Messages.productOpenStock);
            }
            else
            {
                Console.WriteLine(Messages.lackOfProduct);
            }
        }

    }
}
