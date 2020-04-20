using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Service
{
    public class DepartmentService
    {
        private readonly SalesContext _context;

        public DepartmentService(SalesContext context) => _context = context;

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
