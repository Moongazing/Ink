using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moongazing.Ink.Persistence.Contexts;

public class BaseDbContext:DbContext
{
    protected IHttpContextAccessor HttpContextAccessor;
    protected IConfiguration Configuration;



    public BaseDbContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(options)
    {
        HttpContextAccessor = httpContextAccessor;
        Configuration = configuration;
    }
}
