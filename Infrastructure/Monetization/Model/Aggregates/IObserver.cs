namespace Infrastructure.Monetization.Model.Aggregates;

public abstract class Observer
{
    public abstract HttpResponseMessage Update();
    
}