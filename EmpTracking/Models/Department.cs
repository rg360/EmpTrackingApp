using System;
namespace EmpTracking.Controllers
{
    public class Department
    {
        public Department()
        {
        }
        public int DeptID { get; set; }
        public string DeptName { get; set; }
        public string DeptDesc { get; set; }
        public string DeptGroup { get; set; }
    }
}
