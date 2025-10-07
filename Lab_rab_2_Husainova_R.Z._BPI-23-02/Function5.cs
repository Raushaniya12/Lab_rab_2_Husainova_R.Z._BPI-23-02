using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab_2_Husainova_R.Z._BPI_23_02
{
    public class Function5 : BaseFunction
    {
        public override string ImagePath => "/Resources/_11var.png";
        public override double Calculate(FunctionParameters p)
        {
            if (p.N < 1 || p.K < 1)
                throw new ArgumentException("N и K должны быть ≥ 1");

            double sum = 0;
            for (int i = 1; i <= p.N; i++)
            {
                for (int j = 1; j <= p.K; j++)
                {
                    double numerator = Math.Sin(Math.Pow(p.Y, i)) + i * p.X;
                    double denominator = (i + 1) * j;
                    sum += numerator / denominator;
                }
            }
            return sum;
        }
    }
}

