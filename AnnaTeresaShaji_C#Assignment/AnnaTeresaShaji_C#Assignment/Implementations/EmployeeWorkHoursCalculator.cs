using AnnaTeresaShaji_C_Assignment.Interfaces;
using AnnaTeresaShaji_C_Assignment.Models;

namespace AnnaTeresaShaji_C_Assignment.Implementations
{
    public class EmployeeWorkHoursCalculator : IEmployeeWorkHoursCalculator
    {
        public Dictionary<string, double> CalculateEmployeeHours(List<EmployeeDataModel> employeeData)
        {
            var employeeRecords = employeeData
                .Where(x => x.DeletedOn == null &&  x.EndTimeUtc > x.StarTimeUtc && !string.IsNullOrWhiteSpace(x.EmployeeName))
                .ToList();

            return employeeRecords
                .GroupBy(x => x.EmployeeName)
                .ToDictionary(g => g.Key, g => Math.Round(g.Sum(x =>(x.EndTimeUtc - x.StarTimeUtc).TotalHours), 2));
        }
    }
}
