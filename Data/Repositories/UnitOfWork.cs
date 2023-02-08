using Data.Repositories.IRepositories;
using Microsoft.Extensions.Logging;

namespace Data.Repositories;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DataContext Context;
    private readonly ILogger Logger;
    public IMovieRepository MovieRepo { get; private set; }
    public UnitOfWork(DataContext context, ILoggerFactory loggerFactory)
    {
        Context = context;
        Logger = loggerFactory.CreateLogger("log");
        MovieRepo = new MovieRepository(Context, Logger);
    }
    public async Task CommitAsync()
    {
        await Context.SaveChangesAsync();
    }   

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if(!this.disposed)
        {
            if(disposing)
            {
                Context.Dispose();
            }
        }
        this.disposed = true;
    }
    public void Dispose()
    {
        Context.Dispose();
    }
}