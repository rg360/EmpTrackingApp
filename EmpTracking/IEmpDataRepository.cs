using System;
using System.Collections.Generic;
using EmpTracking.Controllers;
using EmpTracking.Models;

namespace EmpTracking
{
    public interface IEmpDataRepository
    {

        public IEnumerable<EmpList> GetAllEmpData();

        public EmpList GetEmpData(int id);

        public void UpdateEmpData(EmpList empdata);

        public void InsertEmpData(EmpList empdata);

        public IEnumerable<Department> GetDepartment();

        public EmpList AssignDepartment();

        public void DeleteEmpData(EmpList empdata);

        public IEnumerable<EmpList> SearchEmpList(string search);
    }
}
