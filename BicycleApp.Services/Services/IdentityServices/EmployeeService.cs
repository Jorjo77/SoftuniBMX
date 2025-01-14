﻿namespace BicycleApp.Services.Services.IdentityServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using BicycleApp.Data.Models.IdentityModels;
    using BicycleApp.Data;
    using BicycleApp.Services.Contracts;
    using BicycleApp.Services.Models.IdentityModels;

    using Microsoft.AspNetCore.Identity;

    using Microsoft.Extensions.Configuration;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;

    using static BicycleApp.Common.ApplicationGlobalConstants;
    using static BicycleApp.Common.UserConstants;
    using Microsoft.AspNetCore.WebUtilities;
    using BicycleApp.Common.Providers.Contracts;
    using BicycleApp.Services.HelperClasses.Contracts;

    public class EmployeeService : IEmployeeService
    {
        private readonly UserManager<BaseUser> userManager;
        private readonly SignInManager<BaseUser> signInManager;
        private readonly RoleManager<BaseUserRole> roleManager;
        private readonly BicycleAppDbContext dbContext;
        private readonly IConfiguration configuration;
        private readonly IModelsFactory modelFactory;
        private readonly IEmailSender emailSender;
        private readonly IOptionProvider optionProvider;
        private readonly IStringManipulator stringManipulator;

        public EmployeeService(UserManager<BaseUser> userManager, 
                               SignInManager<BaseUser> signInManager,
                               RoleManager<BaseUserRole> roleManager,
                               BicycleAppDbContext dbContext, 
                               IConfiguration configuration, 
                               IModelsFactory modelFactory, 
                               IEmailSender emailSender, 
                               IOptionProvider optionProvider, 
                               IStringManipulator stringManipulator)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.dbContext = dbContext;
            this.configuration = configuration;
            this.modelFactory = modelFactory;
            this.emailSender = emailSender;
            this.optionProvider = optionProvider;
            this.stringManipulator = stringManipulator;
        }

        /// <summary>
        /// This method creates a Employee entity in the database
        /// </summary>
        /// <param name="employeeRegisterDto">The info for the employee</param>
        /// <returns>True or False</returns>
        /// <exception cref="ArgumentNullException">If input data is null</exception>
        /// <exception cref="ArgumentException">If employee already exists</exception>
        public async Task<string> RegisterEmployeeAsync(EmployeeRegisterDto employeeRegisterDto, string httpScheme, string httpHost)
        {
            if (employeeRegisterDto == null)
            {
                throw new ArgumentNullException(nameof(employeeRegisterDto));
            }

            var existingEmployee = await userManager.FindByEmailAsync(employeeRegisterDto.Email);
            if (existingEmployee != null)
            {
                throw new ArgumentException($"Employee with email: {employeeRegisterDto.Email} already exists!");
            }

            var employee = this.modelFactory.CreateNewEmployee(employeeRegisterDto);
            employee.DepartmentId = await this.GetDepartmentIdAsync(employeeRegisterDto.Department);

            var result = await this.userManager.CreateAsync(employee, employeeRegisterDto.Password);

            var isRoleExists = await roleManager.RoleExistsAsync(employeeRegisterDto.Role.ToLower());
            var identityRole = new BaseUserRole();
            identityRole.Name = employeeRegisterDto.Role;
            
            if (!isRoleExists)
            {
                await roleManager.CreateAsync(identityRole);
            }
            var roleName = await roleManager.GetRoleNameAsync(identityRole);
            await userManager.AddToRoleAsync(employee, roleName);

            if (result == null)
            {
                return string.Empty;
            }

            if (result.Succeeded)
            {
                var confirmationToken = await userManager.GenerateEmailConfirmationTokenAsync(employee);
                confirmationToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmationToken));
                var endPointToComfirmEmail = optionProvider.EmployeeEmailConfirmEnpoint();
                var routeValues = $"userId={employee.Id}&code={confirmationToken}";
                var callback = stringManipulator.UrlMaker(httpScheme, httpHost, endPointToComfirmEmail, routeValues);
                var emailSenderResult = emailSender.IsSendedEmailForVerification(employee.Email, $"{employee.FirstName} {employee.LastName}", callback);
                if (emailSenderResult)
                {
                    return stringManipulator.ReturnFullName(employee.FirstName, employee.LastName);
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// This method sign in the employee
        /// </summary>
        /// <param name="employeeDto">Input data for the employee</param>
        /// <returns>Respons as Dto</returns>
        /// <exception cref="ArgumentNullException">If input data is null</exception>
        public async Task<EmployeeReturnDto> LoginEmployeeAsync(EmployeeLoginDto employeeDto)
        {
            if (employeeDto == null)
            {
                throw new ArgumentNullException(nameof(employeeDto));
            }

            var employee = await this.userManager.FindByEmailAsync(employeeDto.Email);

            if (employee == null)
            {
                return new EmployeeReturnDto() { Result = false };
            }

            var passwordMatches = await this.userManager.CheckPasswordAsync(employee, employeeDto.Password);
            if (!passwordMatches)
            {
                return new EmployeeReturnDto() { Result = false };
            }

            var result = await signInManager.CheckPasswordSignInAsync(employee, employeeDto.Password, false);

            if (result.Succeeded)
            {
                var roles = await userManager.GetRolesAsync(employee);
                return new EmployeeReturnDto()
                {
                    EmployeeId = employee.Id,
                    EmployeeFullName = $"{employee.FirstName} {employee.LastName}",
                    Token = await this.GenerateJwtTokenAsync(employee),
                    Role = roles[0],
                    Result = true,
                };
            }
            else
            {
                return new EmployeeReturnDto { Result = false };
            }
        }

        /// <summary>
        /// This method returns info abouth the employee
        /// </summary>
        /// <param name="Id">Id of the employee</param>
        /// <returns>Dto</returns>
        public async Task<EmployeeInfoDto?> GetEmployeeInfoAsync(string Id)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(e => e.Id == Id);

            if (employee == null)
            {
                return null;
            }

            string? department = await dbContext.Departments
                .Where(d => d.Id == employee.DepartmentId)
                .Select(d => d.Name)
                .FirstOrDefaultAsync();

            var roles = await userManager.GetRolesAsync(employee);

            return new EmployeeInfoDto()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                //Role = roles.Count > 1 ? string.Join(", ", roles) : roles[0],
                Email = employee.Email,
                Position = employee.Position,
                Department = department,
                PhoneNumber = employee.PhoneNumber,
                DateCreated = employee.DateCreated.ToString(DefaultDateFormat),
                DateOfHire = employee.DateOfHire.ToString(DefaultDateFormat),
                DateOfLeave = employee.DateOfLeave == null ? null : employee.DateOfLeave.Value.ToString(DefaultDateFormat),
                DateUpdated = employee.DateUpdated == null ? null : employee.DateUpdated.Value.ToString(DefaultDateFormat),
                IsManeger = employee.IsManeger
            };
        }


        /// <summary>
        /// This method changes the password for an employee in the database
        /// </summary>
        /// <param name="employeePasswordChangeDto">Input data</param>
        /// <returns>True/False</returns>
        /// <exception cref="ArgumentNullException">If input data is null throws exception</exception>
        public async Task<bool> ChangeEmployeePasswordAsync(EmployeePasswordChangeDto employeePasswordChangeDto)
        {
            if (employeePasswordChangeDto == null)
            {
                throw new ArgumentNullException(nameof(employeePasswordChangeDto));
            }

            var employee = await userManager.FindByIdAsync(employeePasswordChangeDto.EmployeeId);

            if (employee == null)
            {
                // Employee not found
                return false;
            }

            var result = await userManager.ChangePasswordAsync(employee, employeePasswordChangeDto.OldPassword, employeePasswordChangeDto.NewPasword);

            if (result.Succeeded)
            {
                // Password changed successfully
                return true;
            }
            else
            {
                // Failed to change password
                return false;
            }
        }
        /// <summary>
        /// Reset forrgoten password.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Task<bool></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<bool> ResetPasswordToDefault(string email)
        {
            try
            {
                var employee = await dbContext.Employees.FirstAsync(c => c.Email == email);
                //var roles = await userManager.GetRolesAsync(client);
                //string roleName = roles.First(r => r == EMPLOYEE);

                var result = await emailSender.ResetUserPasswordWhenForrgotenAsync(employee.Id, EMPLOYEE);

                if (result)
                {
                    return true;
                }
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
            catch (Exception)
            {
            }
            return false;
        }

        /// <summary>
        /// This method returns the id of the department and creates a department entry in the database if needed
        /// </summary>
        /// <param name="department">The name of the department</param>
        /// <returns>Id as Integer</returns>
        private async Task<int> GetDepartmentIdAsync(string department)
        {
            var departmentEntity = await dbContext.Departments
                .Where(d => d.Name == department)
                .FirstOrDefaultAsync();

            if (departmentEntity == null)
            {
                var newDepartment = this.modelFactory.CreateNewDepartment(department);

                await dbContext.Departments.AddAsync(newDepartment);
                await dbContext.SaveChangesAsync();

                int id = await dbContext.Departments
                    .Where(d => d.Name == department)
                    .Select(d => d.Id)
                    .FirstOrDefaultAsync();

                return id;
            }
            else
            {
                return departmentEntity.Id;
            }
        }

        public async Task ConfirmEmailAsync(string emmployeeId, string code)
        {
            try
            {
                var user = await dbContext.Employees.FirstAsync(u => u.Id == emmployeeId);
                code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));

                await userManager.ConfirmEmailAsync(user, code);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// This method creates a Jwt token
        /// </summary>
        /// <param name="employee">The Employee entity</param>
        /// <returns>Jwt token</returns>
        private async Task<string> GenerateJwtTokenAsync(BaseUser employee)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()),
                new Claim(ClaimTypes.Email, employee.Email)
            };
            var roles = await userManager.GetRolesAsync(employee);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var expires = DateTime.UtcNow.AddDays(7);

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecret"]));

            var credentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["JwtIssuer"],
                audience: configuration["JwtAudience"],
                claims: claims,
                expires: expires,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
