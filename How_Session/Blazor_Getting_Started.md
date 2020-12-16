# Create a Employee HR Blazor app

1. Create a new Blazor app named EmployeeHR in a command shell:

.NET Core CLI

```Cmd
dotnet new blazorwasm -n EmployeeHR

```

The preceding command creates a folder named EmployeeHR with the -o|--output option to hold the app. The EmployeeHR folder is the root folder of the project. Change directories to the EmployeeHR folder with the following command:

.NET Core CLI

```CMD
cd EmployeeHR
```

2. Add a new EmployeeOverview Razor component to the app using the following command:

.NET Core CLI

```Cmd
dotnet new razorcomponent -n EmployeeOverview -o Pages
```

The -n|--name option in the preceding command specifies the name of the new Razor component. The new component is created in the project's Pages folder with the -o|--output option.

> :sushi: Important
> Razor component file names require a capitalized first letter. Open the Pages folder and confirm that the `EmployeeOverview` component file name starts with a capital letter T. The file name should be `EmployeeOverview.razor`.

3. Open the `EmployeeOverview` component in any file editor and add an @page Razor directive to the top of the file with a relative URL of /EmployeeOverview.

`Pages/EmployeeOverview.razor`:

```razor
@page "/employeeoverview"

<h3>EmployeeOverview</h3>

@code {

}

```

Save the `Pages/EmployeeOverview.razor` file.

4. Add the `EmployeeOverview` component to the navigation bar.

The `NavMenu` component is used in the app's layout. Layouts are components that allow you to avoid duplication of content in an app. The NavLink component provides a cue in the app's UI when the component URL is loaded by the app.

In the unordered list (`<ul>...</ul>`) of the NavMenu component, add the following list item (`<li>...</li>`) and `NavLink` component for the EmployeeOverview component.

In `Shared/NavMenu.razor`:

```razor
<ul class="nav flex-column">

    ...

    <li class="nav-item px-3">
        <NavLink class="nav-link" href="employeeoverview">
            <span class="oi oi-list-rich" aria-hidden="true"></span> EmployeeOverview
        </NavLink>
    </li>
</ul>
```

Save the `Shared/NavMenu.razor` file.

5. Build and run the app by executing the dotnet watch run command in the command shell from the `EmployeeHR` folder. After the app is running, visit the new `EmployeeOverview` page by selecting the `EmployeeOverview` link in the app's navigation bar, which loads the page at `/employeeoverview`.

Leave the app running the command shell. Each time a file is saved, the app is automatically rebuilt. The browser temporarily loses its connection to the app while compiling and restarting. The page in the browser is automatically reloaded when the connection is re-established.

6. Create a folder called Models and Add a Employee.cs file in the Models folder of the project (the EmployeeHR folder) to hold a class that represents a Employee. Use the following C# code for the Employee class.

`Employee.cs`:

```C#
public class Employee
{
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Email { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string PhoneNumber { get; set; }
        public bool Smoker { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public Gender Gender { get; set; }
        public string Comment { get; set; }
        public DateTime? JoinedDate { get; set; }
        public DateTime? ExitDate { get; set; }

        public int JobCategoryId { get; set; }
        public JobCategory JobCategory { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
}
```

Navigate to the `SupportingFiles` folder and copy the files from the Models folder to the Models Folder of the EmployeeHR project.

- Country
- Gender.cs
- JobCategory.cs
- MaritalStatus.cs

7. Return to the `EmployeeOverview` component and perform the following tasks:

- Add unordered list markup and a foreach loop to render each EmployeeOverview item as a list item (`<li>`).
  Pages/EmployeeOverview.razor:

```razor

@page "/employeeoverview"

<h1 class="page-title">All employees</h1>

@if (Employees == null)
{
    <p><em>Loading...</em></p>
}
else
{
    <table class="table">
        <thead>
            <tr>
                <th></th>
                <th>Employee ID</th>
                <th>First name</th>
                <th>Last name</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            @foreach (var employee in Employees)
            {
                <tr>
                    <td>@employee.EmployeeId</td>
                    <td>@employee.FirstName</td>
                    <td>@employee.LastName</td>
                    <td>
                        <a href="@($"employeedetail/{employee.EmployeeId}")" class="btn btn-primary table-btn">
                            <i class="fas fa-info-circle"></i>
                        </a>
                    </td>

                </tr>
            }
        </tbody>
    </table>
}
```

Need to update the index.html in the wwwroot folder to included font awesome.

```html
<script
  src="https://kit.fontawesome.com/273d0585ea.js"
  crossorigin="anonymous"
></script>

<link
  href="https://fonts.googleapis.com/css?family=Ubuntu&display=swap"
  rel="stylesheet"
/>
```

## Code Behind File

8. Add a new class to the the pages folder `EmployeeOverview.cs` this will be the code behind page to remove the code for the view making for cleaner code. We use the partial modifier as IDE will complain that a `EmployeeOverview` class already exist that is because Blazor creates the class for the razor element.

```C#

public partial class EmployeeOverview
    {

		public IEnumerable<Employee> Employees { get; set; }

		private List<Country> Countries { get; set; }

		private List<JobCategory> JobCategories { get; set; }

		protected override Task OnInitializedAsync()
		{

			InitializeCountries();
			InitializeJobCategories();
            InitializeEmployees();

            return base.OnInitializedAsync();



		}


        private void InitializeJobCategories()
		{
			JobCategories = new List<JobCategory>()
	{
		new JobCategory{JobCategoryId = 1, JobCategoryName = "research"},
		new JobCategory{JobCategoryId = 2, JobCategoryName = "Sales"},
		new JobCategory{JobCategoryId = 3, JobCategoryName = "Management"},
		new JobCategory{JobCategoryId = 4, JobCategoryName = "Store staff"},
		new JobCategory{JobCategoryId = 5, JobCategoryName = "Finance"},
		new JobCategory{JobCategoryId = 6, JobCategoryName = "QA"},
		new JobCategory{JobCategoryId = 7, JobCategoryName = "IT"},
		new JobCategory{JobCategoryId = 8, JobCategoryName = "Cleaning"},
		new JobCategory{JobCategoryId = 9, JobCategoryName = "Management"},
		new JobCategory{JobCategoryId = 10, JobCategoryName = "Developer"}
	};
		}

		private void InitializeCountries()
		{
			Countries = new List<Country>
	{
		new Country {CountryId = 1, Name = "Belgium"},
		new Country {CountryId = 2, Name = "Netherlands"},
		new Country {CountryId = 3, Name = "USA"},
		new Country {CountryId = 4, Name = "Japan"},
		new Country {CountryId = 5, Name = "China"},
		new Country {CountryId = 6, Name = "UK"},
		new Country {CountryId = 7, Name = "France"},
		new Country {CountryId = 8, Name = "Brazil"}
	};
		}

		private void InitializeEmployees()
		{
			var e1 = new Employee
			{
				CountryId = 1,
				MaritalStatus = MaritalStatus.Married,
				BirthDate = new DateTime(1969, 3, 20),
				City = "Tampa",
				Email = "timothy.oleson@microsoft.com",
				EmployeeId = 1,
				FirstName = "Tim",
				LastName = "Oleson",
				Gender = Gender.Male,
				PhoneNumber = "324777888773",
				Smoker = false,
				Street = "Good Street",
				Zip = "1000",
				JobCategoryId = 10,
				Comment = "Lorem Ipsum",
				ExitDate = null,
				JoinedDate = new DateTime(2019, 4, 1)
			};

			var e2 = new Employee
			{
				CountryId = 2,
				MaritalStatus = MaritalStatus.Married,
				BirthDate = new DateTime(1979, 1, 16),
				City = "Antwerp",
				Email = "gill@bethanyspieshop.com",
				EmployeeId = 2,
				FirstName = "Gill",
				LastName = "Cleeren",
				Gender = Gender.Female,
				PhoneNumber = "33999909923",
				Smoker = false,
				Street = "New Street",
				Zip = "2000",
				JobCategoryId = 1,
				Comment = "Lorem Ipsum",
				ExitDate = null,
				JoinedDate = new DateTime(2017, 12, 24)
			};
			Employees = new List<Employee> { e1, e2 };
		}
	}

```

# Add Api to Project

In the real world we will be calling to a Microservice or a Web Api to consume data the mock data was fine to get us started but we need to know how to call an external Restful Web Api. So lets add one. I prepared an Api for the exercise so lets go grab it and added it our solution.

In the `Blazor_How_Session` folder Navigate to the `SupportingFiles` folder and copy the `EmployeeHR.Api` folder into the `src` folder.

![img](https://github.com/Onemanwolf/Blazor_How_Session/blob/main/How_Session/Images/CopyEmployeeApi.png)

Add `EmployeeHR.Api` Project to the Solution by right clicking on Solution `EmployeeHR` select Add existing project navigate to the `EmployeeHR.Api` folder that you just copied over in the `src` directory and the inside the `EmployeeHR.Api` Folder select the `EmployeeHR.Api.csproj` file to add the project to the solution.

![img](https://github.com/Onemanwolf/Blazor_How_Session/blob/main/How_Session/Images/AddExistingProject.png)

We will need both projects to run, so lets go ahead and set both projects to startup in the solution properties. Right click solution and select Properties.

![img](https://github.com/Onemanwolf/Blazor_How_Session/blob/main/How_Session/Images/SolutionPropertiesStartup.png)

Now run the app by pressing F5 or the start button on the top ribbon

`<Multiple Startup Projects>` Start.

# Create Services for Data

Create Service to get the Data from api separating the concerns of data retrieval away from the UI components.

Create a folder in the root project called `Services`.

Add two files one for an `interface` called `IEmployeeDataService` and one for a `class`called `EmployeeDataService` the concrete implementation of the `interface`.

Create interface `IEmployeeDataService`

```C#
 public interface IEmployeeDataService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee> GetEmployeeDetails(int employeeId);
        Task<Employee> AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int employeeId);
    }

```

```C#
 public class EmployeeDataService : IEmployeeDataService
    {
        private readonly HttpClient _httpClient;

        public EmployeeDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var employeeJson =
                new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/employee", employeeJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var employeeJson =
                new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/employee", employeeJson);
        }

        public async Task DeleteEmployee(int employeeId)
        {
            await _httpClient.DeleteAsync($"api/employee/{employeeId}");
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Employee>>
                    (await _httpClient.GetStreamAsync($"api/employee"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Employee> GetEmployeeDetails(int employeeId)
        {
            return await JsonSerializer.DeserializeAsync<Employee>
                (await _httpClient.GetStreamAsync($"api/employee/{employeeId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }


    }

```

# Add Http Client Configuration

Install Nuget Package `Microsoft.Extensions.Http` right click on the EmployeeHR and select Manage NuGet packages... Browse tab and search for `Microsoft.Extensions.Http` and install version 5.0.0.

We will add HttpClient factory instead of using the built in version HttpClient implementation.

Navigate to the program.cs class in the EmployeeHR project open the program class.

```C#
        public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }

```

Now lets add the HttpClient Factory instance like below:

```C#


 // builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(client => client.BaseAddress = new Uri("https://localhost:44340"));



```

Dependency injection with the [Inject] attribute in blazor this is the way. "This is the way".

```C#
        [Inject]
		public IEmployeeDataService _services { get; set; }

```

Now replace our methods with the service call `GetAllEmployees` we need to make the `OnInitializedAsync` method `async` and for now comment out the Initialize methods.

```c#
protected override async Task OnInitializedAsync()
		{

			//InitializeCountries();
			//InitializeJobCategories();
			//InitializeEmployees();

			Employees = await _services.GetAllEmployees();

			//return base.OnInitializedAsync();



		}
```

Now run the app and see the data coming from the api.

# Add Employee Details Page

Now we can add Employee details page we see how we pass parameters in or page directive `@page "/employeedetail/{EmployeeId}"` so we can fetch the details data for the employee record by passing the employee id to the service method.

```razor
@page "/employeedetail/{EmployeeId}"

<h1 class="page-title">Details for @Employee.FirstName @Employee.LastName</h1>


<div class="col-12 row">
    <div class="col-2">
        <img src="@($"https://gillcleerenpluralsight.blob.core.windows.net/person/{Employee.EmployeeId}.jpg")" class="img-responsive rounded-circle employee-detail-img" />
    </div>
    <div class="col-10 row">
        <div class="col-xs-12 col-sm-8">
            <div class="form-group row">
                <label class="col-sm-4 col-form-label">Employee ID</label>
                <div class="col-sm-8">
                    <label type="text" class="form-control-plaintext">@Employee.EmployeeId</label>
                </div>
            </div>
            <div class="form-group row">
                <label class="col-sm-4 col-form-label">First name</label>
                <div class="col-sm-8">
                    <label type="text" readonly class="form-control-plaintext">@Employee.FirstName</label>
                </div>
            </div>

            <div class="form-group row">
                <label class="col-sm-4 col-form-label">Last name</label>
                <div class="col-sm-8">
                    <label type="text" readonly class="form-control-plaintext">@Employee.LastName</label>
                </div>
            </div>

            <div class="form-group row">
                <label class="col-sm-4 col-form-label">Birthdate</label>
                <div class="col-sm-8">
                    <label type="text" readonly class="form-control-plaintext">@Employee.BirthDate.ToShortDateString()</label>
                </div>
            </div>

            <div class="form-group row">
                <label class="col-sm-4 col-form-label">Email</label>
                <div class="col-sm-8">
                    <label type="text" readonly class="form-control-plaintext">@Employee.Email</label>
                </div>
            </div>

            <div class="form-group row">
                <label class="col-sm-4 col-form-label">Street</label>
                <div class="col-sm-8">
                    <label type="text" readonly class="form-control-plaintext">@Employee.Street</label>
                </div>
            </div>

            <div class="form-group row">
                <label class="col-sm-4 col-form-label">Zip</label>
                <div class="col-sm-8">
                    <label type="text" readonly class="form-control-plaintext">@Employee.Zip</label>
                </div>
            </div>

            <div class="form-group row">
                <label class="col-sm-4 col-form-label">City</label>
                <div class="col-sm-8">
                    <label type="text" readonly class="form-control-plaintext">@Employee.City</label>
                </div>
            </div>

            <div class="form-group row">
                <label class="col-sm-4 col-form-label">Phone number</label>
                <div class="col-sm-8">
                    <label type="text" readonly class="form-control-plaintext">@Employee.PhoneNumber</label>
                </div>
            </div>

            <div class="form-group row">
                <label class="col-sm-4 col-form-label">Gender</label>
                <div class="col-sm-8">
                    <label type="text" readonly class="form-control-plaintext">@Employee.Gender</label>
                </div>
            </div>

            <div class="form-group row">
                <label class="col-sm-4 col-form-label">Smoker</label>
                <div class="col-sm-8">

                    @if (Employee.Smoker)
                    {
                        <label type="text" readonly class="form-control-plaintext">Yes</label>
                    }
                    else
                    {
                        <label type="text" readonly class="form-control-plaintext">No</label>

                    }
                </div>
            </div>

            <div class="form-group row">
                <label class="col-sm-4 col-form-label">Joined us</label>
                <div class="col-sm-8">
                    <label type="text" readonly class="form-control-plaintext">@Employee.JoinedDate?.ToShortDateString()</label>
                </div>
            </div>

            <div class="form-group row">
                <label class="col-sm-4 col-form-label">Left us</label>
                <div class="col-sm-8">
                    <label type="text" readonly class="form-control-plaintext">@Employee.ExitDate?.ToShortDateString()</label>
                </div>
            </div>
        </div>
    </div>
</div>

```

## Code Behind File

Now we add the code behind like we did for the employee overview page by adding a class called `EmployeeDetail.cs` we us the parameter attribute on the EmployeeId this lets blazor know this is the parameter to work with will searching for Employees Details with the `GetEmployeeDetails` method.

```C#

public partial class EmployeeDetail
    {

		/// <summary>
		/// Parameter attribute let Blazor know this is the parameter being passed in
		/// </summary>
		[Parameter]
		public string EmployeeId { get; set; }

		public Employee Employee { get; set; } = new Employee();

        //inject the service using the built in Dependency injection
		[Inject]
		public IEmployeeDataService _service { get; set; }


		protected override async Task OnInitializedAsync()
		{

            //call api to get details
			Employee = await _service.GetEmployeeDetails(int.Parse(EmployeeId));


		}

		public IEnumerable<Employee> Employees { get; set; }

		private List<Country> Countries { get; set; }

		private List<JobCategory> JobCategories { get; set; }


	}


```

Now lets run the app to see the details page in action.

## Add Blazor Forms

We need to added some more supporting services, that we will use to edit employee data in our `EmployeeEdit.razor` component below is a list of the elements we will be creating in this section

- `ICountryDataService`
- `CountryDataService`
- `IJobCategoryDataService`
- `JobCategoryDataService`
- `EmployeeEdit.razor`
- `EmployeeEdit.cs`

Lets get started with the `ICountryDataService` interface this will allow us to inject the service through the built in .Net Dependency injection this will give lose coupling from implementation details.

Add the interface to the Services folder by right clicking then add new item then add interface called `ICountryDataService` replace the code with below:

```C#

public interface ICountryDataService
{
	Task<IEnumerable<Country>> GetAllCountries();
	Task<Country> GetCountryById(int countryId);
}


```

Add the class to the Services folder by right clicking then add new item then add interface called `CountryDataService` replace the code with below:

```C#

public class CountryDataService : ICountryDataService
{
	private readonly HttpClient _httpClient;

	public CountryDataService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<IEnumerable<Country>> GetAllCountries()
	{
		return await JsonSerializer.DeserializeAsync<IEnumerable<Country>>
			(await _httpClient.GetStreamAsync($"api/country"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
	}

	public async Task<Country> GetCountryById(int countryId)
	{
		return await JsonSerializer.DeserializeAsync<Country>
			(await _httpClient.GetStreamAsync($"api/country{countryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
	}
}
```

Add interface `IJobCategoryDataService` this will allow us to inject the service and decouple us from implementation details. Add to the service folder the interface `IJobCategoryDataService`.

```C#
public interface IJobCategoryDataService
{
	Task<IEnumerable<JobCategory>> GetAllJobCategories();
	Task<JobCategory> GetJobCategoryById(int jobCategoryId);
}

```

Now we add the concrete implementation `JobCategoryDataService` of our interface and you can see the HttpClient is being injected via constructor injection.

```C#
  public class JobCategoryDataService : IJobCategoryDataService
    {
        //Dependency inject with constructor injection
        private readonly HttpClient _httpClient;

        public JobCategoryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<JobCategory>> GetAllJobCategories()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>
                (await _httpClient.GetStreamAsync($"api/jobcategory"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<JobCategory> GetJobCategoryById(int jobCategoryId)
        {
            return await JsonSerializer.DeserializeAsync<JobCategory>
                (await _httpClient.GetStreamAsync($"api/jobcategory/{jobCategoryId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
```

Add the Services to the program class

```C#
        builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(client => client.BaseAddress = new Uri("https://localhost:44340/"));
        builder.Services.AddHttpClient<IJobCategoryDataService, JobCategoryDataService>(client => client.BaseAddress = new Uri("https://localhost:44340/"));

```

Add `EmployeeEdit.razor` that will contain on of our controls to edit Employees we use the blazor `EditForm` as it gives more options as opposed to the html `form`.

```razor
@if (!Saved)
{
    <section class="employee-edit">
        <h1 class="page-title">Details for @Employee.FirstName @Employee.LastName</h1>
        <EditForm Model="@Employee" OnValidSubmit="@HandleValidSubmit"
                  OnInvalidSubmit="@HandleInvalidSubmit">
            <DataAnnotationsValidator />
            <ValidationSummary></ValidationSummary>
            <div class="form-group row">
                <label for="lastName" class="col-sm-3">Last name: </label>
                <InputText id="lastName" class="form-control col-sm-8" @bind-Value="@Employee.LastName" placeholder="Enter last name"></InputText>
                <ValidationMessage class="offset-sm-3 col-sm-8" For="@(() => Employee.LastName)" />
            </div>

            <div class="form-group row">
                <label for="firstName" class="col-sm-3">First name: </label>
                <InputText id="firstName" class="form-control col-sm-8" @bind-Value="@Employee.FirstName" placeholder="Enter first name"></InputText>
                <ValidationMessage class="offset-sm-3 col-sm-8" For="@(() => Employee.FirstName)" />
            </div>


            <div class="form-group row">
                <label for="birthdate" class="col-sm-3">Birthdate: </label>
                <InputDate id="birthdate" class="form-control col-sm-8" @bind-Value="@Employee.BirthDate" placeholder="Enter birthdate"></InputDate>

            </div>
            <div class="form-group row">
                <label for="email" class="col-sm-3">Email: </label>
                <InputText id="email" class="form-control col-sm-8" @bind-Value="@Employee.Email" placeholder="Enter email"></InputText>
                <ValidationMessage class="offset-sm-3 col-sm-8" For="@(() => Employee.Email)" />
            </div>

            <div class="form-group row">
                <label for="street" class="col-sm-3">Street: </label>
                <InputText id="street" class="form-control col-sm-8" @bind-Value="@Employee.Street" placeholder="Enter street"></InputText>

            </div>

            <div class="form-group row">
                <label for="zip" class="col-sm-3">Zip code: </label>
                <InputText id="zip" class="form-control col-sm-8" @bind-Value="@Employee.Zip" placeholder="Enter zip code"></InputText>

            </div>

            <div class="form-group row">
                <label for="city" class="col-sm-3">City: </label>
                <InputText id="city" class="form-control col-sm-8" @bind-Value="@Employee.City" placeholder="Enter city"></InputText>

            </div>

            <div class="form-group row">
                <label for="country" class="col-sm-3">Country: </label>
                <InputSelect id="country" class="form-control col-sm-8" @bind-Value="@CountryId">
                    @foreach (var country in Countries)
                        {
                        <option value="@country.CountryId">@country.Name</option>
                        }
                </InputSelect>
            </div>

            <div class="form-group row">
                <label for="phonenumber" class="col-sm-3">Phone number: </label>
                <InputText id="phonenumber" class="form-control col-sm-8" @bind-Value="@Employee.PhoneNumber" placeholder="Enter phone number"></InputText>
            </div>

            <div class="form-group row">
                <label for="longitude" class="col-sm-3">Longitude: </label>
                <InputNumber id="longitude" class="form-control col-sm-8" @bind-Value="@Employee.Longitude"></InputNumber>
            </div>

            <div class="form-group row">
                <label for="latitude" class="col-sm-3">Latitude: </label>
                <InputNumber id="latitude" class="form-control col-sm-8" @bind-Value="@Employee.Latitude"></InputNumber>
            </div>

            <div class="form-group row">
                <label for="smoker" class=" offset-sm-3">
                    <InputCheckbox id="smoker" @bind-Value="@Employee.Smoker"></InputCheckbox>
                    &nbsp;Smoker
                </label>
            </div>

            <div class="form-group row">
                <label for="jobcategory" class="col-sm-3">Job category: </label>
                <InputSelect id="jobcategory" class="form-control col-sm-8" @bind-Value="@JobCategoryId">
                    @foreach (var jobCategory in JobCategories)
                        {
                        <option value="@jobCategory.JobCategoryId">@jobCategory.JobCategoryName</option>
                        }
                </InputSelect>
            </div>

            <div class="form-group row">
                <label for="gender" class="col-sm-3">Gender: </label>
                <InputSelect id="gender" class="form-control col-sm-8" @bind-Value=@Employee.Gender>
                    <option value="@(Gender.Male)">Male</option>
                    <option value="@(Gender.Female)">Female</option>
                    <option value="@(Gender.Other)">Other</option>
                </InputSelect>
            </div>

            <div class="form-group row">
                <label for="maritalstatus" class="col-sm-3">Marital status: </label>
                <InputSelect id="maritalstatus" class="form-control col-sm-8" @bind-Value=@Employee.MaritalStatus>
                    <option value="@(MaritalStatus.Single)">Single</option>
                    <option value="@(MaritalStatus.Married)">Married</option>
                    <option value="@(MaritalStatus.Other)">Other</option>
                </InputSelect>
            </div>

            <div class="form-group row">
                <label for="joineddate" class="col-sm-3">Joined on: </label>
                <InputDate id="joineddate" class="form-control col-sm-8" @bind-Value="@Employee.JoinedDate" placeholder="Enter date joined"></InputDate>
            </div>

            <div class="form-group row">
                <label for="exitdate" class="col-sm-3">Left on: </label>
                <InputDate id="exitdate" class="form-control col-sm-8" @bind-Value="@Employee.ExitDate" placeholder="Enter exit date"></InputDate>
            </div>

            <div class="form-group row">
                <label for="comment" class="col-sm-3">Comment: </label>
                <InputTextArea id="comment" class="form-control col-sm-8" @bind-Value="@Employee.Comment" placeholder="Enter comment"></InputTextArea>
                <ValidationMessage class="offset-sm-3 col-sm-8" For="@(() => Employee.Comment)" />
            </div>

            <button type="submit" class="btn btn-primary edit-btn">Save employee</button>

            @if (Employee.EmployeeId > 0)
            {
                <a class="btn btn-danger" @onclick="@DeleteEmployee">
                    Delete
                </a>
            }

            <a class="btn btn-outline-primary" @onclick="@NavigateToOverview">Back to overview</a>
        </EditForm>
    </section>

}
else
{
    <div class="alert @StatusClass">@Message</div>


}
```

Like before we will add our code behind partial class `EmployeeEdit.cs`

```C#
 public partial class EmployeeEdit
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }
        [Inject]
        public ICountryDataService CountryDataService { get; set; }
        [Inject]
        public IJobCategoryDataService JobCategoryDataService { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Employee Employee { get; set; } = new Employee();
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

        protected string CountryId = string.Empty;
        protected string JobCategoryId = string.Empty;

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            Countries = (await CountryDataService.GetAllCountries()).ToList();
            //Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            JobCategories = (await JobCategoryDataService.GetAllJobCategories()).ToList();

            int.TryParse(EmployeeId, out var employeeId);

            if (employeeId == 0) //new employee is being created
            {
                //add some defaults
                Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
            }
            else
            {
                Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            }

            CountryId = Employee.CountryId.ToString();
            JobCategoryId = Employee.JobCategoryId.ToString();
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;
            Employee.CountryId = int.Parse(CountryId);
            Employee.JobCategoryId = int.Parse(JobCategoryId);

            if (Employee.EmployeeId == 0) //new
            {
                var addedEmployee = await EmployeeDataService.AddEmployee(Employee);
                if (addedEmployee != null)
                {
                    StatusClass = "alert-success";
                    Message = "New employee added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new employee. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await EmployeeDataService.UpdateEmployee(Employee);
                StatusClass = "alert-success";
                Message = "Employee updated successfully.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteEmployee()
        {
            await EmployeeDataService.DeleteEmployee(Employee.EmployeeId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }
    }
```

Now lets run the app to see the edit page in action.
