using CoreProject.Models.Entities;
using CoreProject.Models.Exceptions;
using CoreProject.Models.Responses;
using CoreProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;


namespace CoreProject.API.Controllers
{
    [Route("Users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = new ResponseData();
            response.Status = false;

            try
            {
                var users = await _userService.GetUsers();
                response.Status = true;
                response.Data = users;

            }

            catch (Exception ex)
            {
                response.Code = (HttpStatusCode) HttpContext.Response.StatusCode;
                response.Message = ex.Message;
            }

            return Ok(response);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = new ResponseData();
            response.Status = false;

            try
            {
                var user = await _userService.GetUser(id);
                response.Status = true;
                response.Data = user;

            }

            catch (ItemNotFoundException ex)
            {
                response.Code = HttpStatusCode.NotFound;
                response.Message = ex.Message;

            }

            catch (Exception ex)
            {
                response.Code = (HttpStatusCode)HttpContext.Response.StatusCode;
                response.Message = ex.Message;
            }

            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] User user)
        {
            var response = new ResponseData();
            response.Status = false;

            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                                            .SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage));


                    throw new ValidationException(message);

                }
                await _userService.AddUser(user);
                response.Status = true;

            }

            catch (ValidationException ex)
            {
                response.Code = (HttpStatusCode)HttpContext.Response.StatusCode;
                response.Message = ex.Message;
            }

            catch (Exception ex)
            {
                response.Code = (HttpStatusCode)HttpContext.Response.StatusCode;
                response.Message = ex.Message;
            }

            return Ok(response);

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User user)
        {
            var response = new ResponseData();
            response.Status = false;

            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                                            .SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage));


                     throw new ValidationException(message);

                }

                await _userService.UpdateUser(id, user);
                response.Status = true;
            }

            catch (ValidationException ex)
            {
                response.Code = (HttpStatusCode)HttpContext.Response.StatusCode;
                response.Message = ex.Message;
            }

            catch (ItemNotFoundException ex)
            {
                response.Code = HttpStatusCode.NotFound;
                response.Message = ex.Message;

            }

            catch (Exception ex)
            {
                response.Code = (HttpStatusCode)HttpContext.Response.StatusCode;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = new ResponseData();
            response.Status = false;

            try
            {

                await _userService.DeleteUser(id);
                response.Status = true;

            }

            catch (ItemNotFoundException ex)
            {
                response.Code = HttpStatusCode.NotFound;
                response.Message = ex.Message;

            }

            catch (Exception ex)
            {
                response.Code = (HttpStatusCode)HttpContext.Response.StatusCode;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

    }
}

