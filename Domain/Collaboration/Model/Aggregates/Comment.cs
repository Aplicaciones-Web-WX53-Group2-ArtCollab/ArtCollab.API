using Domain.Collaboration.Model.Commands;

namespace Domain.Collaboration.Model.Aggregates;

public partial class Comment 
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime Date { get; set; }
}


public partial class Comment
{
    public Comment()
    {
        Content = string.Empty;
    }

    public Comment(CreateCommentCommand command)
    {
        Content = command.Content;
        Date = DateTime.Now;
    }
}