﻿namespace BicicleApp.Api.Controllers
{
    using BicycleApp.Services.Contracts;
    using BicycleApp.Services.Models.IdentityModels;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> RegisterEmployee([FromBody] EmployeeRegisterDto employeeRegisterDto)
        {
            try
            {
                if (employeeRegisterDto == null)
                {
                    // The clientRegisterDto object is null, so return a 400 Bad Request response
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    //Hide the email and password
                    employeeRegisterDto.Email = "";
                    employeeRegisterDto.Password = "";
                    employeeRegisterDto.ConfirmPassword = "";
                    return StatusCode(422, employeeRegisterDto);
                }

                //Register
                bool isRegistered = await employeeService.RegisterEmployeeAsync(employeeRegisterDto);

                if (isRegistered)
                {
                    return Ok();
                }

                //Return bad request if registration has failed
                employeeRegisterDto.Email = "";
                employeeRegisterDto.Password = "";
                employeeRegisterDto.ConfirmPassword = "";
                return BadRequest(employeeRegisterDto);
            }
            catch (Exception e)
            {
                if (e.Message == $"Employee with email: {employeeRegisterDto.Email} already exists!")
                {
                    //If the email already exists in the database
                    employeeRegisterDto.Email = "";
                    employeeRegisterDto.Password = "";
                    employeeRegisterDto.ConfirmPassword = "";
                    return StatusCode(409, employeeRegisterDto);
                }

                //Other Errors
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmployeeLoginDto>> LoginEmployee([FromBody] EmployeeLoginDto employeeLoginDto)
        {

            try
            {
                if (employeeLoginDto == null)
                {
                    // The clientLoginDto object is null, so return a 400 Bad Request response
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    //Hide the email and password
                    employeeLoginDto.Email = "";
                    employeeLoginDto.Password = "";
                    return StatusCode(422, employeeLoginDto);
                }

                //Login
                var responce = await employeeService.LoginEmployeeAsync(employeeLoginDto);

                if (responce.Result)
                {
                    return Ok(responce);
                }
                else
                {
                    return BadRequest(responce);
                }
            }
            catch (Exception)
            {
                //Other Errors
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("info")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ClientInfoDto>> GetEmployeeInfo([FromQuery] string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }

            try
            {
                var dto = await employeeService.GetEmployeeInfoAsync(id);

                if (dto == null)
                {
                    return NotFound();
                }

                return Ok(dto);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("password")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> ChangePassword([FromBody] EmployeePasswordChangeDto employeePasswordChangeDto)
        {
            if (employeePasswordChangeDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return StatusCode(422, employeePasswordChangeDto);
            }

            try
            {
                var result = await employeeService.ChangeEmployeePasswordAsync(employeePasswordChangeDto);

                if (result)
                {
                    return StatusCode(StatusCodes.Status202Accepted);
                }
                else
                {
                    return StatusCode(422, employeePasswordChangeDto);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}