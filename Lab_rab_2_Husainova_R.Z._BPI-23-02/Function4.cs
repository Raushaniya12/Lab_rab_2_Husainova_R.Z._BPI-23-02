using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab_2_Husainova_R.Z._BPI_23_02
{
    public class Function4 : BaseFunction
    {
        public double A { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public Function4(double a = 0, int c = 1, int d = 1)
        {
            A = a;
            C = c;
            D = d;
        }
        public override string ImagePath => "/Resources/_4p.png";
        public override double Calculate()
        {

            double sum = 0;
            for (int i = 0; i <= D; i++)
            {
                sum += Math.Pow(C + A, i);
            }
            return sum;
        }
    }
}
