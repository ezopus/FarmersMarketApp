using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Tests.Mocks
{
	public static class DatabaseMock
	{
		public static TestApplicationDbContext ContextInstance
		{
			get
			{
				var dbContextOptions = new DbContextOptionsBuilder<TestApplicationDbContext>()
					.UseInMemoryDatabase("FarmersMarketInMemoryDb" + DateTime.Now.Ticks.ToString())
					.Options;

				return new TestApplicationDbContext(dbContextOptions);
			}

		}
	}
}
