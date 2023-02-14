using Data.Models;
using Data.Repositories.IRepositories;
using Microsoft.Extensions.Logging;

namespace Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{    
    public UserRepository(DataContext context, ILogger logger) : base(context, logger)
    {
    }
}