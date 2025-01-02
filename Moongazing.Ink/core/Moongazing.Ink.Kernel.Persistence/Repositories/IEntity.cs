namespace Moongazing.Ink.Kernel.Persistence.Repositories;

public interface IEntity<T>
{
    T Id { get; set; }
}