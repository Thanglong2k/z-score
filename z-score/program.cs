using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Data;
using ConsoleTables;

namespace z_score
{
    internal class program
    {
        static int soTP=2;
        static DataTable table;
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            #region
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
            #endregion
            List<double> arrX = new List<double> { 9.1, 4.5, 5.3, 6.7, 6.5, 7.0, 6.0, 5.5, 7.0, 7.0, 8.5, 8.6 };
            List<double> arrY = new List<double> { 8.5, 5.5, 6.0, 7.5, 8.5, 6.0, 6.5, 6.8, 9.0, 7.2, 8.0, 8.5 };
            table = new DataTable();
            table.Columns.Add("value", typeof(double));
            table.Columns.Add("z-score", typeof(double));
            double xTB = 0, dlcX = 0, yTB = 0, dlcY = 0;
            double k = 0;
            for(int i = 0; i < arrX.Count(); i++)
            {
                k += arrX[i] * arrY[i];
            }
            Console.WriteLine("k=:"+k);
            Console.WriteLine("===========TÍNH X============");
            trungBinh(arrX,ref xTB);
            doLechChuan(arrX,xTB,ref dlcX);
            zscore(arrX,xTB,dlcX);
            zscore_ABS(arrX,xTB,dlcX);
            zscore_Do10(arrX,xTB);
            zscore_MinMax(arrX,xTB);
            Console.WriteLine("===========TÍNH Y============");
            trungBinh(arrY,ref yTB);
            doLechChuan(arrY,yTB,ref dlcY);
            zscore(arrY, yTB, dlcY);
            zscore_ABS(arrY,yTB,dlcY);
            zscore_Do10(arrY,yTB);
            zscore_MinMax(arrY,yTB);

            moiTuongQuan(arrX, arrY, xTB, yTB, dlcX, dlcY);
            Console.ReadKey(); // stop screen
        }

        private static void doLechChuan(List<double> arr,double TB,ref double dlc)
        {
            double total = 0;
            arr.ToList().ForEach(x => total += Math.Pow(x - TB, 2));
            dlc = Math.Round( Math.Sqrt(total / arr.Count()),soTP);
            Console.WriteLine("Độ lệch chuẩn : "+dlc);
        }

        private static void input(ref double TB,ref double dlc)
        {
            Console.WriteLine("Nhập trung bình: ");
             TB = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhập độ lệch chuẩn: ");
             dlc = double.Parse(Console.ReadLine());
        }
        private static void trungBinh(List<double> arr,ref double TB)
        {
            
            double total = 0;
            arr.ToList().ForEach(x => total+=x);
            TB = Math.Round( total / arr.Count(),soTP);
            Console.WriteLine("Trung Bình: "+ TB);

        }
        private static void zscore(List<double> arr,double TB,double dlc)
        {
            table.Clear();
            Console.WriteLine("\n-------------z-score: ----------------");
            arr.ToList().ForEach(x => {
                //Console.WriteLine("Value =" + x + "---> z-score =" + Math.Round((x - TB) / dlc, soTP));
                table.Rows.Add(x, Math.Round((x - TB) / dlc, soTP));
            }
            );
            writeTable(table);
        }
        private static void zscore_ABS(List<double> arr,double TB, double dlc)
        {
            table.Clear();
            Console.WriteLine("\n-------------z-score TBTTD: -------------");
            double total = 0;
            arr.ToList().ForEach(x => total += Math.Round(Math.Abs(x - TB),soTP));
            dlc = Math.Round((double)total / arr.Count(),soTP);
            Console.WriteLine("sA : " + dlc);
            arr.ToList().ForEach(x => {
                //Console.WriteLine("Value =" + x + "---> z-score =" + Math.Round((x - TB) / dlc, soTP));
                table.Rows.Add(x, Math.Round((x - TB) / dlc, soTP));
            });
            writeTable(table);
        }
        private static void zscore_MinMax(List<double> arr, double TB)
        {
            table.Clear();
            Console.WriteLine("\n-------------min-max: -------------");
            Console.WriteLine("Nhập min: ");
            double new_min = double.Parse(Console.ReadLine());
            Console.WriteLine("Nhập max: ");
            double new_max = double.Parse(Console.ReadLine());
            double min = arr.Min();
            double max = arr.Max();
            arr.ToList().ForEach(x =>
            {
                //Console.WriteLine("Value =" + x + "---> z-score =" + Math.Round((((x - min) / (max - min)) * (new_max - new_min)) + new_min, soTP));
                table.Rows.Add(x, Math.Round((((x - min) / (max - min)) * (new_max - new_min)) + new_min, soTP));
            }
            );
            writeTable(table);
        }
        private static void zscore_Do10(List<double> arr, double TB)
        {
            table.Clear();
            Console.WriteLine("\n-------------độ thập phân: -------------");
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
            Console.WriteLine("j = " + j);
            arr.ToList().ForEach(x =>
            {
                //Console.WriteLine("Value =" + x + "---> z-score =" + Math.Round(x / Math.Pow(10, j), soTP));
                table.Rows.Add(x, Math.Round(x / Math.Pow(10, j), soTP));
            }
                );
            writeTable(table);
        }
        private static void moiTuongQuan(List<double> arrX, List<double> arrY,double xTB, double yTB, double dlcX, double dlcY)
        {
            Console.WriteLine("----------Mối tương quan----------");
            double total = 0;
            for (int i = 0;i<arrX.Count() ; i++)
            {
                total+=arrX[i]*arrY[i];
            }
            Console.WriteLine("Tổng : " + Math.Round(total,soTP));
            double nXY = Math.Round(arrX.Count() * xTB * yTB,soTP);
            Console.WriteLine("Tích trung bình : " + nXY);
            double ndlcXY = Math.Round(arrX.Count() * dlcX * dlcY,soTP);
            Console.WriteLine("Tích độ lệch chuẩn : " + ndlcXY);
            double result = Math.Round((total - nXY) / ndlcXY,soTP);
            Console.Write("Tương quan rXY: " + result);
            if(result>0) Console.WriteLine("------>Tương quan thuận");
            else if(result==0) Console.WriteLine("------>Không có mối tương quan");
            else Console.WriteLine("------>Tương quan nghịch");
        }
        private static void writeTable(DataTable data)
        {
            string[] columnNames = data.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();

            DataRow[] rows = data.Select();

            var table = new ConsoleTable(columnNames);
            foreach (DataRow row in rows)
            {
                table.AddRow(row.ItemArray);
            }
            table.Write(Format.MarkDown);
            /*table.Write(Format.Alternative);
            table.Write(Format.Minimal);
            table.Write(Format.Default);*/
        }
        
    }
}
