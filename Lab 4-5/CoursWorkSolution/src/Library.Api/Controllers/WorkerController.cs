using Library.Api.Models;
using Library.BusinessLogic.Services;
using Library.DataAccess.Models;
using Library.DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
	[Authorize(Roles = ("Admin"))]
    public class WorkerController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IPositionRepository _positionRepository;

		public WorkerController(IAccountService accountService, IPositionRepository positionRepository)
		{
			_accountService = accountService;
			_positionRepository = positionRepository;
		}

		public async Task<IActionResult> Index()
        {
            var workers = await _accountService.GetWorkersAsync();

            if (workers == null) 
            {
                return View();
            }

            return View(workers);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
			ViewBag.Positions = await _positionRepository.GetPositionsAsync();

			return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkerModel model)
        {
            var worker = new Worker()
            {
                Name = model.Name,
                Email = model.Email,
                PositionId = model.PositionId
            };

            await _accountService.AddAsync(worker);

            return RedirectToAction("Index");
		}

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var worker = await _accountService.GetWorkerByIdAsync(id);

            var model = new WorkerModel()
            {
                PositionId = worker.PositionId,
                PositionName = worker.Position.Name,
                Email = worker.Email,
                Name = worker.Name,
                Id = worker.Id
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(WorkerModel worker)
        {
            await _accountService.DeleteWorker(new Worker
            {
                PositionId = worker.PositionId,
                Email = worker.Email,
                Name = worker.Name,
                Id = worker.Id
            });

            return RedirectToAction("Index", "Worker");
        }

		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			var worker = await _accountService.GetWorkerByIdAsync(id);

			ViewBag.Positions = await _positionRepository.GetPositionsAsync();

			var model = new WorkerModel()
			{
				PositionId = worker.PositionId,
				PositionName = worker.Position.Name,
				Email = worker.Email,
				Name = worker.Name,
				Id = worker.Id
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Update(WorkerModel worker)
		{
			await _accountService.UpdateWorkerAsync(new Worker
			{
				PositionId = worker.PositionId,
				Email = worker.Email,
				Name = worker.Name,
				Id = worker.Id
			});

			return RedirectToAction("Index", "Worker");
		}

	}
}
