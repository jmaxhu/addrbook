using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using Addrbook.Service;
using Addrbook.Models;

namespace Addrbook.Tests
{
  // see example explanation on xUnit.net website:
  // https://xunit.github.io/docs/getting-started-dotnet-core.html
  public class StuffServiceTest : TestBase, IClassFixture<DatabaseFixture>
  {
    private DatabaseFixture fixture;
    private IStuffService stuffService;

    public StuffServiceTest(DatabaseFixture fixture)
    {
      this.fixture = fixture;
      stuffService = new StuffService(this.fixture.DbContext);
    }

    [Fact]
    public async void AddStuffTest()
    {
      var stuff = new Stuff
      {
        Name = "stuff001",
        DepartmentId = -1
      };

      await Assert.ThrowsAsync<UserFriendlyException>(() => stuffService.Add(null));
      await Assert.ThrowsAsync<UserFriendlyException>(() => stuffService.Add(stuff)); // no cellphone value, wrong DepartmentId

      stuff.CellPhone = "13900910011";
      stuff.Phone = "81702912";
      stuff.Office = "3611";

      var department = fixture.DbContext.Departments.FirstOrDefault();
      Assert.NotNull(department);

      stuff.DepartmentId = department.Id;
      stuff = await stuffService.Add(stuff);
      Assert.True(stuff.Id > 0);

      await Assert.ThrowsAsync<UserFriendlyException>(() => stuffService.Add(stuff)); // same cellphone exception
    }
  }
}
