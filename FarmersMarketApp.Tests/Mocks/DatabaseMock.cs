using FarmersMarketApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FarmersMarketApp.Tests.Mocks
{
	public static class DatabaseMock
	{
		public static ApplicationDbContext ContextInstance
		{
			get
			{
				var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
					.UseInMemoryDatabase("FarmersMarketInMemoryDb" + DateTime.Now)
					.Options;

				return new ApplicationDbContext(dbContextOptions);
			}

		}
	}
}
