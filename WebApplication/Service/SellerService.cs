using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Service
{
    public class SellerService
    {
        private readonly SalesContext _context;

        public SellerService(SalesContext context) => _context = context;

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            obj.Department = _context.Department.FirstOrDefault();

            _context.Add(obj);

            _context.SaveChanges();
        }
    }
}
