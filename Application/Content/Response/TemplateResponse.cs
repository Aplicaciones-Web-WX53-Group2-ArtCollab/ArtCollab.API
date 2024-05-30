namespace Application.Response;

public class TemplateResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date_Publish { get; set; }
    public string Type { get; set; }
    public string ImgUrl { get; set; }
    public int TemplateStateId { get; set; }
    public int TemplateHistoryId { get; set; }
    public int PortfolioId { get; set; }
    public string Genre { get; set; }
}