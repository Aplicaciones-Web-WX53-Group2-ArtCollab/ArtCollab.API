namespace Application.Response;

public class CommentResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Rank { get; set; }
    public int Likes { get; set; } 
    public int Dislikes { get; set; } 
    public DateTime Date { get; set; }
}