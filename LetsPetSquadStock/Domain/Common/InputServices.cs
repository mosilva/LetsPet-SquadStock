using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock.Domain;

namespace Stock.Domain.Common
{
    public static class InputServices
    {
        private static string DefaultTextFormat(string userInput)
        {
            return CapitalizeLettersAfterSpace(userInput).Trim();
        }

        private static string CapitalizeLettersAfterSpace(string text)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(text);
        }

        public static string UserInput()
        {
            string userInput = Console.ReadLine();
            Console.WriteLine();
            if (!string.IsNullOrWhiteSpace(userInput))
            {
                return DefaultTextFormat(userInput);
            }
            Console.WriteLine(Messages.invalidNullInput);
            return UserInput();
        }

        public static Category SelectCategory()
        {
            Console.WriteLine(Messages.categorySelectionMenu);
            var inputType = UserInput();
            switch (inputType)
            {
                case "1":
                    return Category.Shampoo;

                case "2":
                    return Category.Conditioner;

                case "3":
                    return Category.Perfume;

                default:
                    Console.WriteLine(Messages.formatError);
                    return SelectCategory();
            }
        }

        public static Usage SelectUsage()
        {
            Console.WriteLine(Messages.usageSelectionMenu);
            var inputUsage = UserInput();
            switch (inputUsage)
            {
                case "1":
                    return Usage.General;

                case "2":
                    return Usage.Special;

                default:
                    Console.WriteLine(Messages.formatError);
                    return SelectUsage();
            }
        }

        public static Species SelectSpecies()
        {
            Console.WriteLine(Messages.speciesSelectionMenu);
            var inputSpecie = UserInput();
            switch (inputSpecie)
            {
                case "1":
                    return Species.Dog;


                case "2":
                    return Species.Cat;


                default:

                    Console.WriteLine(Messages.formatError);
                    return SelectSpecies();

            }

        }

        public static string NewName()
        {
            Console.Write(Messages.inputName);
            var InptName = UserInput();
            return InptName;
        }

        public static string NewBrand()
        {
            Console.Write(Messages.inputBrand);
            var InptBrand = UserInput();
            return InptBrand;
        }

        public static int NewQuantity(int allowedQuantity)
        {
            Console.Write($"{Messages.inputQuantity} (É possível adicionar até {allowedQuantity} produto(s)): ");
            string userInput = UserInput();
            bool validFormatQuantity = int.TryParse(userInput, out int inputQuantity);
            if (validFormatQuantity)
            {
                if (inputQuantity >= 1 && inputQuantity <= allowedQuantity)
                {
                    return inputQuantity;
                }
                else
                {
                    Console.WriteLine(Messages.invalidQuantity);
                    return NewQuantity(allowedQuantity);
                }
            }
            else
            {
                Console.WriteLine(Messages.formatError);
                return NewQuantity(allowedQuantity);
            }
        }

        public static decimal NewPrice()
        {
            Console.Write(Messages.inputPrice);
            var InPrice = UserInput();
            var correctPrice = decimal.TryParse(InPrice, out var InptPrice);
            if (correctPrice && InptPrice > 0)
            {
                return InptPrice;
            }
            else
            {
                Console.WriteLine(Messages.formatError);
                return NewPrice();
            }
        }

        public static int NewTotalVolume()
        {
            Console.Write(Messages.inputTotalVolume);
            var InTotalVolume = UserInput();
            var correctTotalVolume = int.TryParse(InTotalVolume, out var InptTotalVolume);
            if (correctTotalVolume && InptTotalVolume > 0)
            {
                return InptTotalVolume;
            }
            else
            {
                Console.WriteLine(Messages.formatError);
                return NewTotalVolume();
            }
        }

        public static DateTime NewExpirationDate()
        {
            Console.Write(Messages.inputExpirationDate);
            var InDate = UserInput();
            var correctDate = DateTime.TryParse(InDate, out var InptExpirationDate);
            if (correctDate && InptExpirationDate > DateTime.Now)
            {
                return InptExpirationDate;
            }
            else
            {
                Console.WriteLine(Messages.formatError);
                return NewExpirationDate();
            }
        }             

        public static bool ReturnSwitch()
        {
            Console.WriteLine(Messages.maxedOutQuantity);
            string userInput = UserInput();
            switch (userInput)
            {
                case "Sim":
                    return false;

                case "Não":
                    return true;

                default:
                    Console.WriteLine(Messages.formatError);
                    return ReturnSwitch();

            }
        }

    }


}
