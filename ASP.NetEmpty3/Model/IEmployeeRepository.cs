using System.Collections.Generic;

namespace ASP.NetEmpty3.Model
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);

        public IEnumerable<Employee> GetAllEmployee();

    }
}
