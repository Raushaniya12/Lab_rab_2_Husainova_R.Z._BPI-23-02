using System;

public abstract class BaseFunction
{
    public abstract double Calculate(params double[] args);
    public virtual string ImagePath => "/Resources/placeholder.png";
    
}