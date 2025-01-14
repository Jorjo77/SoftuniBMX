﻿namespace BicycleApp.Services.Contracts
{
    using System.Threading.Tasks;

    using BicycleApp.Services.Models.IdentityModels;

    public interface IEmployeeService
    {
        Task<string> RegisterEmployeeAsync(EmployeeRegisterDto employeeRegisterDto, string httpScheme, string httpHost);

        Task<EmployeeReturnDto> LoginEmployeeAsync(EmployeeLoginDto employeeDto);

        Task<EmployeeInfoDto?> GetEmployeeInfoAsync(string Id);

        Task<bool> ChangeEmployeePasswordAsync(EmployeePasswordChangeDto employeePasswordChangeDto);

        Task<bool> ResetPasswordToDefault(string email);

        Task ConfirmEmailAsync(string emmployeeId, string code);
    }
}
