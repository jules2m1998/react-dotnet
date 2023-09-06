using Management.Core.Business.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Core.Business.Tests.Contexts;

public class PaginationContext
{
    public IQueryable<int> Items { get; set; } = null!;
    public PagedList<int> PagedList { get; set; } = null!;
}
