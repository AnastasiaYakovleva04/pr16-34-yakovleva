using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr16_3_yakovleva
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Сколько хотите ввести чисел: ");
                int n = Convert.ToInt32(Console.ReadLine());
                if (n < 0)
                    Console.WriteLine("Количество не может быть менее 0");
                else
                {
                    double[] arr = new double[n];
                    for (int i = 0; i<n; i++)
                    {
                        Console.WriteLine(i + 1 + ": ");
                        arr[i] = Convert.ToDouble(Console.ReadLine());
                    }

                    Console.WriteLine();

                    var ch = from numbers in arr 
                             group numbers by numbers into g 
                             select new { Number = g.Key, Ch = g.Count() };
                    foreach (var item in ch)
                        Console.WriteLine(item.Number + " - " + item.Ch);

                    Console.WriteLine("-----------------");

                    double[] newArr = arr.Select(number =>
                    {
                        var chItem = ch.FirstOrDefault(item => item.Number == number);
                        return number * chItem.Ch;
                    }).ToArray();

                    var newCh = from numbers in newArr
                             group numbers by numbers into g
                             select new { Number = g.Key, Ch = g.Count() };
                    foreach (var item in newCh)
                        Console.WriteLine(item.Number + " - " + item.Ch);
                }
            }
            catch
            {
                Console.WriteLine("Неверный формат данных");
            }
            Console.ReadKey();
        }
    }
}
