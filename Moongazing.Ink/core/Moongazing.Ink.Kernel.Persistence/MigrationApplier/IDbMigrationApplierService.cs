using Microsoft.EntityFrameworkCore;

namespace Moongazing.Ink.Kernel.Persistence.MigrationApplier;

public interface IDbMigrationApplierService
{
    void Initialize();
}

public interface IDbMigrationApplierService<TDbContext> : IDbMigrationApplierService
    where TDbContext : DbContext
{


}

