﻿using Application.UseCases.Commands;
using Application.UseCases.DTO;
using Implementation;
using Implementation.Validator;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private UseCaseHandler _handler;

        public SupplierController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // POST api/<SupplierController>
        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateSupplierDTO dto,
            [FromServices] ICreateSupplierCommand command,
            [FromServices] CreateSupplierValidator validator)
        {
            try
            {
                var result = validator.Validate(dto);
                if (!result.IsValid)
                {
                    return UnprocessableEntity(result.Errors.Select(x => new
                    {
                        x.ErrorMessage,
                        x.PropertyName
                    }));
                }
                _handler.HandleCommand(command, dto);
                return StatusCode(201);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] UpdateSupplierDTO dto,
            [FromServices] IUpdateSupplierCommand command,
            [FromServices] UpdateSupplierValidator validator)
        {
            try
            {
                var result = validator.Validate(dto);
                if (!result.IsValid)
                {
                    return UnprocessableEntity(result.Errors.Select(x => new
                    {
                        x.ErrorMessage,
                        x.PropertyName
                    }));
                }
                _handler.HandleCommand(command, dto);
                return StatusCode(201);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] DeleteSupplierDTO dto,
            [FromServices] IDeleteSupplierCommand command,
            [FromServices] DeleteSupplierValidator validator)
        {
            try
            {
                var result = validator.Validate(dto);
                if (!result.IsValid)
                {
                    return UnprocessableEntity(result.Errors.Select(x => new
                    {
                        x.ErrorMessage,
                        x.PropertyName
                    }));
                }
                _handler.HandleCommand(command, dto);
                return StatusCode(201);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
