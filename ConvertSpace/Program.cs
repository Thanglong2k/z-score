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
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            string t1 = "9.1	4.5	5.3	6.7	6.5	7.0	6.0	5.5	7.0	7.0	8.5	8.6";
            string t2 = "8.5	5.5	6.0	7.5	8.5	6.0	6.5	6.8	9.0	7.2	8.0	8.5";

            string h1 = t1.Replace("\t", ",");
            string h2 = t2.Replace("\t", ",");
            Console.WriteLine(h1);
            Console.WriteLine(h2);
        }
    }
}
