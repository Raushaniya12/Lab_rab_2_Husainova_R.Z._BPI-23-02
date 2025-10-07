using System;

namespace Lab_rab_2_Husainova_R.Z._BPI_23_02
{
    public class Function1 : BaseFunction
    {
        public override string ImagePath => "/Resources/_1p.png";

        public override double Calculate(FunctionParameters p)
        {
            return Math.Sin(p.F * p.A);
        }
    }
}