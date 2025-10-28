namespace AnnaTeresaShaji_C_Assignment.Interfaces
{
    public interface IEmployeeAttendenceChartGenerator
    {
        bool GenerateEmployeeWorkHoursPieChart(Dictionary<string, double> employeeHours, string filePath);
    }
}
