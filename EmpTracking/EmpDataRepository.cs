using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using EmpTracking.Controllers;
using EmpTracking.Models;

namespace EmpTracking
{
    public class EmpDataRepository : IEmpDataRepository
    {
        private readonly IDbConnection _conn;

        public EmpDataRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<EmpList> GetAllEmpData()
        {
            return _conn.Query<EmpList>("SELECT * FROM EmpData;");
        }

        public EmpList GetEmpData(int id)
        {
            return _conn.QuerySingle<EmpList>("SELECT * FROM EmpData WHERE EmpDataID = @id;", new { id = id });
            
        }

        public void UpdateEmpData(EmpList empdata)
        {
            _conn.Execute("UPDATE EmpData SET FName = @fname, LName = @lname WHERE EmpDataID = @id;", new { fname = empdata.FName, lname = empdata.LName, id = empdata.EmpDataID });
        }

        public void InsertEmpData(EmpList employeeToInsert)
        {
            _conn.Execute("INSERT INTO EmpData (FNAME, LNAME) VALUES (@fname, @lname);",
                new { fname = employeeToInsert.FName, lname = employeeToInsert.LName });

        }

        public IEnumerable<Department> GetDepartment()
        {
            return _conn.Query<Department>("SELECT * FROM Department;");
        }

        public EmpList AssignDepartment()
        {
            var deptList = GetDepartment();
            var employee = new EmpList();
            employee.Departments = deptList;

            return employee;
        }

        public void DeleteEmpData(EmpList empdata)
        {
            _conn.Execute("DELETE FROM EmpData WHERE EmpDataID = @id;",
                                       new { id = empdata.EmpDataID });
        }

        public IEnumerable<EmpList> SearchEmpList(string search)
        {
            return _conn.Query<EmpList>("SELECT * FROM EmpData WHERE LName LIKE @lastname;",
                new { lastname = "%" +search + "%"});
        }

    }
}
