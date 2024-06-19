namespace Domain.User.Model.Aggregates;

public partial class Reader
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Type { get; set; }
    public string ImgUrl { get; set; }
}

public partial class  Reader
{
    public Reader()
    {
        Name = string.Empty;
        UserName = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
        Type = string.Empty;
        ImgUrl = string.Empty;
    }
}