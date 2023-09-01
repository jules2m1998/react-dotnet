using Management.Core.Domain.Tests.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Core.Domain.Tests.Implementations;

[Binding]
public class Step_Then
{
    private readonly TestContext _testContext;
    public Step_Then(TestContext testContext)
    {
        _testContext = testContext;
    }
    [Then(@"I got (.*)")]
    public void ThenIGot(int p0)
    {
        var total = _testContext.X1 + _testContext.X2;
        Assert.Equal(p0, total);
    }
}
