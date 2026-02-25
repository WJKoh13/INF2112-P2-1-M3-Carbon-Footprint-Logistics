using Microsoft.AspNetCore.Mvc;
using ReturnStage.Gateways;
using ReturnStage.Managers;
using Stage = ReturnStage.Models.ReturnStage;

namespace ReturnStage.Controllers
{
    public class ReturnStageController : Controller
    {
        private readonly ReturnStageManager _manager;
        private readonly ReturnStageGateway _gateway;

        public ReturnStageController(ReturnStageManager manager, ReturnStageGateway gateway)
        {
            _manager = manager;
            _gateway = gateway;
        }

        // GET: /ReturnStage
        // Lists all return stages
        public IActionResult Index()
        {
            var stages = _gateway.FindAll();
            return View(stages);
        }

        // GET: /ReturnStage/Details/{stageId}
        // Handles viewing a specific stage — maps to HandleReturnStage() in UML
        public IActionResult HandleReturnStage(string stageId)
        {
            var stage = _gateway.FindById(stageId);
            if (stage == null)
                return NotFound();

            return View("Details", stage);
        }

        // GET: /ReturnStage/Report/{returnRequestId}
        // Displays the full carbon report for a return request
        public IActionResult CarbonReport(string returnRequestId)
        {
            var report = _manager.GetCarbonReport(returnRequestId);
            if (report == null)
                return NotFound();

            return View("CarbonReport", report);
        }

        // GET: /ReturnStage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /ReturnStage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Stage stage)
        {
            if (!ModelState.IsValid || !stage.IsValidStage())
                return View(stage);

            _gateway.Insert(stage);
            return RedirectToAction("Index");
        }

        // GET: /ReturnStage/Edit/{stageId}
        public IActionResult Edit(string stageId)
        {
            var stage = _gateway.FindById(stageId);
            if (stage == null)
                return NotFound();

            return View(stage);
        }

        // POST: /ReturnStage/Edit/{stageId}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string stageId, Stage stage)
        {
            if (!ModelState.IsValid || !stage.IsValidStage())
                return View(stage);

            _gateway.Update(stage);
            return RedirectToAction("Index");
        }

        // POST: /ReturnStage/Delete/{stageId}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(string stageId)
        {
            _gateway.Delete(stageId);
            return RedirectToAction("Index");
        }
    }
}