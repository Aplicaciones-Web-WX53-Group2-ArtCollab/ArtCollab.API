namespace Infraestructure.Models
{
    public partial class Book
    {
        public Book()
        {
            this.Title = string.Empty;
            this.Description = string.Empty;
            this.Date_Publish = new DateTime();
            this.Type = string.Empty;
            this.ImgUrl = string.Empty;
            this.TemplateState_Id = 0;
            this.TemplateHistory_Id = 0;
            this.Id = 0;
            this.Portfolio_Id = 0;
            this.Genre = string.Empty;
        }
    }

    public partial class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date_Publish { get; set; }
        public string Type { get; set; }
        public string ImgUrl { get; set; }
        public int TemplateState_Id { get; set; }
        public int TemplateHistory_Id { get; set; }
        public int Id { get; set; }
        public int Portfolio_Id { get; set; }
        public string Genre { get; set; }
    }
}