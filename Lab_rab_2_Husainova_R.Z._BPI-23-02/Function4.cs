using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab_2_Husainova_R.Z._BPI_23_02
{
    public class Function4 : BaseFunction
    {
        public int x { get; set; }
        public double z { get; set; }
        public double y { get; set; }
        public override string ImagePath => "/Resources/_4p.png";
        public override double Calculate()
        {
            double sum = 0;
            for (int i = 0; i <= x; i++)
            {
                sum += Math.Pow(y + z, i);
            }
            return sum;
        }
    }
}