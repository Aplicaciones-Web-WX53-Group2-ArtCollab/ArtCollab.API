using Infrastructure.Shared.Model;

namespace Infrastructure.Collaboration.Model;

public class Comment : BaseModel
{
    public string Name { get; set; }
    public string Image { get; set; }
    public string Content { get; set; }
    public string Rank { get; set; }
    public int Likes { get; set; } = 0;
    public int Dislikes { get; set; } = 0;
    public DateTime Date { get; set; }
}