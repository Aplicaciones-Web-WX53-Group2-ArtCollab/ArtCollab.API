using Domain.Content.Model.Aggregates;

namespace Domain.Content.Model.Entities;

public partial class TemplateState
{
    public ICollection<Template> Templates { get; }
    
    public int Id { get; set; }
    public bool Flag { get; set; }
}

public partial class TemplateState
{
    public TemplateState()
    {
        Flag = false;
    }

    public TemplateState(bool flag)
    {
        Flag = flag;
    }
}