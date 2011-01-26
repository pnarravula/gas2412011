using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubDepartmentRepository : DepartmentsRepository
    {
        public IEnumerable<Department> get_main_departments()
        {
            return Enumerable.Range(1, 100).Select(x => new Department{name = x.ToString("Main Department 00")});
        }
		public IEnumerable<Department> get_departments_in_department(Department parent_department)
		{
			return Enumerable.Range(1, 100).Select(x => new Department { name = x.ToString("Sub Department 000") });
		}
	}
}