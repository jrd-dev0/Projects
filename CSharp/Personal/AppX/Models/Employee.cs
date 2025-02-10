﻿using System.ComponentModel.DataAnnotations.Schema;

namespace AppX.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }
    }
}