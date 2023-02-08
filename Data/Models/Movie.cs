using System.ComponentModel.DataAnnotations;
using Data.ValueObjects;

namespace Data.Models;

public class Movie
{    
    [Key]
    [Required]
    public int Id {get; set;}
    
    [Required(ErrorMessage = "O título é obrigatório")]
    [MaxLength(50, ErrorMessage = "O campo título não pode exceder 50 caracteres")]
    public string? Title {get; set;}
    
    [Required(ErrorMessage = "O gênero é obrigatório")]
    public Gender Gender {get; set;}
    
    [Required(ErrorMessage = "A duração é obrigatória")]
    [Range(70, 600, ErrorMessage = "A duração deve ser entre 70 e 600 minutos")]
    public int Duration {get; set;}
}