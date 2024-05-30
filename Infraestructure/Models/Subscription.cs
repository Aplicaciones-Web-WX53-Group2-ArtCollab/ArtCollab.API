namespace Infraestructure.Models;

public partial class Subscription :BaseModel
{
    public int UserId { get; set; }
    public int Type { get; set; }
    public decimal Price { get; set; }
    public DateTime DatePayed { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateFinish { get; set; }
}