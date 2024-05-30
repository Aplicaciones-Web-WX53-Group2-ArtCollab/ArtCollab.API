using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Monetization.Request;

public class CommisionRequest
{
    [Required]
    [DefaultValue(" ")]
    public string content { get; set; }
    
    [Required]
    [DefaultValue(0.00)]
    public double amount { get; set; }
}