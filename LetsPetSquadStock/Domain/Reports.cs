using Stock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain
{
    public class Reports
    {
        private Stock storage;
        public Reports(Stock storage)
        {
            this.storage = storage;
        }
        public void StockContentReport()
        {
            if (storage.ProductCategoryQuantity(Category.Shampoo) != 0)
            {
                Console.WriteLine(Messages.listOfProducts + Category.Shampoo.GetDescription() + ":");
                foreach (Product shampoo in storage.StoredShampoo)
                    PrintProduct(shampoo);
            }
            else
                Console.WriteLine(Messages.noProductsAvailable + Category.Shampoo.GetDescription() + ".");

            if (storage.StoredCondicionador.Count != 0)
            {
                Console.WriteLine(Messages.listOfProducts + Category.Conditioner.GetDescription() + ":");
                foreach (Product conditioner in storage.StoredCondicionador)
                    PrintProduct(conditioner);
            }
            else
                Console.WriteLine(Messages.noProductsAvailable + Category.Conditioner.GetDescription() + ".");

            if (storage.StoredPerfume.Count != 0)
            {
                Console.WriteLine(Messages.listOfProducts + Category.Perfume.GetDescription() + ":");
                foreach (Product perfume in storage.StoredPerfume)
                    PrintProduct(perfume);
            }
            else
                Console.WriteLine(Messages.noProductsAvailable + Category.Perfume.GetDescription() + ".");
        }

        public void SearchResultsByType(List<Product> products)
        {
            foreach (Product p in products)
                PrintProduct(p);
        }

        public void SearchResultsByName(string nameInput)
        {
            bool found = false;
            foreach (Product product in storage.GetFullStock())
            {
                if (product.Name.ToLower() == nameInput.ToLower())
                {
                    PrintProduct(product);
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine(Messages.productNotFound);
        }

        public void SearchResultsByBrand(string brandInput)
        {
            bool found = false;
            foreach (Product product in storage.GetFullStock())
            {
                if (product.Brand.ToLower() == brandInput.ToLower())
                {
                    PrintProduct(product);
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine(Messages.productNotFound);
        }

        public void ShowFullStock()
        {
            foreach (Product product in storage.GetFullStock())
                PrintProduct(product);
        }

        public void PrintProduct(Product product)
        {
            Console.WriteLine(@$"Nome: {product.Name}
Marca: {product.Brand}
- Categoria: {product.Category.GetDescription()}
- Espécie: {product.Species.GetDescription()}
- Uso: {product.Usage.GetDescription()}
- Preço: {product.Price.ToString("C2", CultureInfo.CurrentCulture)}
- Volume disponível / Volume total: {product.CurrentVolume}/{product.TotalVolume}
- Data de validade: {product.ExpirationDate.ToString("dd/MM/yyyy")}
------------------------------------------------------------
");
        }

    }
}
