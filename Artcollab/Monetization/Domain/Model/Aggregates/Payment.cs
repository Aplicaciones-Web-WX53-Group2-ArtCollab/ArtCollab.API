namespace Application.Monetization.Domain.Model.Aggregates;

public partial class Payment
{
    public string Type { get; set; }
    
}

public partial class Payment
{
    public Payment()
    {
        Type = " ";
    }
}