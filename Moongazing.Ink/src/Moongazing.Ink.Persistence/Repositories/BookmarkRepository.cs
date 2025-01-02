using Moongazing.Ink.Application.Repositories;
using Moongazing.Ink.Domain.Entities;
using Moongazing.Ink.Kernel.Persistence.Repositories;
using Moongazing.Ink.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moongazing.Ink.Persistence.Repositories;

public class BookmarkRepository : EfRepositoryBase<BookmarkEntity, Guid, BaseDbContext>,IBookmarkRepository
{
    public BookmarkRepository(BaseDbContext context):base(context)
    {

    }
}
