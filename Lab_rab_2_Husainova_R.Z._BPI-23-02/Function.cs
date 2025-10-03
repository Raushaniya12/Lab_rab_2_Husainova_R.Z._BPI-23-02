using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab_2_Husainova_R.Z._BPI_23_02
{
    public class Function1 : BaseFunction
    {
        public override string ImagePath => "/Resources/_1p.png";
        public override double Calculate(params double[] args)
        {
            if (args.Length != 2)
                throw new ArgumentException("Требуется 2 аргумента: a и f");

            double a = args[0];
            int f = (int)Math.Round(args[1]);
            return Math.Sin(f * a);
        }
    }

    public class Function2 : BaseFunction
    {
        public override string ImagePath => "/Resources/_p2.png";
        public override double Calculate(params double[] args)
        {
            if (args.Length != 3)
                throw new ArgumentException("Требуется 3 аргумента: a, b, f");

            double a = args[0];
            double b = args[1];
            int f = (int)Math.Round(args[2]);
            return Math.Cos(f * a) + Math.Sin(f * b);
        }
    }

    public class Function3 : BaseFunction
    {
        public override string ImagePath => "/Resources/_3p.png";
        public override double Calculate(params double[] args)
        {
            if (args.Length != 4)
                throw new ArgumentException("Требуется 4 аргумента: a, b, c, d");

            double a = args[0];
            double b = args[1];
            int c = (int)Math.Round(args[2]);
            int d = (int)Math.Round(args[3]);
            return c * Math.Pow(a, 2) + d * Math.Pow(b, 2);
        }
    }

    public class Function4 : BaseFunction
    {
        public override string ImagePath => "/Resources/_4p.png";
        public override double Calculate(params double[] args)
        {
            if (args.Length != 3)
                throw new ArgumentException("Требуется 3 аргумента: a, c, d");

            double a = args[0];
            int c = (int)Math.Round(args[1]);
            int d = (int)Math.Round(args[2]);

            double sum = 0;
            for (int i = 0; i <= d; i++)
            {
                sum += Math.Pow(c + a, i);
            }
            return sum;
        }
    }

    public class Function5 : BaseFunction
    {
        public override string ImagePath => "/Resources/_11var.png";
        public override double Calculate(params double[] args)
        {
            if (args.Length != 4)
                throw new ArgumentException("Требуется 4 аргумента: x, y, N, K");

            double x = args[0];
            double y = args[1];
            int N = (int)Math.Round(args[2]);
            int K = (int)Math.Round(args[3]);

            if (N < 1 || K < 1)
                throw new ArgumentException("N и K должны быть ≥ 1");

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