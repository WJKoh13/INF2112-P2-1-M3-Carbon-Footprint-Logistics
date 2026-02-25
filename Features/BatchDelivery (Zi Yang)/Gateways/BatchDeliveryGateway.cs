using System.Collections.Generic;
using System.Data;
using BatchDelivery.Models;

namespace BatchDelivery.Gateways
{
    public class DeliveryBatchMapper
    {
        private readonly IDbConnection _db;

        public DeliveryBatchMapper(IDbConnection db)
        {
            _db = db;
        }

        // Fetch all batches for a given warehouse filtered by status
        public List<DeliveryBatch> GetBatchByStatus(string warehouse, BatchStatus status)
        {
            // Execute query against DB and map rows to DeliveryBatch objects
            // e.g. SELECT * FROM DeliveryBatches WHERE SourceHub = @warehouse AND Status = @status
            var results = new List<DeliveryBatch>();
            // ... DB logic here ...
            return results;
        }

        // Persist a batch — decides whether to insert or update
        public void Save(DeliveryBatch batch)
        {
            var existing = FindByIdentifier(batch.DeliveryBatchIdentifier);
            if (existing == null)
                Insert(batch);
            else
                Update(batch);
        }

        // Find a single batch by its unique identifier
        public DeliveryBatch FindByIdentifier(string batchIdentifier)
        {
            // SELECT * FROM DeliveryBatches WHERE DeliveryBatchIdentifier = @batchIdentifier
            return null; // replace with actual DB call
        }

        // Return all delivery batches
        public List<DeliveryBatch> FindAll()
        {
            // SELECT * FROM DeliveryBatches
            return new List<DeliveryBatch>();
        }

        // Insert a new batch record
        public bool Insert(DeliveryBatch batch)
        {
            // INSERT INTO DeliveryBatches (...) VALUES (...)
            return true;
        }

        // Update an existing batch record
        public bool Update(DeliveryBatch batch)
        {
            // UPDATE DeliveryBatches SET ... WHERE DeliveryBatchIdentifier = @id
            return true;
        }
    }
}