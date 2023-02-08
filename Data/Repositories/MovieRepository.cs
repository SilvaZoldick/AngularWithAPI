using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Models;
using Data.Repositories.IRepositories;
using Microsoft.Extensions.Logging;

namespace Data.Repositories;

public class MovieRepository : Repository<Movie>, IMovieRepository
{    
    public MovieRepository(DataContext context, ILogger logger) : base(context, logger)
    {
    }
}