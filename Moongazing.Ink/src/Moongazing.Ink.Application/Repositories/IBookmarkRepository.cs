using Moongazing.Ink.Domain.Entities;
using Moongazing.Ink.Kernel.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moongazing.Ink.Application.Repositories
{
    public interface IBookmarkRepository: IAsyncRepository<BookmarkEntity, Guid>, IRepository<BookmarkEntity, Guid>
    {
    }
}
