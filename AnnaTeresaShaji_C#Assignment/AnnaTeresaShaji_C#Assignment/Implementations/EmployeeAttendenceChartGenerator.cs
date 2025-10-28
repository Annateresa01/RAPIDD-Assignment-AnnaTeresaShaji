using AnnaTeresaShaji_C_Assignment.Interfaces;
using System.Drawing;

namespace AnnaTeresaShaji_C_Assignment.Implementations
{
    public class EmployeeAttendenceChartGenerator : IEmployeeAttendenceChartGenerator
    {
        public bool GenerateEmployeeWorkHoursPieChart(Dictionary<string, double> employeeHours, string filePath)
        {
            try
            {
                var sorted = employeeHours.OrderByDescending(x => x.Value).ToList();
                var totalHours = sorted.Sum(x => x.Value);

                int width = 800, height = 700;
                using Bitmap bmp = new Bitmap(width, height);
                using Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.White);

                float startAngle = 0;
                Random rand = new Random();
                int legendX = 580;
                int legendY = 50;

                foreach (var emp in sorted)
                {
                    float sweepAngle = (float)(emp.Value / totalHours * 360);

                    int r = rand.Next(100, 255);
                    int gColor = rand.Next(100, 255);
                    int b = rand.Next(100, 255);

                    Brush brush = new SolidBrush(Color.FromArgb(r, gColor, b));

                    g.FillPie(brush, 50, 50, 500, 500, startAngle, sweepAngle);
                    var percentage = Math.Round((emp.Value / totalHours) * 100, 2);

                    g.FillRectangle(brush, legendX, legendY, 20, 20);
                    g.DrawString($"{emp.Key}  - {percentage}%",
                                 new Font("Arial", 10),
                                 Brushes.Black,
                                 legendX + 30, legendY + 3);

                    legendY += 25;
                    startAngle += sweepAngle;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
                bmp.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
