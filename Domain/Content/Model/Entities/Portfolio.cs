using Domain.Content.Model.Aggregates;

namespace Domain.Content.Model.Entities;

public partial class Portfolio
{
    public int Id { get;  }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public ICollection<Template> Templates { get; }
}

public partial class Portfolio
{
    public Portfolio()
    {
        Title = string.Empty;
        Description = string.Empty;
        Quantity = 0;
    }
    
    public Portfolio(string title, string description, int quantity)
    {
        Title = title;
        Description = description;
        Quantity = quantity;
    }
    
}