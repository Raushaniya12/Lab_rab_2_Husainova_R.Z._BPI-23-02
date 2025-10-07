using System;

namespace Lab_rab_2_Husainova_R.Z._BPI_23_02
{
    public abstract class BaseFunction
    {
        public abstract string ImagePath { get; }
        public abstract double Calculate(FunctionParameters parameters);
    }
}