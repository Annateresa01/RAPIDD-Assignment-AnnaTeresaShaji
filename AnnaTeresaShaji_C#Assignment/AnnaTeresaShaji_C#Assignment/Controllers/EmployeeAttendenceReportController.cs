using AnnaTeresaShaji_C_Assignment.Interfaces;

namespace AnnaTeresaShaji_C_Assignment.Controllers
{
    public class EmployeeAttendenceReportController
    {
        private readonly IApiService _apiService;
        private readonly IEmployeeWorkHoursCalculator _employeeTimeCalculator;
        private readonly IEmployeeAttendenceReportGenerator _reportService;
        private readonly IEmployeeAttendenceChartGenerator _chartGenerator;

        public EmployeeAttendenceReportController(IApiService apiService, IEmployeeWorkHoursCalculator employeeTimeCalculator, IEmployeeAttendenceReportGenerator reportService, IEmployeeAttendenceChartGenerator chartGenerator)
        {
            _apiService = apiService;
            _employeeTimeCalculator = employeeTimeCalculator;
            _reportService = reportService;
            _chartGenerator = chartGenerator;
        }

        public async Task Execute()
        {
            var Data = await _apiService.GetEmployeeData();
            var outputDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Outputs");

            Directory.CreateDirectory(outputDir);

            var htmlPath =Path.Combine(outputDir, "EmployeeHoursReport.html");
            var chartPath = Path.Combine(outputDir, "PieChart.png");

            Console.WriteLine($"Records fetched: {Data?.Count}");

            var EmployeeHour = _employeeTimeCalculator.CalculateEmployeeHours(Data);

            Console.WriteLine("Generating reports...");

            var employeeReportGenerated = _reportService.GenerateEmployeeWorkHoursReport(EmployeeHour,htmlPath);
            var employeeChartGenerated = _chartGenerator.GenerateEmployeeWorkHoursPieChart(EmployeeHour,chartPath);

        }
    }
}
