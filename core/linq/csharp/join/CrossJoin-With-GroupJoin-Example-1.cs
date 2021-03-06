using System;
using System.Collections.Generic;
using System.Linq;

namespace Join
{
    public static class CrossJoinWithGroupJoinExample1
    {
        // The group join operator is more general than join, as this slightly more verbose version of the cross join sample shows.
        // Output:
        // Chai: Beverages
        // Chang: Beverages
        // Guarana Fantastica: Beverages
        // Sasquatch Ale: Beverages
        // Steeleye Stout: Beverages
        // Cote de Blaye: Beverages
        // Chartreuse verte: Beverages
        // Ipoh Coffee: Beverages
        // Laughing Lumberjack Lager: Beverages
        // Outback Lager: Beverages
        // Rhonbrau Klosterbier: Beverages
        // Lakkalikoori: Beverages
        // Aniseed Syrup: Condiments
        // Chef Anton's Cajun Seasoning: Condiments
        // Chef Anton's Gumbo Mix: Condiments
        // Grandma's Boysenberry Spread: Condiments
        // Northwoods Cranberry Sauce: Condiments
        // Genen Shouyu: Condiments
        // Gula Malacca: Condiments
        // Sirop d'erable: Condiments
        // Vegie-spread: Condiments
        // Louisiana Fiery Hot Pepper Sauce: Condiments
        // Louisiana Hot Spiced Okra: Condiments
        // Original Frankfurter grune Sobe: Condiments
        // Queso Cabrales: Dairy Products
        // Queso Manchego La Pastora: Dairy Products
        // Gorgonzola Telino: Dairy Products
        // Mascarpone Fabioli: Dairy Products
        // Geitost: Dairy Products
        // Raclette Courdavault: Dairy Products
        // Camembert Pierrot: Dairy Products
        // Gudbrandsdalsost: Dairy Products
        // Flotemysost: Dairy Products
        // Mozzarella di Giovanni: Dairy Products
        // Ikura: Seafood
        // Konbu: Seafood
        // Carnarvon Tigers: Seafood
        // Nord-Ost Matjeshering: Seafood
        // Inlagd Sill: Seafood
        // Gravad lax: Seafood
        // Boston Crab Meat: Seafood
        // Jack's New England Clam Chowder: Seafood
        // Rogede sild: Seafood
        // Spegesild: Seafood
        // Escargots de Bourgogne: Seafood
        // Rod Kaviar: Seafood
        public static void QuerySyntaxExample()
        {
            string[] categories = new string[]
            {
                "Beverages",
                "Condiments",
                "Vegetables",
                "Dairy Products",
                "Seafood"
            };

            List<Product> products = Data.Products;

            var q =
                from c in categories
                join p in products on c equals p.Category into ps
                from p in ps
                select new { Category = c, p.ProductName };

            foreach (var v in q)
            {
                Console.WriteLine($"{v.ProductName}: {v.Category}");
            }
        }

        // The group join operator is more general than join, as this slightly more verbose version of the cross join sample shows.
        // Output:
        // Chai: Beverages
        // Chang: Beverages
        // Guarana Fantastica: Beverages
        // Sasquatch Ale: Beverages
        // Steeleye Stout: Beverages
        // Cote de Blaye: Beverages
        // Chartreuse verte: Beverages
        // Ipoh Coffee: Beverages
        // Laughing Lumberjack Lager: Beverages
        // Outback Lager: Beverages
        // Rhonbrau Klosterbier: Beverages
        // Lakkalikoori: Beverages
        // Aniseed Syrup: Condiments
        // Chef Anton's Cajun Seasoning: Condiments
        // Chef Anton's Gumbo Mix: Condiments
        // Grandma's Boysenberry Spread: Condiments
        // Northwoods Cranberry Sauce: Condiments
        // Genen Shouyu: Condiments
        // Gula Malacca: Condiments
        // Sirop d'erable: Condiments
        // Vegie-spread: Condiments
        // Louisiana Fiery Hot Pepper Sauce: Condiments
        // Louisiana Hot Spiced Okra: Condiments
        // Original Frankfurter grune Sobe: Condiments
        // Queso Cabrales: Dairy Products
        // Queso Manchego La Pastora: Dairy Products
        // Gorgonzola Telino: Dairy Products
        // Mascarpone Fabioli: Dairy Products
        // Geitost: Dairy Products
        // Raclette Courdavault: Dairy Products
        // Camembert Pierrot: Dairy Products
        // Gudbrandsdalsost: Dairy Products
        // Flotemysost: Dairy Products
        // Mozzarella di Giovanni: Dairy Products
        // Ikura: Seafood
        // Konbu: Seafood
        // Carnarvon Tigers: Seafood
        // Nord-Ost Matjeshering: Seafood
        // Inlagd Sill: Seafood
        // Gravad lax: Seafood
        // Boston Crab Meat: Seafood
        // Jack's New England Clam Chowder: Seafood
        // Rogede sild: Seafood
        // Spegesild: Seafood
        // Escargots de Bourgogne: Seafood
        // Rod Kaviar: Seafood
        public static void MethodSyntaxExample()
        {
            string[] categories = new string[]
            {
                "Beverages",
                "Condiments",
                "Vegetables",
                "Dairy Products",
                "Seafood"
            };

            List<Product> products = Data.Products;

            var q =
                categories.GroupJoin(products, c => c, p => p.Category, (c, ps) => new { c, ps })
                    .SelectMany(@t => @t.ps, (@t, p) => new { Category = @t.c, p.ProductName });

            foreach (var v in q)
            {
                Console.WriteLine($"{v.ProductName}: {v.Category}");
            }
        }
    }
}
