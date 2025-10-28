using AnnaTeresaShaji_C_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnaTeresaShaji_C_Assignment.Interfaces
{
    public interface IEmployeeWorkHoursCalculator
    {
        Dictionary<string, double> CalculateEmployeeHours(List<EmployeeDataModel> employeeData);
    }
}
