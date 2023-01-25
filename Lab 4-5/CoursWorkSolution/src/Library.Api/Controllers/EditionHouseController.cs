using IdentityServer4.Extensions;
using Library.BusinessLogic.DTO_s;
using Library.BusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Authorize(Roles = ("Admin"))]
    public class EditionHouseController : Controller
    {
        private readonly IEditionHouseService _editionHouseService;

        public EditionHouseController(IEditionHouseService editionHouseService)
        {
            _editionHouseService = editionHouseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var list = await _editionHouseService.GetEditionHousesAsync();

            if (list.IsNullOrEmpty())
            {
                return View();
            }

            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EditionHouseDto editionHouse)
        {
            await _editionHouseService.AddAsync(editionHouse);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var edition = await _editionHouseService.GetEditionHouseById(id);

            return View(edition);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditionHouseDto editionHouseDto)
        {
            await _editionHouseService.UpdateAsync(editionHouseDto);

            return RedirectToAction("Index");
        }

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var edition = await _editionHouseService.GetEditionHouseById(id);

			return View(edition);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(EditionHouseDto editionHouseDto)
		{
			await _editionHouseService.DeleteAsync(editionHouseDto);

			return RedirectToAction("Index");
		}
	}
}
