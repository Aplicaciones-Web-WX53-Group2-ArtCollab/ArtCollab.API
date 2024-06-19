using System.ComponentModel.DataAnnotations.Schema;
using Domain.Shared.Models.Entities;

namespace Domain.Content.Models.Aggregate;

public partial class Template : BaseModel
{
    public string Title { get; set; }
    public string Description { get; set; }
        
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime Date_Publish { get; set; }
    public string Type { get; set; }
    public string ImgUrl { get; set; }
        
    public int TemplateState_id { get; set; }
        
    public int TemplateHistory_id { get; set; }
        
    public int Portfolio_id { get; set; }
    public string Genre { get; set; }
}