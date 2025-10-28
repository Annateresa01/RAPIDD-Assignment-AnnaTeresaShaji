namespace AnnaTeresaShaji_C_Assignment.Interfaces
{
    public interface IEmployeeAttendenceReportGenerator
    {
        bool GenerateEmployeeWorkHoursReport(Dictionary<string, double> employeeHours, string filePath);
    }
}
