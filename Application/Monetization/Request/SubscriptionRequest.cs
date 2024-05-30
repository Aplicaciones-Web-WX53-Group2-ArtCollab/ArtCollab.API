using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Monetization.Request;

public class SubscriptionRequest
{
    [Required]
    [DefaultValue(false)]
    public bool isActive { get; set; }
}