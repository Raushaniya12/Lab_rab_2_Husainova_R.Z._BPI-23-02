using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab_2_Husainova_R.Z._BPI_23_02
{
    public class Function4 : BaseFunction
    {
        public override string ImagePath => "/Resources/_4p.png";
        public override double Calculate(FunctionParameters p)
        {
            double sum = 0;
            for (int i = 0; i <= p.D; i++)
            {
                sum += Math.Pow(p.C + p.A, i);
            }
            return sum;
        }
    }
}