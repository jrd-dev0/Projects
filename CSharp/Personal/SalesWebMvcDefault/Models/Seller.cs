﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be {2} and {1}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Range(100.0, 100000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "$ {0:F2}")]
        public double BaseSalary { get; set; }

        public Department Department { get; set; }
        
        public int DepartmentId { get; set; }

        ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() { }
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord saleRecord)
        {
            Sales.Add(saleRecord);
        }

        public void RemoveSales(SalesRecord saleRecord)
        {
            Sales.Remove(saleRecord);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(saleRecord => saleRecord.Date >= initial && saleRecord.Date <= final).Sum(saleRecord => saleRecord.Amount);
        }
    }
}
