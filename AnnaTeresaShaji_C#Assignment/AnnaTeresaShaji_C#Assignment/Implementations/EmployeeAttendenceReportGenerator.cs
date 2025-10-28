using AnnaTeresaShaji_C_Assignment.Interfaces;
using System.Text;

namespace AnnaTeresaShaji_C_Assignment.Implementations
{
    public class EmployeeAttendencReportGenerator : IEmployeeAttendenceReportGenerator
    {
        public bool GenerateEmployeeWorkHoursReport(Dictionary<string, double> employeeHours, string filePath)
        {
            try
            {
                if (employeeHours == null || employeeHours.Count == 0)
                {
                    Console.WriteLine("No data available");

                    return false;
                }

                var sortedHours = employeeHours.OrderByDescending(x => x.Value).ToList();

                var sb = new StringBuilder();
                sb.Append("<html><head><title>Employee Work Hours Report</title></head><body>");
                sb.Append("<h2>Employee Hours Report</h2>");
                sb.Append("<table border='1' cellpadding='5' cellspacing='0'>");
                sb.Append("<tr><th>Employee Name</th><th>Total Hours Worked</th></tr>");

                foreach (var emp in sortedHours)
                {
                    var rowColor = emp.Value < 100 ? " style='background-color:#ffcccc;'" : "";

                    sb.Append($"<tr{rowColor}><td>{emp.Key}</td><td>{emp.Value}</td></tr>");
                }

                sb.Append("</table></body></html>");

                var dir = Path.GetDirectoryName(filePath);

                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                File.WriteAllText(filePath, sb.ToString());

                Console.WriteLine($"report generated at: {Path.GetFullPath(filePath)}");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating for report: {ex.Message}");

                return false;
            }
        }
    }
}
