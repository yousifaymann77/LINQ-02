
using LINQ.Models;
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



        }
    }
}
