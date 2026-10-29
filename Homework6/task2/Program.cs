using GeneralMethods;
using Homework6.task2.Models;

namespace Homework6.task2 {

    public class Program
    {
        public static void Main()
        {
            Catalog catalog = CreateSampleCatalog();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n1 - about the topic and the OOP principles");
                Console.WriteLine("2 - show the catalog");
                Console.WriteLine("3 - search parts by name");
                Console.WriteLine("4 - sell a part");
                Console.WriteLine("0 - exit");

                int choice = InputMethods.ReadValue<int>(
                    "Choose an action", 
                    int.TryParse, 
                    c => c is >= 0 and <= 4, 
                    "Enter a number from 0 to 4");

                switch (choice)
                {
                    case 1:
                        ExplainTopicAndPrinciples(catalog);
                        break;
                    case 2:
                        ShowCatalog(catalog);
                        break;
                    case 3:
                        SearchParts(catalog);
                        break;
                    case 4:
                        SellPart(catalog);
                        break;
                    default:
                        isRunning = false;
                        break;
                }
            }
        }

        private static Catalog CreateSampleCatalog()
        {
            Catalog catalog = new Catalog("Auto parts catalog");

            catalog.Add(new EnginePart("ENG-001", "Поршневое кольцо", "Mahle", 3200m, 12, 1.6, 120000));
            catalog.Add(new EnginePart("ENG-002", "Свеча зажигания", 450m, 40));
            catalog.Add(new BrakePart("BRK-001", "Тормозной диск передний", "Brembo", 5400m, 6, 300, true));
            catalog.Add(new BrakePart("BRK-002", "Тормозные колодки", 2100m, 0));
            catalog.Add(new ElectricalPart("ELC-001", "Аккумулятор 60 Ач", "Varta", 8900m, 4, 12, 60));
            catalog.Add(new ElectricalPart("ELC-002", "Лампа H7", 380m, 25));

            return catalog;
        }

        private static void PrintParts(IReadOnlyList<Part> parts)
        {
            if (parts.Count == 0)
            {
                Console.WriteLine("Nothing found.");
                return;
            }

            foreach (Part part in parts)
            {
                string stock = part.IsInStock() ? $"{part.Quantity} pcs" : "out of stock";

                Console.WriteLine(
                    $"{part.Article,-8} {part.Name,-26} {part.GetCategory(),-11} {part.Price,9:F2}  {stock}");
                Console.WriteLine($"         {part.GetSpecifications()}");
            }
        }

        private static string GetTypeChain(Part part)
        {
            List<string> chain = new List<string>();
            Type? type = part.GetType();

            while (type != null && type != typeof(object))
            {
                chain.Add(type.Name);
                type = type.BaseType;
            }

            return string.Join(" -> ", chain);
        }

        private static void ShowCatalog(Catalog catalog)
        {
            Console.WriteLine($"{catalog.Name}: {catalog.Count} items, total value {catalog.TotalValue:F2}");
            PrintParts(catalog.Parts);
        }

        private static void SearchParts(Catalog catalog)
        {
            string text = InputMethods.ReadString("Enter a part of the name");
            PrintParts(catalog.SearchByName(text));
        }

        private static void SellPart(Catalog catalog)
        {
            string article = InputMethods.ReadString("Enter the article (e.g. ENG-001)");
            Part? part = catalog.FindByArticle(article);

            if (part == null)
            {
                Console.WriteLine("No part with this article.");
                return;
            }

            int amount = InputMethods.ReadValue<int>(
                "Enter the amount",
                int.TryParse,
                value => value > 0, 
                "Enter a positive integer");

            if (part.Sell(amount))
            {
                Console.WriteLine($"Sold {amount} x {part.Name}. Left in stock: {part.Quantity}.");
            }
            else
            {
                Console.WriteLine($"Cannot sell {amount}: only {part.Quantity} in stock.");
            }
        }

        private static void ExplainTopicAndPrinciples(Catalog catalog)
        {
            Console.WriteLine();
            Console.WriteLine("TOPIC: a parts catalog keeps car parts. Every part has an article, a name, a price");
            Console.WriteLine("and a stock level, but engine, brake and electrical parts also have their own features.");

            Console.WriteLine();
            Console.WriteLine("1) ENCAPSULATION: data is hidden, access goes through properties and methods that check values.");
            Part sample = new EnginePart("TMP-1", "Sample", 100m, 1);

            try
            {
                sample.Price = -10m;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"   Setting Price = -10 is refused: {ex.Message}");
            }

            Console.WriteLine("   Quantity can only be read from outside; it changes only through Sell and Restock.");

            Console.WriteLine();
            Console.WriteLine("2) INHERITANCE: EnginePart, BrakePart and ElectricalPart reuse everything from Part.");

            foreach (Part part in catalog.Parts)
            {
                Console.WriteLine($"   {part.Name}: {GetTypeChain(part)}");
            }

            Console.WriteLine();
            Console.WriteLine("3) POLYMORPHISM: the same calls give different results depending on the real object.");

            foreach (Part part in catalog.Parts)
            {
                Console.WriteLine(
                    $"   {part.GetCategory(),-10} | {part.GetSpecifications()} | warranty {part.GetWarrantyMonths()} months");
            }

            Console.WriteLine();
            Console.WriteLine("4) ABSTRACTION: Part is abstract, so 'new Part()' does not compile. It only describes");
            Console.WriteLine("   what any part can do. The catalog works with Part and does not care which kind it is.");
        }
    }
}