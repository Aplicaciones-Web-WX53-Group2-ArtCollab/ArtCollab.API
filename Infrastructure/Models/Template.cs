using System.ComponentModel.DataAnnotations.Schema;

namespace Infraestructure.Models
{
    public partial class Template : BaseModel
    {
        public Template()
        {
            Date_Publish = DateTime.Now;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date_Publish { get; set; }
        public string Type { get; set; }
        public string ImgUrl { get; set; }
        
        [Column("TemplateState_Id")]
        public int TemplateStateId { get; set; }
        
        [Column("TemplateHistory_Id")]
        public int TemplateHistoryId { get; set; }
        
        [Column("Portfolio_Id")]
        public int PortfolioId { get; set; }
        public string Genre { get; set; }
    }
}