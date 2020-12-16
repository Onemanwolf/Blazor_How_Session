using EmployeeHR.Models;
using EmployeeHR.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHR.Pages
{
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

}
