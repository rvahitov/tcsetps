using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Correct.Storage.Application.Requests;
using MediatR;

namespace Correct.Storage.RestApi.Controllers
{
    [RoutePrefix("api/box")]
    public class BoxController : ApiController
    {
        private readonly IMediator _mediator;

        public BoxController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateBox(CreateBoxRequest request, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }

            var response = await _mediator.Send(request, cancellationToken).ConfigureAwait(false);
            return Ok(response);
        }
    }
}