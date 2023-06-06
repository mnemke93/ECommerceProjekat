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
    public class PaymentsController : ControllerBase
    {
        private UseCaseHandler _handler;

        public PaymentsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        [HttpDelete("create")]
        public IActionResult Create([FromBody] CreatePaymentDTO dto,
            [FromServices] ICreatePaymentCommand command,
            [FromServices] CreatePaymentValidator validator)
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
        public IActionResult Update([FromBody] UpdatePaymentDTO dto,
            [FromServices] IUpdatePaymentCommand command,
            [FromServices] UpdatePaymentValidator validator)
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
        [HttpPost("delete")]
        public IActionResult Delete([FromBody] DeletePaymentDTO dto,
            [FromServices] IDeletePaymentCommand command,
            [FromServices] DeletePaymentValidator validator)
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
