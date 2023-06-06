using Application.DTO;
using Application.Queries;
using Application.UseCases.Commands;
using Application.UseCases.DTO;
using Application.UseCases.DTO.Searches;
using Implementation;
using Implementation.Validator;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private UseCaseHandler _handler;

        public CategoriesController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        
        //api/<CategoriesController>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetCategoriesQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody]CreateCategoryDTO dto,
            [FromServices]ICreateCategoryCommand command,
            [FromServices]CreateCategoryValidator validator)
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
        public IActionResult Update([FromBody]UpdateCategoryDTO dto,
            [FromServices]IUpdateCategoryCommand command,
            [FromServices]UpdateCategoryValidator validator)
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
        public IActionResult Delete([FromBody] DeleteCategoryDTO dto,
            [FromServices] IDeleteCategoryCommand command,
            [FromServices] DeleteCategoryValidator validator)
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
