using Microsoft.AspNetCore.Mvc;
using Data.Models;
using Data.Repositories.IRepositories;
using AutoMapper;
using NetApi.Models.DTOs.Movie;

namespace NetApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IUnitOfWork UnitOfWork;
    private readonly IMapper Mapper;

    public MoviesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        UnitOfWork = unitOfWork;
        Mapper = mapper;
    }

    [HttpGet]    
    public async Task<IActionResult> Get()
    {
        IEnumerable<Movie> moviesList = await UnitOfWork.MovieRepo.GetAllAsync();
        List<ReadMovieDTO> movieDTOList = new List<ReadMovieDTO>();
        foreach(var movie in moviesList){
            movieDTOList.Add(Mapper.Map<ReadMovieDTO>(movie));
        }
        return Ok(movieDTOList);
    }
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Movie? movie = await UnitOfWork.MovieRepo.GetAsync(i => i.Id == id);
        try{
            var movieDTO = Mapper.Map<ReadMovieDTO>(movie);
            if (movie is null) return NotFound();
            return Ok(movieDTO);
        }
        catch(Exception ex){
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]    
    public async Task<IActionResult> AddAsync([FromBody] CreateMovieDTO movieDTO)
    {
        if(!ModelState.IsValid)    
            return new JsonResult(movieDTO){StatusCode = 500};
            
        Movie movie = Mapper.Map<Movie>(movieDTO);
        await UnitOfWork.MovieRepo.AddAsync(movie);
        await UnitOfWork.CommitAsync();
        return CreatedAtAction(nameof(Index), new {Id = movie.Id}, movie);
    }
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateMovie(int id, [FromBody] UpdateMovieDTO movieDTO)
    {
        Movie? movie = await UnitOfWork.MovieRepo.GetAsync(m => m.Id == id);
        if (movie is null) return NotFound();
        Mapper.Map(movieDTO, movie);
        UnitOfWork.MovieRepo.Update(movie);
        await UnitOfWork.CommitAsync();
        return NoContent();
    }
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        await UnitOfWork.MovieRepo.DeleteAsyncById(id);
        await UnitOfWork.CommitAsync();
        return Ok(null);
    }
}