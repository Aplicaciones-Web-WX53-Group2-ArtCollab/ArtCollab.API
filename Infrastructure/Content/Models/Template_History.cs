using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Models;

public partial class Template_History : BaseModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime ModifiedAt { get; set; }
    
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime DeleteAt { get; set; }
}