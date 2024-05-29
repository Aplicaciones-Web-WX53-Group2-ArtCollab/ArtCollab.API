using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Models;

public partial class Template_History : BaseModel
{
    public Template_History()
    {
        ModifiedAt = DateTime.Now;
        DeleteAt = DateTime.Now;
    }
    
    [Column("Modified_At")]
    public DateTime ModifiedAt { get; set; }
    
    [Column("Delete_At")]
    public DateTime DeleteAt { get; set; }
}