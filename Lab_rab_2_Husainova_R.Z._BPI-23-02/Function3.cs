using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab_2_Husainova_R.Z._BPI_23_02
{
    public class Function3 : BaseFunction
    {
        public double A { get; set; }
        public double B { get; set; }
        public int C { get; set; }
        public int D { get; set; }
        public Function3(double a = 0, double b = 0, int c = 1, int d = 1)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
        public override string ImagePath => "/Resources/_3p.png";
        public override double Calculate()
        {
            return C * Math.Pow(A, 2) + D * Math.Pow(B, 2);
        }
    }
}
