﻿using DTO;
using FoodShopManagementApi.DAO;
using FoodShopManagementApi.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopManagementApi.Controllers
{
    [Route("api/FoodShopManagement/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IConfiguration _config;

        public CustomerController(IConfiguration config)
        {
            _config = config;
        }

        public bool ValidateToken()
        {
            var header = HttpContext.Request.Headers;
            header.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues value);
            bool isValid = JwtUtil.ValidateJSONWebToken(value, _config);
            return isValid;
        }

        [HttpGet("load-customer")]
        [Produces("application/json")]
        public IActionResult LoadCustomer()
        {
            TblCustomerDAO dao = TblCustomerDAO.getInstance();
            try
            {
                List<TblCustomerDTO> result = dao.loadCustomers();
                if (result != null)
                {
                    return Ok(result);
                }
            }
            catch (Exception)
            {
                StatusCode(500);
            }
            return Unauthorized();
        }
    }
}
