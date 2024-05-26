using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Model;

public class Reader : BaseModel
{
    [Required]
    [MaxLength(120)]
    public string Name { get; set; }

    [Required]
    [MaxLength(120)]
    public string UserName { get; set; }

    [Required]
    [MaxLength(120)]
    public string Email { get; set; }

    [Required]
    [MaxLength(12)]
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