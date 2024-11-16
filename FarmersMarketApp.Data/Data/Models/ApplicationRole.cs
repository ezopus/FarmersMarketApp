using Microsoft.AspNetCore.Identity;

namespace FarmersMarketApp.Infrastructure.Data.Models
{
	public class ApplicationRole : IdentityRole<Guid>
	{
		public ApplicationRole()
			: base()
		{

		}

		public ApplicationRole(string role)
			: base(role)
		{

		}
	}
}
