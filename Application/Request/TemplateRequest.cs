using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Request;

public class TemplateRequest
{
    [Required] 
    [MaxLength(50)]
    public string Title { get; set; }
    
    [Required] 
    [MaxLength(500)]
    public string Description { get; set; }
    
    [Required] 
    [MaxLength(120)]
    public string Type { get; set; }
    
    
    [Required] 
    [MaxLength(120)]
    public string ImgUrl { get; set; }
    
    
    public string Genre { get; set; }
}