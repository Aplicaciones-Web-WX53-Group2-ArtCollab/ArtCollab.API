using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Content.Models.Entities;

public partial class TemplateHistory
{
    public int Id {get;set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime Modified_at { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime Delete_at { get; set; }
}