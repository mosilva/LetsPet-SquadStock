using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock.Domain.Common;

namespace Stock.Domain
{
    public class ProductMenu
    {
        private Stock storage;
        private Reports reports;
        private ProductRegistration registry;
        //private ProductInUse productInUse;

        public ProductMenu(Stock storage, Reports reports, ProductRegistration registry/*, ProductInUse productInUse*/)
        {
            this.storage = storage;
            this.registry = registry;
            this.reports = reports;
            /*this.productInUse = productInUse;*/
        }
        public void BeginProgram()
        {
            TestCreatedStock();
            MenuSelection();
        }

        private void RegisterNewProduct()
        {
            Console.Clear();
            Console.WriteLine(Messages.headerNewProductRegistry);
            bool validProductRegistry = false;

            do
            {
                validProductRegistry = registry.NewProductRegistryValidation();

                if (!validProductRegistry)
                {
                    validProductRegistry = InputServices.ReturnSwitch();
                }
            }
            while (!validProductRegistry);

            ReturnProgram();
        }

        private void MenuSelection()
        {
            Console.WriteLine(Messages.headerStock);
            Console.WriteLine(Messages.menuProductTest);
            string userInput = InputServices.UserInput();
            switch (userInput)
            {
                case "1":
                    RegisterNewProduct();
                    ReturnProgram();
                    return;
                case "2":
                    PrintStock();
                    ReturnProgram();
                    return;
                case "3":
                    OpenProduct();
                    ReturnProgram();
                    return;
                case "4":
                    ReportMainMenu();
                    ReturnProgram();
                    return;
                default:
                    Console.Clear();
                    Console.WriteLine(Messages.formatError);
                    MenuSelection();
                    return;
            }
        }

        private void ReturnProgram()
        {
            Console.WriteLine();
            Console.Write(Messages.returnEntryKey);
            Console.ReadKey();
            Console.Clear();
            MenuSelection();
            return;
        }

        public void DefaultMenuStock()
        {
            string userInputType = InputServices.UserInput();
            switch (userInputType)
            {
                case "1":
                    registry.NewProductRegistryValidation();
                    return;
                case "2":
                    //relatorio.MenuDeSelecao();
                    return;
                case "3":
                    //Main();
                    return;
                default:
                    Console.WriteLine(Messages.formatError);
                    DefaultMenuStock();
                    return;
            }
        }

        public void ReportMainMenu()
        {
            Console.Clear();
            Console.WriteLine(Messages.headerNewReport);
            Console.WriteLine(Messages.reportSelectionMenu);
            string userInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInput))
                reports.ShowFullStock();
            else
                switch (userInput)
                {
                    case "1":
                        ReportNameMenu();
                        ReturnProgram();
                        return;
                    case "2":
                        ReportTypeMenu();
                        ReturnProgram();
                        return;
                    case "3":
                        ReportBrandMenu();
                        ReturnProgram();
                        return;
                    default:
                        Console.WriteLine(Messages.formatError);
                        ReportMainMenu();
                        break;
                }
        }

        public void ReportBrandMenu()
        {
            Console.WriteLine(Messages.reportBrandMenu);
            string userInput = InputServices.UserInput();
            reports.SearchResultsByBrand(userInput);
        }

        public void ReportNameMenu()
        {
            Console.WriteLine(Messages.reportNameMenu);
            string userInput = InputServices.UserInput();
            reports.SearchResultsByName(userInput);
        }

        public void ReportTypeMenu()
        {
            Console.WriteLine(Messages.reportTypeMenu);
            string userInput = InputServices.UserInput();
            switch (userInput)
            {
                case "1":
                    reports.SearchResultsByType(storage.StoredShampoo);
                    break;
                case "2":
                    reports.SearchResultsByType(storage.StoredCondicionador);
                    break;
                case "3":
                    reports.SearchResultsByType(storage.StoredPerfume);
                    break;
                case "4":
                    reports.StockContentReport();
                    break;
                default:
                    Console.WriteLine(Messages.formatError);
                    ReportTypeMenu();
                    break;
            }
        }

        public void TestCreatedStock()
        {
            Product InicialShampoo = new Product(Category.Shampoo, Usage.General, "Pet Clean 5 em 1",
                "Pet Clean", 14, 700, DateTime.Now.AddYears(1), Species.Dog);
            Product InicialConditioner = new Product(Category.Conditioner, Usage.General, "Sanol Dog revitalizante",
                "Sanol", 17, 500, DateTime.Now.AddYears(1), Species.Dog);
            Product InicialPerfume = new Product(Category.Perfume, Usage.General, "Colônia Me.Au Pet Cheirinho de Bebê",
                "Me.Au Pet", 13, 120, DateTime.Now.AddYears(1), Species.Dog);

            storage.AddToStock(InicialShampoo);
            storage.AddToStock(InicialConditioner);
            storage.AddToStock(InicialPerfume);

            return;
        }

        private void PrintStock()
        {
            List<Product> stockCollection = storage.GetFullStock();

            foreach (Product item in stockCollection)
            {
                reports.PrintProduct(item);
            }
        }

        public void PrintOpenProducts()
        {
            foreach (Product item in ProductInUse.OpenShampoo)
            {
                reports.PrintProduct(item);
            }

            foreach (Product item in ProductInUse.OpenConditioner)
            {
                reports.PrintProduct(item);
            }

            foreach (Product item in ProductInUse.OpenPerfume)
            {
                reports.PrintProduct(item);
            }
        }


        private void OpenProduct()
        {
            Category wantedProductType = InputServices.SelectCategory();
            Usage wantedProductUsage = InputServices.SelectUsage();
            Species wantedProductSpecies = InputServices.SelectSpecies();
            storage.ValidateProductRemoval(wantedProductType, wantedProductUsage, wantedProductSpecies);
        }
    }
}
