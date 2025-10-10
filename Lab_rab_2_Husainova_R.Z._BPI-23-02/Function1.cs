using System;

namespace Lab_rab_2_Husainova_R.Z._BPI_23_02
{
    public class Function1 : BaseFunction
    {
        public int F { get; set; }
        public double A { get; set; }
        public override string ImagePath => "/Resources/_1p.png";

        public override double Calculate()
        {
            return Math.Sin(F * A);
        }
    }
}