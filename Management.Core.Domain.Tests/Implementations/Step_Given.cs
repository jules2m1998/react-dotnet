using Management.Core.Domain.Tests.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Core.Domain.Tests.Implementations;

[Binding]
public class Step_Given
{
    private readonly TestContext _testContext;
    public Step_Given(TestContext testContext)
    {
        _testContext = testContext;
    }
    [Given(@"(.*)")]
    public void Given(int p0)
    {
        _testContext.X1 = p0;
    }

}
