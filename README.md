### foreword
This project is done to be presented at the final exam after the [ASP.NET Advanced course, October 2024](https://softuni.bg/trainings/4708/asp-net-advanced-october-2024) done at [SoftUni](https://softuni.bg/). 
<br>

### basics
The project is titled **"Farmers Market App"** and is intended to be a local online farmers market place where people can have access to and buy local products from farms across the land, giving each registered user to act as a farmer and in turn offer his own produce to the market. The app should work as a platform and present an easy way for users to take advantage of a streamlined farm-to-table approach for more individual and authentic gastronomic experiences. Who doesn't love a real cheese or a great english breakfast with free-range eggs and grilled sausages, right?
<br>

### setup

The app is written in C# using .NET 8, EF Core, ASP.NET and using MSSQL as the main database. It mainly follows the MVC pattern with Controllers and Razor Views and has a little JS sprinkled here and there for a better UX. For the UI bootstrap is used with the [Slate theme](https://bootswatch.com/slate/), toastr has been implemented, along with some custom vanilla JS scripts.Two API controllers for Farmer and Order have been also implemented - more for practice and a better user experience than for handling any serious business logic. SOLID principles are followed as much as possible and the app is separated into five layers:

```
FarmersMarketApp.Common
FarmersMarketApp.Infrastructure
FarmersMarketApp.Services
FarmersMarketApp.ViewModels
FarmersMarketApp.Web
```

The `.Common` layer holds data validation constants, error messages and notification messages.

The `.Infrastructure` layer holds the `ApplicationDBContext`, the main database `Models`, a `Configuration` folder with separated configurations for each entity, `Datasets` with seed data for `Farm`, `Farmer`, `FarmerFarm` and `Products` in JSON format. DTOs are used for each configuration and can be found in its respective folder. The unit of work pattern which EF uses is the reason an abstracted `IRepository` is implemented in this layer and is used for the `.Services` layer.

The `.Services` layer holds the main business logic of the app. Each entity has its own IService contract and implementation which hold business logic methods. For example, `IFarmerService` provides a method for a regular registered user to become a farmer and handles the logic, separating the repository from the controllers in the `.Web` layer.

The `.ViewModels` layer holds all user-related Razor views and is separated in case of switching to a different front end approach. Currently models are passed from the controllers to the Razor views and all the pages are generated in the backend.

The `.Web` layer holds the main part of the app which brings the previous layers all into one working piece. `Controllers` are mainly used with one `BaseController` which the others inherit mainly to handle authorization in one place using the `[Authorize]` attribute. Each Controller uses instances of appropriate `Services` from the service layer, which are being injected in the constructor via DI. `Extensions` are used to configure the application and clean up the `Program.cs` file with `ServiceCollectionExtensions` handling  configuration of the services and determining their scope, connecting to the db context and configuring the identity and cookies. `Areas` holds the separate controllers and views for the `Admin` role, while in `Program.cs` the Admin role is seeded, Error and area route handling are added. 

##### Configuration to run the app

First off, make sure you have the following NuGet packages:

```
Microsoft.AspNetCore.Identity.UI -v 8.0.11
Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 8.0.11
Microsoft.AspNetCore.Http.Features
Microsoft.AspNetCore.OpenApi -v 8.0.10
Microsoft.EntityFrameworkCore -v 8.0.10
Microsoft.EntityFrameworkCore.SqlServer -v 8.0.11
Microsoft.Extensions.Configuration.UserSecrets -v 6.0.1
System.Text.Json -v 8.0.5
```

These NuGets have been used additionally for development purposes, so they are optional: 
```
Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore -v 8.0.10
Microsoft.EntityFrameworkCore.Tools -v 8.0.11
Microsoft.VisualStudio.Web.CodeGeneration.Design -v 8.0.7
Swashbuckle.AspNetCore -v 6.7.0
```

Currently the db connection string is located in the user secrets.json which is found locally, so first steps are adding your own string in the appsettings.json or to your user secrets like this:

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR-SERVER-NAME-HERE;Database=FarmersMarketApp;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;"
  }
}
```

Next up, for some of the JavaScript modules to work correctly, be sure to add your proper localhost url and port in the `FarmersMarketApp.Web/wwwroot/js/constants.js` file:

```
export const API_URL = "https://localhost:7088/api";
```

Of course, you should have a working internet connection and either Chrome or Firefox browsers installed, where the app has been tested and working.

<br>

### user types and functionality

There are four types of users which the app currently supports:

1. Anonymous users can:
    1. browse products, farms and farmers
    2. view product details - price, producing farm, production and expiration date
    3. view farm details - contact information, address, opening hours
    4. filter results via category, farm, farmer, sorting, search term
2. Regular registered users additionally can:
    1. Add multiple products from multiple farms to their cart
    2. Place orders and pay for them (currently payment works only as a mock-up)
    3. Check state of pending orders once they have "paid" for them
    4. Check details of complete or cancelled orders
    5. Change their email, password and phone number
    6. Apply to become a farmer - after successfully filling out the form the user becomes a pending farmer and needs to be approved by administrator before having the authorization to use full farmer functionality
3. Farmers can:
    1. add multiple farms
    2. add multiple products to each farm
    3. view and manage only products from their own farms in "My products"
    4. view and manage only their own farms in "My farms"
    3. soft delete individual products - keeps producing farm active, removes all products from orders which are not yet placed
    4. soft delete individual farms - also soft deletes all products by this farm to ensure consistency
    5. view each order with only the products that they produce via "My Orders"
    6. complete or cancel each order
    7. Change their email, password and phone number
4. Administrators can:
    1. manage products - delete or restore individual products
    2. manage farms - delete or restore individual farms and their products
    3. manage farmers - approve pending farmers and delete/restore already approved farmers
    4. Change their email, password and phone number
<br>

### epilogue
This is by no means the most thorough markdown with how the app works and how it should be used but it is intended to give the general idea without diving explicitly into the smallest details. It will be updated at some point in the future with more images and examples but by then - feel free to test and share any feedback, ideas, bugs, pull requests and so on. Salute!
