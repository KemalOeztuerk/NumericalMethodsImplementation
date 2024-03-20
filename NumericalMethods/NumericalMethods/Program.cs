using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumericalMethods
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static double Function(double x)
        {
            return x * x * x - 4; // Örnek olarak x^3 - 4 fonksiyonunu kullandık
        }

        static double Sekant(double x0, double x1, double tolerance=0.0001, int maxIterations=1000)
        {
            double x2 = 0;
            double f0 = Function(x0);
            double f1 = Function(x1);
            int iterations = 0;

            Console.WriteLine("İterasyon\t  x0\t\t  x1\t\t  x2\t\t  f(x2)\t\t   |x1 - x0|");

            while (Math.Abs(x1 - x0) > tolerance && iterations < maxIterations)
            {
                x2 = x1 - f1 * (x1 - x0) / (f1 - f0);
                x0 = x1;
                x1 = x2;
                f0 = f1;
                f1 = Function(x1);
                iterations++;

                Console.WriteLine($"{iterations}\t\t{x0}\t{x1}\t{x2}\t{f1}\t{Math.Abs(x1 - x0)}");
            }

            return x2;
        }

        //x^2+3x-19 [1,7] Aralığında Epsilon: 0.003
        static double F(double x)
        {
            return x * x + 3 * x - 19;
        }

        static double Kiris(double x0, double x1,double epsilon = 0.003)
        {
            double x2 = 0;
            double f0 = F(x0);
            double f1 = F(x1);

            int AdımSayısı = 0;

            do
            {
                double f0_gecici = F(x0);
                double f1_gecici = F(x1);

                x2 = x1 - (f1_gecici * (x1 - x0)) / (f1_gecici - f0_gecici);
                double f2 = F(x2);

                Console.WriteLine($"Adım {AdımSayısı + 1}: x1 = {x1}, f(x1) = {f1_gecici}, x2 = {x2}, f(x2) = {f2}");

                if (f2 * f1 < 0)
                {
                    x0 = x1;
                    f0 = f1;
                }
                else
                {
                    f0 = f2;
                }

                x1 = x2;
                f1 = f2;

                AdımSayısı++;
            } while (Math.Abs(f1) > epsilon);

            Console.WriteLine($"Kökün yaklaşık değeri :{x2} ve f(x) değeri : {F(x2)}");
            return x2;
        }


        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
