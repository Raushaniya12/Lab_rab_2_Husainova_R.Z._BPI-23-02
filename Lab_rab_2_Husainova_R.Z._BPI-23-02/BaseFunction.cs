using System;

public abstract class BaseFunction
{
    public abstract double Calculate();
    public virtual string ImagePath => "/Resources/placeholder.png";
    
}