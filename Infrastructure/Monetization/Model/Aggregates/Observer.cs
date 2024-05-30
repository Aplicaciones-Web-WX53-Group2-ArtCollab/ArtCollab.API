namespace Infraestructure.Monetization.Model.Aggregates;

public abstract class Observer
{
    public abstract TaskStatus Update();
    
}