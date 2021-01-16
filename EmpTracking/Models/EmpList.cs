using System;
using System.Collections.Generic;
using EmpTracking.Controllers;

namespace EmpTracking.Models
{
    public class EmpList
    {
        public EmpList()
        {
        }

        public int EmpDataID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime DateHire { get; set; }
        public string Email { get; set; }
        public int EmpStatID { get; set; }
        public int DeptID { get; set; }
        public int PositionID { get; set; }
        public int FieldID { get; set; }
        public IEnumerable<Department> Departments { get; set; }
    }
}
