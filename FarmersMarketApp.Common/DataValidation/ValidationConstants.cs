﻿namespace FarmersMarketApp.Common.DataValidation
{
    public static class ValidationConstants
    {
        public static class ApplicationUserValidation
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 100;
            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 100;
            public const int AddressMinLength = 5;
            public const int AddressMaxLength = 100;
        }

        public static class ProductValidation
        {
            public const int ProductNameMaxLength = 60;
            public const int ProductNameMinLength = 2;

            public const int ProductDescriptionMinLength = 10;
            public const int ProductDescriptionMaxLength = 500;
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
    }
}
