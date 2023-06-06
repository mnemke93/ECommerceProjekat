using Application.UseCases.Commands;
using Application.UseCases.DTO;
using FluentValidation;
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
    public class ReviewsController : ControllerBase
    {
        private UseCaseHandler _handler;

        public ReviewsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        // POST api/<ReviewsController>
        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateReviewDTO dto,
            [FromServices] ICreateReviewCommand command,
            [FromServices] CreateReviewValidator validator)
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
        public IActionResult Update([FromBody] UpdateReviewDTO dto,
            [FromServices] IUpdateReviewCommand command,
            [FromServices] UpdateReviewValidator validator)
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
        public IActionResult Delete([FromBody] DeleteReviewDTO dto,
            [FromServices] IDeleteReviewCommand command,
            [FromServices] DeleteReviewValidator validator)
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
