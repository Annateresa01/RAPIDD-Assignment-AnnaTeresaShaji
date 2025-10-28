using AnnaTeresaShaji_C_Assignment.Models;

namespace AnnaTeresaShaji_C_Assignment.Interfaces
{
    public interface IApiService
    {
        Task<List<EmployeeDataModel>> GetEmployeeData();
    }
}
