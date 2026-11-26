
using LINQ.Models;
using System.Diagnostics.Metrics;
using System.Drawing;
using static LINQ.DataSources.Source;

namespace LINQ_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1. Get top 3 most expensive products
            var top3 = ProductList.OrderByDescending(p => p.UnitPrice).Take(3);
            foreach(var p in top3)
            {
                Console.WriteLine(p);
            }
            #endregion


            #region 2. show page 2 of products, with page size = 5
            int page = 2;
            int pageSize = 5;

            var page2 = ProductList.Skip((page - 1) * pageSize).Take(pageSize);
            foreach (var p in page2)
            {
                Console.WriteLine(p);
            }
            #endregion


            #region 3. Take products from the list as long as Their UnitPrice is less than $25(list is ordered by price).

            var price25 = ProductList.OrderBy(P => P.UnitPrice).TakeWhile(p => p.UnitPrice <= 25.0000m);
            foreach (var p in price25)
            {
                Console.WriteLine(p);
            }
            #endregion


            #region 4. Check if ALL products in the "Seafood" category are in stock
            var Result = ProductList.Where(p => p.Category == "Seafood").All(p => p.UnitsInStock > 0);
            Console.WriteLine(Result);
            #endregion


            #region MyRegion
            int[] ids = { 3, 9, 13, 18 };
            var result1 = ids.Contains(9);
            Console.WriteLine(result1);
            #endregion


            #region 6. Group all products by Category and print each group with its product count.
            var result2 = ProductList.GroupBy(p => p.Category).Select(n => new { category = n.Key, count = n.Count() });
            foreach(var p in result2)
            {
                Console.WriteLine(p);
            }
            #endregion


            #region 7. Group products by Category and project only product names per group
            var result3 = ProductList.GroupBy(p => p.Category);
            foreach(var g in result3)
            {
                Console.WriteLine(g.Key);
                foreach (var p in g)
                {
                    Console.WriteLine($"\t{p.ProductName}");
                }
            }

            #endregion

            #region 8. Find all categories that have MORE THAN 3 products
            var result4 = ProductList.GroupBy(p => p.Category).Where(g => g.Count() > 3);
            foreach (var g in result4)
            {
                Console.WriteLine($"{g.Key}: {g.Count()}");
            }
            #endregion


            #region 9. Using QUERY SYNTAX, group customers by Country, and for each group select { Country, Count, TotalOrderValue }.
            var result5 = from c in CustomerList
                          group c by c.Country into countryGroup
                          select new { Country = countryGroup.Key,
                                       Count = countryGroup.Count(), 
                                       TotalOrderValue = countryGroup.Sum(c => c.Orders.Sum(o => o.Total))
                          };
            foreach (var g in result5)
            {
                Console.WriteLine(g);
            }
            #endregion


            #region 10. Calculate the total number of units in stock across all products
            var totalStock = ProductList.Sum(p => p.UnitsInStock);
            Console.WriteLine($"Total Units in Stock: {totalStock}");
            #endregion


            #region 11. Find the CHEAPEST and MOST EXPENSIVE product prices
            var result6 = ProductList.OrderByDescending(p => p.UnitPrice).Select(p => p.UnitPrice).First();
            Console.WriteLine($"Most Expensive: {result6}");
            var result7 = ProductList.OrderBy(p => p.UnitPrice).Select(p => p.UnitPrice).First();
            Console.WriteLine($"Cheapest: {result7}");
            #endregion


            #region 12. Get a distinct list of all product categories
            var disList = ProductList.DistinctBy(p => p.Category);
            foreach (var p in disList)
            {
                Console.WriteLine(p);
            }
            #endregion


            #region 13. find product IDs that are in setA but NOT in setB
            int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
            int[] setB = { 3, 6, 9, 12, 15, 13 };
            var result8 = setA.Except(setB);
            Console.WriteLine(string.Join(", ", result8));
            #endregion


            #region 14. Find countries that appear in list1 but NOT in list2 (case -insensitive).
            string[] list1 = { "Germany", "France", "UK", "Spain" };
            string[] list2 = { "france", "SPAIN", "Italy" };
            var result9 = list1.Except(list2, StringComparer.OrdinalIgnoreCase);
            Console.WriteLine(string.Join(", ", result9));
            #endregion


            #region 15. Build a Dictionary<int, Product> keyed by ProductID. Then retrieve and print the product with ID = 18.
            var pId = ProductList.ToDictionary(p => p.ProductID);
            Console.WriteLine(pId[18]);
            #endregion


            #region 16. Get the first product whose price is greater than $50.
            var result10 = ProductList.SkipWhile(p => p.UnitPrice <= 50.0000m).First();
            Console.WriteLine(result10);
            #endregion

        }
        }
}
