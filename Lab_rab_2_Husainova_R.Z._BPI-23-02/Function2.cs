using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab_rab_2_Husainova_R.Z._BPI_23_02
{
    public class Function2 : BaseFunction
    {
        public override string ImagePath => "/Resources/_p2.png";

        public override double Calculate(FunctionParameters p)
        {
            return Math.Cos(p.F * p.A) + Math.Sin(p.F * p.B);
        }
    }
}