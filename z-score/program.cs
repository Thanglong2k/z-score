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
            Console.WriteLine("Noi dung trong file: ");
            string a = File.ReadAllText("E:/Nam4/Ki1/KhaiPhaDuLieu/z-score/z-score/Test.txt");
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
            
            Console.ReadKey(); // stop screen
        }
    }
}
