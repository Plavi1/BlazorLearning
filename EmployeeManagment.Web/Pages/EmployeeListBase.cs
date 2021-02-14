using EmployeeManagment.Models;
using EmployeeManagment.Web.Models;
using EmployeeManagment.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public bool ShowFooter { get; set; } = true;

        protected int SelectedEmployeesCount { get; set; } = 0;

        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectedEmployeesCount++;
            }
            else
            {
                SelectedEmployeesCount--;
            }
        }

        protected override async Task OnInitializedAsync()
            {
                Employees = (await EmployeeService.GetEmployees()).ToList();
            }
    }
   
}
