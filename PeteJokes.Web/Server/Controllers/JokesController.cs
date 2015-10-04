using System.Threading.Tasks;
using System.Web.Http;
using MediatR;
using PeteJokes.Queries;

namespace PeteJokes.Web.Server.Controllers
{
    public class JokesController : ApiController
    {
        private readonly IMediator _mediator;

        public JokesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/Jokes/Recent")]
        public async Task<IHttpActionResult> Recent()
        {
            var jokes = await _mediator.SendAsync(new RecentJokesQuery());
            return Ok(jokes);
        }
    }
}