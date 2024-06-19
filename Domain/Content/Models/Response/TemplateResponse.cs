namespace Domain.Content.Models.Response;

public class TemplateResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date_Publish { get; set; }
    public string Type { get; set; }
    public string ImgUrl { get; set; }
    public int TemplateState_id { get; set; }
    public int TemplateHistory_id { get; set; }
    public int Portfolio_id { get; set; }
    public string Genre { get; set; }
}