using Microsoft.AspNetCore.Mvc;
using MiniCursoCSharp.API.UseCases.Clients.Register;
using MIniCursoCSharp.Communication.Requests;
using MIniCursoCSharp.Communication.Responses;

namespace MiniCursoCSharp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(RequestClientJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorMessagesJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestClientJson request)
        {
            try
            {
                var useCase = new RegisterClientUseCase();
                var response = useCase.Execute(request);
                return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ResponseErrorMessagesJson(new List<string> { ex.Message }));
            }
            catch (Exception ex)
            {
                var errors = ex.GetBaseException().Message;
                ex.GetBaseException();
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson(new List<string> { ex.Message }));
            }
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
    public class RegisterClientUseCase
    {
        public ResponseClientJson Execute(RequestClientJson request)
        {
            // Implementation here
            return new ResponseClientJson
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone
            };
        }
    }
    public class ResponseErrorMessagesJson(List<string> errors)
    {
        public List<string> Errors { get; private set; } = errors;
    }
}

public class ResponseClientJson
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
}

public class RequestClientJson
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; internal set; }
}
