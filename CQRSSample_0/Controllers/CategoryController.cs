using CQRSSample_0.CQRS.Commands.CategoryCommands;
using CQRSSample_0.CQRS.Handlers.CategoryHandlers.Modify;
using CQRSSample_0.CQRS.Handlers.CategoryHandlers.Read;
using CQRSSample_0.CQRS.Results.CategoryResults;
using CQRSSample_0.CQRS.Queries.CategoryQueries;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using MediatR;

namespace CQRSSample_0.Controllers
{
    public class CategoryController : Controller
    {
        /* constructor hell problem may occur without using mediatr */
        //readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        //readonly GetCategoryByIDQueryHandler _getCategoryByIDQueryHandler;
        //readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        //readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        //readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

        // mediatr
        readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            List<GetCategoryQueryResult> categories = await _mediator.Send(new GetCategoryQuery());
            return View(categories);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            await _mediator.Send(createCategoryCommand);
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            GetCategoryByIDQueryResult value = await _mediator.Send(new GetCategoryByIDQuery(id));

            UpdateCategoryCommand command = new()
            {
                CategoryID = value.CategoryId,
                CategoryName = value.CategoryName,
                Description = value.Description
            };

            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
        {
            await _mediator.Send(updateCategoryCommand);
            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _mediator.Send(new RemoveCategoryCommand(id));
            return RedirectToAction("CategoryList");
        }
    }
}
