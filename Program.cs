using System;
using System.IO;

namespace OAIP_KR
{
    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            double a = 0, b = 0, e = 0;
            string path = "test1.txt";

            (a, b, e) = ReadFile(path);

            double x = goldSectionSearch(a, b, e);
            path = "test2.txt";

            WriteFile(path, x);

            Console.ReadKey();
        }

        static (double, double, double) ReadFile(string path)
        {
            double a, b, e;

            using (StreamReader reader = new StreamReader(path))
            {
                string text = reader.ReadToEnd();
                string[] splitText = text.Split(' ');

                a = Convert.ToDouble(splitText[0]);
                b = Convert.ToDouble(splitText[1]);
                e = Convert.ToDouble(splitText[2]);

                Console.WriteLine($"Точка 1 = {a}; точка 2 = {b}; точность = {e}");
            }

            return (a, b, e);
        }

        static void WriteFile(string path, double x)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine("Ответ: " + x);

                Console.WriteLine("Ответ: " + x);
            }
        }

        static double goldSectionSearch(double a, double b, double e)
        {
            if ((Math.Abs(b - a) < e) == false)
            {
                double x1 = b - ((b - a) / Math.PI);
                double x2 = a + ((b - a) / Math.PI);

                if (F(x1) <= F(x2))
                {
                    a = x1;
                }
                else
                {
                    b = x2;
                }
                goldSectionSearch(a, b, e);
            }

            return (a + b) / 2;
        }

        static double F(double x)
        {
            return x * x;
        }
    }
}