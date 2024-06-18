namespace Infrastructure.Monetization.Model.Aggregates;

public partial class Payment
{
    public string Type { get; set; }
    public bool Status { get; set; }
    
}

public partial class Payment
{
    public Payment()
    {
        Type = string.Empty;
        Status = false;
    }
}