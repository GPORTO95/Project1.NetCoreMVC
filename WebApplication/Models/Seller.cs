using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WebApplication.Models
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDaate { get; set; }
        public double BasicSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() { }

        public Seller(string name, string email, DateTime birthDaate, double basicSalary, Department department)
        {
            Name = name;
            Email = email;
            BirthDaate = birthDaate;
            BasicSalary = basicSalary;
            Department = department;
        }

        public Seller(int id, string name, string email, DateTime birthDaate, double basicSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDaate = birthDaate;
            BasicSalary = basicSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(s => s.Date >= initial && s.Date <= final).Sum(s => s.Amount);
        }
    }
}
