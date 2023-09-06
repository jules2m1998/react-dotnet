using Management.Core.Business.Tests.Contexts;
using TechTalk.SpecFlow.Assist;

namespace Management.Api.Tests.Implementations;

[Binding]
public class Step_Given
{
    private readonly PaginationContext context;

    public Step_Given(PaginationContext context)
    {
        this.context = context;
    }

    [Given(@"The following array is provide for pagination")]
    public void GivenTheFollowingArrayIsProvideForPagination(Table table)
    {
        var data = table.CreateSet<Result>();
        context.Items = data.Select(x => x.Data).AsQueryable();
    }
}

class Result
{
    public int Data { get; set; }
}
