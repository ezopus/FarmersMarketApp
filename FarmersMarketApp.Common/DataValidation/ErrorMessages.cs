﻿namespace FarmersMarketApp.Common.DataValidation
{
	public static class ErrorMessages
	{
		public const string ErrorUserFirstName = "First name must be between 2 and 100 symbols.";
		public const string ErrorUserLastName = "Last name must be between 2 and 100 symbols.";
		public const string ErrorUserAddress = "Address must be between 5 and 100 symbols.";


		public const string ErrorProductName = "Product name must be between 2 and 60 symbols.";
		public const string ErrorProductDescription = "Product description must be between 10 and 500 symbols.";
		public const string ErrorProductQuantity = "Product quantity must be positive integer.";
		public const string ErrorProductWeight = "Product weight must be positive integer.";

		public const string ErrorFarmName = "Farm name must be between 5 and 150 symbols.";
		public const string ErrorFarmAddress = "Farm address must be between 6 and 200 symbols.";
		public const string ErrorFarmCity = "Farm city must be between 3 and 30 symbols.";

		public const string ErrorFarmerCompanyName = "Company name must be between 2 and 100 symbols.";
		public const string ErrorFarmerCompanyRegistrationNumberLength = "Company number must be between 9 and 10 digits.";
		public const string ErrorFarmerCompanyRegistrationNumberType = "Company number must consist only of digits.";
		public const string ErrorFarmerCompanyAddress = "Company address must be between 5 and 120 symbols.";
		public const string ErrorAcceptDeliveriesNotSelected = "Please indicate if you are open for business.";

	}
}
