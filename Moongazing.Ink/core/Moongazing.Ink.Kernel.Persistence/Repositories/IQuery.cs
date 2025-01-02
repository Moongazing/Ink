namespace Moongazing.Ink.Kernel.Persistence.Repositories;

public interface IQuery<T>
{
    IQueryable<T> Query();
}
