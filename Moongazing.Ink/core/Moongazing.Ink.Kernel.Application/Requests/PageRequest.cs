using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moongazing.Ink.Kernel.Application.Requests;

public class PageRequest
{
    public int PageIndex { get; set; } = default!;
    public int PageSize { get; set; } = default!;
}
