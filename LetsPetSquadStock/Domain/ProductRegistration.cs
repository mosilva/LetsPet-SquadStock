using Stock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain
{
    public class ProductRegistration
    {
        private int minAmount = 2;
        private int maxAmount = 20;
        private Stock storage;

        public ProductRegistration(Stock storage)
        {
            this.storage = storage;
        }

        public bool NewProductRegistryValidation()
        {
            Category newProductCategory = InputServices.SelectCategory();
            int allowedQuantity = AllowedQuantityByCategory(newProductCategory);
            if (allowedQuantity > 0)
            {
                int newProductQuantity = InputServices.NewQuantity(allowedQuantity);
                NewProductRegistry(newProductCategory, newProductQuantity);
                return true;
            }
            return false;
        }

        private void AddNewProductToStock(Product newProduct)
        {
            storage.AddToStock(newProduct);
        }

        private int AllowedQuantityByCategory(Category newProductCategory)
        {
            return maxAmount - storage.ProductCategoryQuantity(newProductCategory);
        }

        private void NewProductRegistry(Category newProductCategory, int quantity)
        {
            Usage newProductUsage = InputServices.SelectUsage();
            string newProductName = InputServices.NewName();
            string newProductBrand = InputServices.NewBrand();
            decimal newProductPrice = InputServices.NewPrice();
            int newProductTotalVolume = InputServices.NewTotalVolume();
            DateTime newProductExpirationDate = InputServices.NewExpirationDate();
            Species newProductSpecies = InputServices.SelectSpecies();

            for (int i = 0; i < quantity; i++)
            {
                Product newProduct = new Product(newProductCategory, newProductUsage, newProductName, newProductBrand, newProductPrice,
                                             newProductTotalVolume, newProductExpirationDate, newProductSpecies);
                AddNewProductToStock(newProduct);
            }
            Console.WriteLine(Messages.sucessfullNewProductRegistry);

        }
    }

}

