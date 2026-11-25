
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

        }
    }
}
