using System.Collections.Generic;
using EmployeeHR.Shared;

namespace EmployeeHR.Api.Models {
    public interface IJobCategoryRepository {
        IEnumerable<JobCategory> GetAllJobCategories ();
        JobCategory GetJobCategoryById (int jobCategoryId);
    }
}