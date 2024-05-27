namespace Infraestructure.Models;

public class Comment : BaseModel
{
    public string Name { get; set; }
    public string Image { get; set; }
    public string Content { get; set; }
    public string Rank { get; set; }
    public int Likes { get; set; } = 0;
    public int Dislikes { get; set; } = 0;
}