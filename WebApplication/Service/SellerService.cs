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
    }
}
