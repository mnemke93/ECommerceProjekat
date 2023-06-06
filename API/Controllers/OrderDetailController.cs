using Application.UseCases.Commands;
using Application.UseCases.DTO;
using Implementation.Validator;
using Implementation;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private UseCaseHandler _handler;

        public OrderDetailController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateOrderDetailDTO dto,
            [FromServices] ICreateOrderDetailCommand command,
            [FromServices] CreateOrderDetailValidator validator)
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
        public IActionResult Update([FromBody] UpdateOrderDetailDTO dto,
            [FromServices] IUpdateOrderDetailCommand command,
            [FromServices] UpdateOrderDetailValidator validator)
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
        public IActionResult Delete([FromBody] DeleteOrderDetailDTO dto,
            [FromServices] IDeleteOrderDetailCommand command,
            [FromServices] DeleteOrderDetailValidator validator)
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
