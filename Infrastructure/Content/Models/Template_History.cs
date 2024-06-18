using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Shared.Model;

namespace Infrastructure.Content.Models;

public partial class Template_History : BaseModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime Modified_at { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime Delete_at { get; set; }
}