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
    }
}