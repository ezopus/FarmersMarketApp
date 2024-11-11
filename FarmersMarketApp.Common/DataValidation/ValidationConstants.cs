namespace FarmersMarketApp.Common.DataValidation
{
	public static class ValidationConstants
	{
		public const string TimeRequiredFormat = "HH:mm";
		public const string DateTimeRequiredFormat = "dd-MM-yyyy";
		public static class ApplicationUserValidation
		{
			public const int FirstNameMinLength = 2;
			public const int FirstNameMaxLength = 100;
			public const int LastNameMinLength = 2;
			public const int LastNameMaxLength = 100;
			public const int AddressMinLength = 5;
			public const int AddressMaxLength = 100;
			public const int CityMinLength = 3;
			public const int CityMaxLength = 30;
			public const int PhoneMixLength = 4;
			public const int PhoneMaxLength = 17;
			public const string PhoneNumberRegex = @"\+?[\d]{4,17}";
		}

		public static class ProductValidation
		{
			public const int ProductNameMaxLength = 60;
			public const int ProductNameMinLength = 2;

			public const int ProductDescriptionMinLength = 5;
			public const int ProductDescriptionMaxLength = 500;

			public const double ProductSizeMin = 0.01;
			public const double ProductSizeMax = 1000;

			public const double ProductQuantityMin = 0.001;
			public const double ProductQuantityMax = 1000;

			public const double ProductWeightMin = 0.001;
			public const double ProductWeightMax = 1000;

			public const string ProductPriceMin = "0.001";
			public const string ProductPriceMax = "10000";

		}

		public static class FarmValidation
		{
			public const int FarmNameMinLength = 5;
			public const int FarmNameMaxLength = 150;

			public const int FarmAddressMinLength = 6;
			public const int FarmAddressMaxLength = 200;

			public const int FarmCityMinLength = 3;
			public const int FarmCityMaxLength = 30;

		}

		public static class FarmerValidation
		{
			public const int CompanyNameMinLength = 2;
			public const int CompanyNameMaxLength = 100;

			public const int CompanyRegistrationNumberMinLength = 9;
			public const int CompanyRegistrationNumberMaxLength = 10;
			public const string CompanyRegistrationNumberRegex = @"[\d]{9,10}";

			public const int CompanyAddressMinLength = 5;
			public const int CompanyAddressMaxLength = 120;

		}
	}
}
