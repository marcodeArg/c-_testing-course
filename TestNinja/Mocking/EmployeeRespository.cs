namespace TestNinja.Mocking
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _db = new EmployeeContext();

        public void Delete(int id)
        {
            var employee = _db.Employees.Find(id);
            
            if (employee == null) return;
            
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }

    public interface IEmployeeRepository
    {
        void Delete(int id);
    }
}