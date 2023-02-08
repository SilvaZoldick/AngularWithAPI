using System.ComponentModel.DataAnnotations;
using Data.ValueObjects;

namespace NetApi.Models.DTOs.Movie;

public class UpdateMovieDTO
{
    [Required(ErrorMessage = "O título é obrigatório")]
    [StringLength(50, ErrorMessage = "O campo título não pode exceder 50 caracteres")]
    public string? Title {get; set;}
    
    [Required(ErrorMessage = "O gênero é obrigatório")]
    public string Gender {get; set;}
    
    [Required(ErrorMessage = "A duração é obrigatória")]
    [StringLength(70, ErrorMessage = "A duração deve ser entre 70 e 600 minutos")]
    public string Duration {get; set;}
}