using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab_2_Husainova_R.Z._BPI_23_02
{
    public static class Function
    {
        public static double Function1(double a, int f)
        {
            return Math.Sin(f * a);
        }
        public static double Function2(double a, double b, int f)
        {
            return Math.Cos(f * a) + Math.Sin(f * b);
        }
        public static double Function3(double a, double b, int c, int d)
        {
            return c * Math.Pow(a, 2) + d * Math.Pow(b, 2);
        }
        public static double Function4(double a, int c, int d)
        {
            double sum = 0;
            for (int i = 0; i <= d; i++)
            {
                sum += Math.Pow(c + a, i);
            }
            return sum;
        }
        public static double Function5(double x, double y, int N, int K)
        {
            double sum = 0;

            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= K; j++)
                {           
                    double numerator = Math.Sin(Math.Pow(y, i)) + i * x;
                    double denominator = (i + 1) * j;

                    sum += numerator / denominator;
                }
            }

            return sum;
        }
    }
}
