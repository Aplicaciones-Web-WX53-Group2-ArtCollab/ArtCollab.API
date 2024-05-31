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
    [DefaultValue("https://example.com/image.jpg")]
    public string ImgUrl { get; set; }
    
    [DefaultValue(" ")]
    public string Genre { get; set; }
    
    [DefaultValue(0)]
    public int TemplateState_id { get; set; }
    
    [DefaultValue(0)]
    public int Template_History_id { get; set; }
    
    [DefaultValue(0)]
    public int Portfolio_id { get; set; }
}