
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



        }
    }
}
