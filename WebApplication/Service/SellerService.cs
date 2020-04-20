using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;
using Microsoft.EntityFrameworkCore;

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

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);

            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);

            _context.Seller.Remove(obj);

            _context.SaveChanges();
        }
    }
}
