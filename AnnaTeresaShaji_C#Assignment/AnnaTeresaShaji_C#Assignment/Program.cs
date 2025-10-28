using AnnaTeresaShaji_C_Assignment.Controllers;
using AnnaTeresaShaji_C_Assignment.Implementations;
using AnnaTeresaShaji_C_Assignment.Interfaces;

namespace AnnaTeresaShaji_C_Assignment
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("PROJECT started running");

            IApiService apiService = new ApiService();
            IEmployeeWorkHoursCalculator timeCalculator = new EmployeeWorkHoursCalculator();
            IEmployeeAttendenceReportGenerator reportService = new EmployeeAttendencReportGenerator();
            IEmployeeAttendenceChartGenerator chart = new EmployeeAttendenceChartGenerator();

            EmployeeAttendenceReportController controller = new EmployeeAttendenceReportController(apiService, timeCalculator, reportService, chart);

            await controller.Execute();

            Console.WriteLine("Project completed");
            Console.ReadKey();
        }
    }
}
