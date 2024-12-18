﻿using FarmersMarketApp.Infrastructure.Data.Models;

namespace FarmersMarketApp.ViewModels.FarmViewModels
{
	public class FarmInfoViewModel
	{
		public string Id { get; set; } = null!;
		public string Name { get; set; } = null!;

		public string? ImageUrl { get; set; }

		public string Address { get; set; } = null!;

		public string City { get; set; } = null!;

		public string? Email { get; set; }
		public string? PhoneNumber { get; set; }

		public string? OpenHours { get; set; }

		public string? CloseHours { get; set; }

		public bool IsOpen
		{
			get
			{
				if (!string.IsNullOrEmpty(OpenHours) && !string.IsNullOrEmpty(CloseHours))
				{
					//edge case when farm works until midnight or early hours on the next day
					if (TimeOnly.Parse(OpenHours) > TimeOnly.Parse(CloseHours))
					{
						return TimeOnly.Parse(OpenHours) < TimeOnly.FromDateTime(DateTime.Now);
					}

					//regular case when farm is open and closes on the same day
					return TimeOnly.Parse(OpenHours) < TimeOnly.FromDateTime(DateTime.Now)
						   && TimeOnly.Parse(CloseHours) > TimeOnly.FromDateTime(DateTime.Now);
				}

				//if no hours have been set
				return false;
			}
		}

		public virtual ICollection<FarmerFarm> FarmersFarms { get; set; } = new List<FarmerFarm>();

		public virtual ICollection<Product> Products { get; set; } = new List<Product>();

		public bool IsDeleted { get; set; }
	}
}
