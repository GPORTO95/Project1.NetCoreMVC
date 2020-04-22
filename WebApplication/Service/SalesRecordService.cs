using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebApplication.Service
{
    public class SalesRecordService
    {
        private readonly SalesContext _context;

        public SalesRecordService(SalesContext context) => _context = context;

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if(minDate.HasValue)
                result = result.Where(x => x.Date >= minDate.Value);
            
            if(maxDate.HasValue)
                result = result.Where(x => x.Date <= maxDate.Value);
            

            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            //var result = from obj in _context.SalesRecord
            //             join s in _context.Seller on obj.SellerId equals s.Id
            //             join d in _context.Department on s.DepartmentId equals d.Id
            //             where obj.Date >= minDate && obj.Date <= maxDate
            //             orderby obj.Date descending
            //             select new { Date = obj.Date, Ammount = obj.Amount, Status = obj.Status, Name = s.Name, NameDP = d.Name };

            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x => x.Seller.Department)
                .ToListAsync();
        }
    }
}
