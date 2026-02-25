using System.Collections.Generic;
using System.Data;
using Stage = ReturnStage.Models.ReturnStage;

namespace ReturnStage.Gateways
{
    /// <summary>
    /// Table Data Gateway for ReturnStage.
    /// Handles all DB access for the return_stages table.
    /// </summary>
    public class ReturnStageGateway
    {
        private readonly IDbConnection _db;

        public ReturnStageGateway(IDbConnection db)
        {
            _db = db;
        }

        /// <summary>
        /// Find a single stage by its own ID.
        /// </summary>
        public Stage FindById(string stageId)
        {
            // TODO: SELECT * FROM ReturnStages WHERE StageId = @stageId
            return null;
        }

        /// <summary>
        /// Find all stages belonging to a specific return request.
        /// </summary>
        public List<Stage> FindByReturnId(string returnId)
        {
            // TODO: SELECT * FROM ReturnStages WHERE ReturnRequestId = @returnId
            return new List<Stage>();
        }

        /// <summary>
        /// Find all stages whose total carbon footprint exceeds the given threshold.
        /// </summary>
        public List<Stage> FindHighCarbonStages(float threshold)
        {
            // TODO: SELECT * FROM ReturnStages WHERE TotalCarbon > @threshold
            return new List<Stage>();
        }

        /// <summary>
        /// Return every stage record in the table.
        /// </summary>
        public List<Stage> FindAll()
        {
            // TODO: SELECT * FROM ReturnStages
            return new List<Stage>();
        }

        /// <summary>
        /// Find all stages of a specific type (e.g. Cleaning, Repairing).
        /// </summary>
        public List<Stage> FindByStageType(string stageType)
        {
            // TODO: SELECT * FROM ReturnStages WHERE StageType = @stageType
            return new List<Stage>();
        }

        /// <summary>
        /// Insert a new stage record. Returns true if successful.
        /// </summary>
        public bool Insert(Stage stage)
        {
            // TODO: INSERT INTO ReturnStages (...) VALUES (...)
            return true;
        }

        /// <summary>
        /// Update an existing stage record. Returns true if successful.
        /// </summary>
        public bool Update(Stage stage)
        {
            // TODO: UPDATE ReturnStages SET ... WHERE StageId = @stageId
            return true;
        }

        /// <summary>
        /// Delete a stage record by ID. Returns true if successful.
        /// </summary>
        public bool Delete(string stageId)
        {
            // TODO: DELETE FROM ReturnStages WHERE StageId = @stageId
            return true;
        }
    }
}
