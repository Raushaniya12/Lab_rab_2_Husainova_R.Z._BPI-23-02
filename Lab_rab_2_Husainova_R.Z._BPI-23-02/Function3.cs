using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab_2_Husainova_R.Z._BPI_23_02
{
    public class Function3 : BaseFunction
    {
        public override string ImagePath => "/Resources/_3p.png";
        public override double Calculate(FunctionParameters p)
        {
            return p.C * Math.Pow(p.A, 2) + p.D * Math.Pow(p.B, 2);
        }
    }
}