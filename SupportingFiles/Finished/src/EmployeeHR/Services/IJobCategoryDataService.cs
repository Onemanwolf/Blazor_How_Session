using EmployeeHR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeHR.Services
{
	public interface IJobCategoryDataService
	{
		Task<IEnumerable<JobCategory>> GetAllJobCategories();
		Task<JobCategory> GetJobCategoryById(int jobCategoryId);
	}
}
