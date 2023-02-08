using System.ComponentModel.DataAnnotations;
using Data.ValueObjects;

namespace NetApi.Models.DTOs.Movie;

public class ReadMovieDTO
{    
    public int Id {get; set;}
    public string? Title {get; set;}
    public Gender Gender {get; set;}
    public int Duration {get; set;}
}