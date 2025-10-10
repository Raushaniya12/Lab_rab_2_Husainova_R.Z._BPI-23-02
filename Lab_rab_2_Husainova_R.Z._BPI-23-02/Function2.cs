using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab_rab_2_Husainova_R.Z._BPI_23_02
{
    public class Function2 : BaseFunction
    {
        public int F { get; set; }
        public double A { get; set; }
        public double B { get; set; }
        public override string ImagePath => "/Resources/_p2.png";

        public override double Calculate()
        {
            return Math.Cos(F * A) + Math.Sin(F * B);
        }
    }
}