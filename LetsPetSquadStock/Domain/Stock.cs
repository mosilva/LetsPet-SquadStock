using Stock.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Domain
{
    public class Stock
    {
        public List<Product> StoredShampoo { get; private set; } = new();
        public List<Product> StoredCondicionador { get; private set; } = new();
        public List<Product> StoredPerfume { get; private set; } = new();

        public List<Product> GetFullStock()
        {
            List<Product> fullStock = StoredShampoo.Concat(StoredCondicionador).Concat(StoredPerfume).ToList();
            return fullStock;
        }

        public int ProductCategoryQuantity(Category productType)
        {
            switch (productType)
            {
                case Category.Shampoo:
                    return StoredShampoo.Count;
                case Category.Conditioner:
                    return StoredCondicionador.Count;
                case Category.Perfume:
                    return StoredPerfume.Count;
                default:
                    break;
            }
            return 0;
        }

        public void AddToStock(Product newProduct)
        {
            switch (newProduct.Category)
            {
                case Category.Shampoo:
                    StoredShampoo.Add(newProduct);
                    StoredShampoo.Sort((x, y) => x.ExpirationDate.CompareTo(y.ExpirationDate));
                    return;
                case Category.Conditioner:
                    StoredCondicionador.Add(newProduct);
                    StoredCondicionador.Sort((x, y) => x.ExpirationDate.CompareTo(y.ExpirationDate));
                    return;
                case Category.Perfume:
                    StoredPerfume.Add(newProduct);
                    StoredPerfume.Sort((x, y) => x.ExpirationDate.CompareTo(y.ExpirationDate));
                    return;
                default:
                    break;
            }
        }

        public Product ProductRemovalFromStock(int productIndex, Category productType)
        {
            Product newProduct = new();

            switch (productType)
            {
                case Category.Shampoo:                    
                    return StoredShampoo.Pop(productIndex);

                case Category.Conditioner:                    
                    return StoredCondicionador.Pop(productIndex);

                case Category.Perfume:                   
                    return StoredPerfume.Pop(productIndex);

                default:
                    break;
            }
            return newProduct;
        }

        public int SearchWantedProduct(List<Product> CategoryStock, Usage wantedProductUsage, Species wantedProductSpecies)
        {
            int productIndex = -1;

            for (int i = 0; i < CategoryStock.Count; i++)
            {
                var product = CategoryStock[i];
                if (product.Usage == wantedProductUsage && product.Species == wantedProductSpecies)
                {
                    productIndex = i;
                    break;
                }
            }

            return productIndex;
        }

        public Product ValidateProductRemoval(Category wantedProductCategory, Usage wantedProductUsage, Species wantedProductSpecies)
        {
            Product productToOpen = new();
            int productIndex = -1;
            switch (wantedProductCategory)
            {
                case Category.Shampoo:
                    productIndex = SearchWantedProduct(StoredShampoo, wantedProductUsage, wantedProductSpecies);
                    break;

                case Category.Conditioner:
                    productIndex = SearchWantedProduct(StoredCondicionador, wantedProductUsage, wantedProductSpecies);
                    break;

                case Category.Perfume:
                    productIndex = SearchWantedProduct(StoredPerfume, wantedProductUsage, wantedProductSpecies);
                    break;

                default:
                    break;
            }

            if (productIndex == -1)
            {
                Console.WriteLine(Messages.productNotFound);
                return productToOpen;
            }
            productToOpen = ProductRemovalFromStock(productIndex, wantedProductCategory);
            return productToOpen;
        }

    }
}
