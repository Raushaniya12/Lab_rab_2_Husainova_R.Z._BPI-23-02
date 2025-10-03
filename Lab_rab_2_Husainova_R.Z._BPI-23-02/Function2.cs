using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab_2_Husainova_R.Z._BPI_23_02
{
    public class Function2 : BaseFunction
    {
        public double A { get; set; }
        public double B { get; set; }
        public int F { get; set; }
        public Function2(double a = 0, double b = 0, int f = 1)
        {
            A = a;
            F = f;
            B = b;
        }
        public override string ImagePath => "/Resources/_p2.png";
        public override double Calculate()
        {
            return Math.Cos(F * A) + Math.Sin(F * B);
        }
    }
}
