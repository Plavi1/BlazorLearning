﻿using EmployeeManagment.Models;
using EmployeeManagment.Web.Models;
using EmployeeManagment.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        public List<Department> Departments { get; set; } = new List<Department>();

        public string DepartmentId { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            Departments = (await DepartmentService.GetDepartments()).ToList();

            EditEmployeeModel.EmployeeId = Employee.EmployeeId;
            EditEmployeeModel.FirstName = Employee.FirstName;
            EditEmployeeModel.LastName = Employee.LastName;
            EditEmployeeModel.Email = Employee.Email;
            EditEmployeeModel.ConfirmEmail = Employee.Email;
            EditEmployeeModel.DateOfBrith = Employee.DateOfBrith;
            EditEmployeeModel.Gender = Employee.Gender;
            EditEmployeeModel.PhotoPath = Employee.PhotoPath;
            EditEmployeeModel.DepartmentId = Employee.DepartmentId;
            EditEmployeeModel.Department = Employee.Department;
        }
        protected void HandleValidSubmit()
        { }
    }
}
