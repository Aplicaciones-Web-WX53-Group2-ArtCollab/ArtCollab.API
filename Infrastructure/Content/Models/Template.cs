using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Shared.Model;

namespace Infrastructure.Content.Models
{
    public partial class Template : BaseModel
    {
        public Template() {}

        public string Title { get; set; }
        public string Description { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Date_Publish { get; set; }
        public string Type { get; set; }
        public string ImgUrl { get; set; }
        
        public int TemplateState_id { get; set; }
        
        public int Template_History_id { get; set; }
        
        public int Portfolio_id { get; set; }
        public string Genre { get; set; }
    }
}