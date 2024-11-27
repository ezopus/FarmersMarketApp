namespace FarmersMarketApp.Common
{
	public static class NotificationConstants
	{
		public const string SuccessMessage = "Success";
		public const string ErrorMessage = "Error";
		public const string InfoMessage = "Info";
		public const string WarningMessage = "Warning";


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


		public const string SuccessfullyAddFarm = "Successfully added farm {0}!";
		public const string FailedAddFarm = "Failed to add farm {0}!";

		public const string SuccessfullyEditFarm = "Successfully edited farm {0}!";
		public const string FailedEditFarm = "Failed to edit farm {0}!";

		public const string SuccessfullyAddProduct = "You have successfully added your product - {0}";
		public const string FailedAddProduct = "Failed to add product - {0}. Please check input fields and try again.";

		public const string SuccessfullyEditProduct = "You have successfully edited your product - {0}";
		public const string FailedEditProduct = "Failed to edit product - {0}. Please check input fields and try again.";

		public const string SuccessfullyDeleteProduct = "You have successfully deleted your product - {0}";
		public const string FailedDeleteProduct = "Failed to delete product - {0}.";

		public const string SuccessfullyRestoreProduct = "You have successfully restored your product - {0}";
		public const string FailedRestoreProduct = "Failed to restore product - {0}.";
	}
}
