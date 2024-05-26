namespace Application.Monetization.Domain.Model.Aggregates;

public partial class Comision
{
    public int Id { get; set; }
    public double Amount { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
}

public partial class Comision
{
    public Comision()
    {
        Amount = 0.00;
        Content = string.Empty;
        Date = DateTime.Now;
    }
}
