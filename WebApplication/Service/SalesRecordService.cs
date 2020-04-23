using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApplication.Service.Exceptions;

namespace WebApplication.Service
{
    public class SalesRecordService
    {
        private readonly SalesContext _context;

        public SalesRecordService(SalesContext context) => _context = context;

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
                result = result.Where(x => x.Date >= minDate.Value);

            if (maxDate.HasValue)
                result = result.Where(x => x.Date <= maxDate.Value);


            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public async Task<List<IGrouping<string, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var historySales = await _context.SalesRecord
                .Where(x => x.Date >= minDate.Value && x.Date <= maxDate.Value && x.Date != null)
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .AsNoTracking()
                .ToListAsync();

            var grouping = historySales.GroupBy(x => x.Seller.Department.Name).ToList();

            return grouping;
        }
    }
}
