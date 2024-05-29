using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Models
{
    public partial class Template : BaseModel
    {
        public Template()
        {
            TemplateStateId = 0;
            TemplateHistoryId = 0;
            PortfolioId = 0;
            Genre = String.Empty;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Date_Publish { get; set; }
        public string Type { get; set; }
        public string ImgUrl { get; set; }
        
        public int TemplateStateId { get; set; }
        
        public int TemplateHistoryId { get; set; }
        
        public int PortfolioId { get; set; }
        public string Genre { get; set; }
    }
}