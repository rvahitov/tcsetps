using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Correct.Storage.Application.Requests;
using MediatR;

namespace Correct.Storage.Portal.Controllers
{
    public class BoxController : Controller
    {
        private readonly IMediator _mediator;

        public BoxController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult CreateBoxGet()
        {
            return View("CreateBox",new CreateBoxRequest());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> CreateBoxPost(CreateBoxRequest postData, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid == false)
            {
                return View("CreateBox",postData);
            }

            await _mediator.Send(postData, cancellationToken)
                .ConfigureAwait(false);
            return RedirectToAction("Index");
        }
    }
}