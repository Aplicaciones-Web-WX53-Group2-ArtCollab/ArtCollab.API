﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain.Content.Models.Commands;

public class UpdateTemplateCommand
{
    [Required] 
    public int Id { get; set; }
    
    [Required] 
    [MaxLength(50)]
    public string Title { get; set; }
    
    [Required] 
    [MaxLength(500)]
    public string Description { get; set; }
    
    [Required] 
    [MaxLength(120)]
    public string Type { get; set; }
    
    [Required] 
    [MaxLength(120)]
    [DefaultValue("https://example.com/image.jpg")]
    public string ImgUrl { get; set; }
    
    [DefaultValue(" ")]
    public string Genre { get; set; }
}