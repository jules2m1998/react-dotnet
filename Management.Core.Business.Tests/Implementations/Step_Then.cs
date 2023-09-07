using Management.Core.Business.Tests.Contexts;

namespace Management.Api.Tests.Implementations;

[Binding]
public class Step_Then
{
    private readonly PaginationContext context;

    public Step_Then(PaginationContext context)
    {
        this.context = context;
    }

    [Then(@"Pagination list must have pageSize = (.*)")]
    public void ThenPaginationListMustHavePageSize(int lPageSize)
    {
        Assert.Equal(lPageSize, context.PagedList.PageSize);
    }

    [Then(@"Page number = (.*)")]
    public void ThenPageNumber(int lPageNumber)
    {
        Assert.Equal(lPageNumber, context.PagedList.PageNumber);
    }

    [Then(@"Current page size = (.*)")]
    public void ThenCurrentPageSize(int currentPageSize)
    {
        Assert.Equal(currentPageSize, context.PagedList.CurrentPageSize);
    }

    [Then(@"Current start index = (.*)")]
    public void ThenCurrentStartIndex(int currentStartIndex)
    {
        Assert.Equal(currentStartIndex, context.PagedList.CurrentStartIndex);
    }

    [Then(@"Current end index = (.*)")]
    public void ThenCurrentEndIndex(int currentEndIndex)
    {
        Assert.Equal(currentEndIndex, context.PagedList.CurrentEndIndex);
    }

    [Then(@"Total page = (.*)")]
    public void ThenTotalPage(int lTotalPages)
    {
        Assert.Equal(lTotalPages, context.PagedList.TotalPages);
    }
    [Then(@"Has previous is (.*)")]
    public void ThenHasPreviousIs(int @bool)
    {
        Assert.Equal(@bool == 1, context.PagedList.HasPrevious);
    }

    [Then(@"Has next is (.*)")]
    public void ThenHasNextIs(int @bool)
    {
        Assert.Equal(@bool == 1, context.PagedList.HasNext);
    }
}
