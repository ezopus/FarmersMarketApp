// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using FarmersMarketApp.Infrastructure.Data.Models;
using FarmersMarketApp.Infrastructure.Repositories.Contracts;
using FarmersMarketApp.Services.Contracts;
using FarmersMarketApp.Web.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using static FarmersMarketApp.Common.NotificationConstants;


namespace FarmersMarketApp.Web.Areas.Identity.Pages.Account.Manage
{
	public class IndexModel : PageModel
	{
		private readonly IRepository _repository;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IFarmerService _farmerService;

		public IndexModel(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			IFarmerService farmerService,
			IRepository repository)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_farmerService = farmerService;
			_repository = repository;
		}

		protected IndexModel()
		{

		}

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public string Username { get; set; }



		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		[TempData]
		public string StatusMessage { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		[BindProperty]
		public InputModel Input { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public class InputModel
		{
			/// <summary>
			///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
			///     directly from your code. This API may change or be removed in future releases.
			/// </summary>
			[Phone]
			[Display(Name = "Phone number")]
			public string PhoneNumber { get; set; }

		}

		public IFormFile ImageFile { get; set; }

		private async Task LoadAsync(ApplicationUser user)
		{
			var userName = await _userManager.GetUserNameAsync(user);
			var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

			Username = userName;

			Input = new InputModel
			{
				PhoneNumber = phoneNumber,
			};
		}

		public async Task<IActionResult> OnGetAsync()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
			}

			await LoadAsync(user);

			return Page();
		}

		public async Task<IActionResult> OnPostAsync([FromForm] IFormFile formFile)
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
			}

			if (!ModelState.IsValid)
			{
				await LoadAsync(user);
				return Page();
			}

			var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
			if (Input.PhoneNumber != phoneNumber)
			{
				var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
				if (!setPhoneResult.Succeeded)
				{
					StatusMessage = "Unexpected error when trying to set phone number.";
					TempData[ErrorMessage] = StatusMessage;
					return RedirectToPage();
				}
			}


			//handle file upload
			var newFilePath = string.Empty;
			if (formFile != null && formFile.Length > 0)
			{
				var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
				var fileExtension = Path.GetExtension(formFile.FileName).ToLower();

				if (!allowedExtensions.Contains(fileExtension))
				{
					ModelState.AddModelError(nameof(formFile), "Only JPG, JPEG, and PNG files are allowed.");
					return Page();
				}

				if (formFile.Length > 2 * 1024 * 1024) // 2 MB limit
				{
					ModelState.AddModelError(nameof(formFile), "The file size cannot exceed 2 MB.");
					return Page();
				}

				var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
				var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(formFile.FileName)}";
				var filePath = Path.Combine(uploadsFolder, uniqueFileName);

				using (var stream = new FileStream(filePath, FileMode.Create))
				{
					await formFile.CopyToAsync(stream);
				}
				//add the relative path to the model.ImageUrl for database storage
				newFilePath = $"/uploads/{uniqueFileName}";
				var currentUserId = User.GetId();
				var currentUser = await _userManager.GetUserAsync(User);
				var currentFarmerId = await _farmerService.GetFarmerIdByUserIdAsync(currentUserId);
				if (!string.IsNullOrEmpty(currentFarmerId))
				{
					var currentFarmer = await _repository.GetByIdAsync<Farmer>(Guid.Parse(currentFarmerId));
					if (currentFarmer != null && currentUser != null)
					{
						currentUser.ImageUrl = newFilePath;
						currentFarmer.ImageUrl = newFilePath;
						await _repository.SaveChangesAsync();
					}
				}
				if (currentUser != null)
				{
					currentUser.ImageUrl = newFilePath;
					await _repository.SaveChangesAsync();
				}
			}


			await _signInManager.RefreshSignInAsync(user);
			StatusMessage = "Your profile has been updated";
			TempData[SuccessMessage] = StatusMessage;

			return RedirectToPage();
		}
	}
}
