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
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseErrorMessagesJson([ex.Message]));
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
                Name = request.Name
            };
        }
    }
    public class ResponseErrorMessagesJson
    {
        public List<string> Errors { get; private set; }

        public ResponseErrorMessagesJson(List<string> errors)
        {
            Errors = errors;
        }
    }
}
