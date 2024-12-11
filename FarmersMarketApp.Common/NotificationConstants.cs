namespace FarmersMarketApp.Common
{
	public static class NotificationConstants
	{
		// TOASTER TYPES
		public const string SuccessMessage = "Success";
		public const string ErrorMessage = "Error";
		public const string InfoMessage = "Info";
		public const string WarningMessage = "Warning";

		// FARMER
		public const string SuccessfullyApproveFarmer = "Successfully approved farmer!";
		public const string FailedApproveFarmer = "Failed to approve farmer!";

		public const string SuccessfullyRestoreFarmer = "Successfully restored farmer!";
		public const string SuccessfullyRestoreFarmerEntities = "Successfully restored farmer and all his farms and products!";
		public const string FailedRestoreFarmer = "Failed to restore farmer!";

		public const string SuccessfullyDeleteFarmer = "Successfully deleted farmer!";
		public const string SuccessfullyDeleteFarmerEntities = "Successfully deleted farmer and his entities!";
		public const string FailedDeleteFarmer = "Failed to delete farmer!";

		public const string AlreadyFarmer = "You are already a farmer.";

		public const string SuccessfullyApplyToBeFarmer = "You have successfully applied to become a farmer!";
		public const string FailedToApplyToBeFarmer = "Sorry, you can't become a farmer now.";

		public const string FailedToApplyToBeFarmerUserHasOpenOrders =
			"Sorry, you cannot apply to be a farmer while you have open orders.";

		public const string RegisterFirstToBecomeFarmer = "Please register first to apply for becoming a farmer";


		// FARM
		public const string SuccessfullyAddFarm = "Successfully added farm {0}!";
		public const string FailedAddFarm = "Failed to add farm {0}!";

		public const string SuccessfullyEditFarm = "Successfully edited farm {0}!";
		public const string FailedEditFarm = "Failed to edit farm {0}!";

		public const string SuccessfullyDeleteFarm = "Farm and all it's products successfully deactivated.";
		public const string FailedDeleteFarm = "Could not find farm to deactivate.";
		public const string SuccessfullyRestoreFarm = "Farm and all it's products successfully restored.";
		public const string FailedRestoreFarm = "Could not find farm to restore.";

		// PRODUCT
		public const string SuccessfullyAddProduct = "You have successfully added your product - {0}";
		public const string FailedAddProduct = "Failed to add product - {0}. Please check input fields and try again.";

		public const string SuccessfullyEditProduct = "You have successfully edited your product - {0}";
		public const string FailedEditProduct = "Failed to edit product - {0}. Please check input fields and try again.";

		public const string SuccessfullyDeleteProduct = "You have successfully deleted your product - {0}";
		public const string FailedDeleteProduct = "Failed to delete product - {0}.";

		public const string SuccessfullyRestoreProduct = "You have successfully restored your product - {0}";
		public const string FailedRestoreProduct = "Failed to restore product - {0}.";

		public const string SuccessfullyAddProductToCart = "Product successfully added to your cart!";
		public const string ErrorProductAmountNegativeNumber = "Product cannot be negative number.";
		public const string ErrorProductAmountTooMuch = "Products are limited to 30 pieces for each order. Consider going wholesale.";

		// PAYMENT
		public const string PaymentSuccessful = "Your payment method was successful. Please check order for details.";
		public const string PaymentFailed = "Your payment failed. Please try again.";
		public const string PaymentCardFailed = "Your card payment failed. Please check details and try again.";
	}
}
