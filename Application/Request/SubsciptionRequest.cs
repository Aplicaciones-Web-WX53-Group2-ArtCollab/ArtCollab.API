using System.ComponentModel.DataAnnotations;

namespace Application.Request;

public class SubsciptionRequest
{
    [Required] 
    [MaxLength(50)]
    public int UserId { get; set; }
    
    [Required] 
    [MaxLength(150)]
    public int Type { get; set; }
    
    [Required] 
    [MaxLength(50)]
    public decimal Price { get; set; }
    
    
}