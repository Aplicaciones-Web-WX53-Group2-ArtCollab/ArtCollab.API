using System.Text.Json.Serialization;

namespace Domain.IAM.Model.Aggregates;

public class Admin(string username, string passwordHash)
{
    public Admin() : this(string.Empty, string.Empty) { }
    public int Id { get; set; }
    
    public string Username { get; private set; } = username;
    
    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;
    
    public Admin UpdateUsername(string username)
    {
        Username = username;
        return this;
    }
    
    public Admin UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }
}