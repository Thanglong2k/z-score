using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace z_score
{
    internal class program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("Noi dung trong file: ");
            string a = File.ReadAllText("Test.txt");
            string b = a.Replace(' ',',').Replace('\t',',');
            Console.WriteLine("Nhập trung bình: ");
            string x=Console.ReadLine();
            float xTB = float.Parse(x);
            Console.WriteLine("Nhập độ lệch chuẩn: ");
            string dl=Console.ReadLine();
            float dlc = float.Parse(dl);
            var c=b.Split(',');
            float[] d = new float[c.Length];
            for(int i=0; i<c.Length; i++)
            {
                d[i] = float.Parse(c[i], CultureInfo.InvariantCulture.NumberFormat);
                float result = (d[i] - xTB) / dlc;
                Console.WriteLine("x"+(i+1)+": {0}",result);
            }
            
            Console.ReadKey(); // stop screen*/
            List<double> arr = new List<double> { 200, 300, 400, 600, 1000 };

            Console.WriteLine("Nhập trung bình: ");
            double xTB = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhập độ lệch chuẩn: ");
            double dlc = double.Parse(Console.ReadLine());
            Console.WriteLine("z-score: ");
            arr.ToList().ForEach(x => Console.WriteLine("Value " + (x - xTB) / dlc));
            Console.WriteLine("z-score TBTTD: ");
            double total = 0;
            arr.ToList().ForEach(x => total += Math.Abs(x - xTB));
            dlc = (double)total / arr.Count();
            arr.ToList().ForEach(x => Console.WriteLine("Value " + (x - xTB) / dlc));
            Console.WriteLine("min-max: ");
            Console.WriteLine("Nhập min: ");
            double new_min = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhập max: ");
            double new_max = double.Parse(Console.ReadLine());
            Console.WriteLine("Value " + new_min);
            for (int i = 1; i < arr.Count() - 1; i++)
            {
                Console.WriteLine("Value " + (((arr[i] - arr[0]) / (arr[arr.Count() - 1] - arr[0])) * (new_max - new_min)) + new_min);
            }
            Console.WriteLine("Value " + new_max);
            Console.WriteLine("độ thập phân: ");
            List<double> arr_new = new List<double>();
            for (int i = 0; i < arr.Count(); i++)
            {
                arr_new.Add(Math.Abs(arr[i]));
            }
            arr_new.Sort();
            int j = 1;
            for (int i = 1; ; i++)
            {
                var result = arr_new[arr_new.Count() - 1] / Math.Pow(10, i);
                if (result < 1)
                {

                    j = i;
                    break;
                }
            }
            arr.ToList().ForEach(x => Console.WriteLine("Value " + x / Math.Pow(10, j)));

            Console.ReadKey(); // stop screen
        }
    }
}
