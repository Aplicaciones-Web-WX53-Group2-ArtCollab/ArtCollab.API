using Domain.Content.Model.Aggregates;

namespace Domain.Content.Model.Entities;

public  partial class TemplateHistory
{
    public int Id { get; }
    public DateTime ModifiedAt { get;  }
    public DateTime DeleteAt { get;  }
    
    public Template Template { get; }
    
    public int TemplateId { get; }
}

public partial class TemplateHistory
{
    public TemplateHistory()
    {
      Template = new Template();
    }
}