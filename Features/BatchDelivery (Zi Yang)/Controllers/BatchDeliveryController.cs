using Microsoft.AspNetCore.Mvc;
using BatchDelivery.Gateways;
using BatchDelivery.Models;
using System.Collections.Generic;

namespace BatchDelivery.Controllers
{
    public class BatchDeliveryController : Controller
    {
        private readonly DeliveryBatchMapper _mapper;

        public BatchDeliveryController(DeliveryBatchMapper mapper)
        {
            _mapper = mapper;
        }

        // GET: /BatchDelivery
        // Lists all delivery batches
        public IActionResult Index()
        {
            var batches = _mapper.FindAll();
            return View("~/Features/BatchDelivery/Views/BatchDelivery.cshtml", batches);
        }

        // GET: /BatchDelivery/Details/{batchId}
        // Handles selecting and viewing a specific batch
        public IActionResult HandleBatchSelection(string batchId)
        {
            var batch = _mapper.FindByIdentifier(batchId);
            if (batch == null)
                return NotFound();

            return View("Details", batch);
        }

        // POST: /BatchDelivery/Consolidate
        // Triggers order consolidation logic for a batch
        [HttpPost]
        public IActionResult ConsolidateOrder(string orderId, string destHub, float orderWeight)
        {
            // In a fuller implementation, this would call BatchDeliveryManager
            // to run batchOrderConsolidator and then save the updated batch
            var batch = _mapper.FindByIdentifier(orderId);
            if (batch == null)
                return NotFound();

            // ... consolidation logic via BatchDeliveryManager ...

            _mapper.Save(batch);
            return RedirectToAction("Index");
        }
    }
}