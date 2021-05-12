using System.Collections.Generic;

namespace AdoDemo
{
    public interface IEmployeeRepository
    {
        Employee Create(Employee employee);
        List<Employee> ReadAll();
        void Update(Employee employee);
        void Delete(int employeeId);
    }
}