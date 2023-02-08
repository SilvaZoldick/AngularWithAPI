namespace Data.Repositories.IRepositories;
public interface IUnitOfWork
{
    IMovieRepository MovieRepo {get;}
    Task CommitAsync();
}