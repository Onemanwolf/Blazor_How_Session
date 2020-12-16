using EmployeeHR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHR.Services
{
	public interface ICountryDataService
	{
		Task<IEnumerable<Country>> GetAllCountries();
		Task<Country> GetCountryById(int countryId);
	}
}
