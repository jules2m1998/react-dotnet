using Management.Core.Domain.Tests.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Core.Domain.Tests.Implementations;

[Binding]
public class Step_When
{
    private readonly TestContext _testContext;
    public Step_When(TestContext testContext)
    {
        _testContext = testContext;
    }

    [When(@"I add (.*)")]
    public void WhenIAdd(int p0)
    {
        _testContext.X2 = p0;
    }
}
