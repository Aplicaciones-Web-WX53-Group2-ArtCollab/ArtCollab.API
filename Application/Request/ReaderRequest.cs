using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Application.Request;

public class ReaderRequest
{
    [Required]
    [MaxLength(120)]
    public string Name { get; set; }

    [Required]
    [MaxLength(20)]
    public string UserName { get; set; }

    [Required]
    [MaxLength(120)]
    [DefaultValue("user@example.com")]
    [RegularExpression(@"^[\w-.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email format")] //Regular expression for email format validation: @, domain, and extension
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    [MaxLength(16)]
    public string Password { get; set; }

    [Required]
    [MaxLength(120)]
    [DefaultValue("Reader")]
    public string Type { get; set; }

    [Required]
    [MaxLength(120)]
    [DefaultValue("https://randomuser.me/api/portraits/thumb/men/15.jpg")]
    public string ImgUrl { get; set; }
}