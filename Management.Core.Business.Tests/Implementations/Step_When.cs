using Management.Core.Business.Tests.Contexts;
using Management.Core.Business.Wrappers;

namespace Management.Api.Tests.Implementations;

[Binding]
public class Step_When
{
    private readonly PaginationContext context;

    public Step_When(PaginationContext context)
    {
        this.context = context;
    }

    [When(@"Pagination list is created with (.*) and (.*)")]
    public void WhenPaginationListIsCreatedWithAnd(int pageNumber, int pageSize)
    {
        context.PagedList = PagedList<int>.Create(context.Items,pageNumber, pageSize);
    }
}
