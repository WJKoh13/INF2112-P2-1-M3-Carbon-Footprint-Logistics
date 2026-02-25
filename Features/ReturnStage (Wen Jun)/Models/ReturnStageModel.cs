using System;
using System.Collections.Generic;

namespace ReturnStage.Models
{
    // Enumeration of valid return stage types
    public enum ReturnStageType
    {
        DamageInspection,
        Repairing,
        Servicing,
        Cleaning,
        ReturnToInventory
    }

    public class ReturnStage
    {
        public string StageId { get; set; }

        // Foreign key from Module 2 ReturnRequest
        public string ReturnRequestId { get; set; }

        public float TotalCarbon { get; set; }

        public double EnergyKWh { get; set; }
        public double LabourHours { get; set; }
        public double MaterialsKg { get; set; }
        public double CleaningSuppliesQty { get; set; }
        public double WaterLitres { get; set; }
        public double PackagingKg { get; set; }
        public decimal SurchargeRate { get; set; }

        public ReturnStageType StageType { get; set; }

        /// <summary>
        /// Validates that this stage has all required resource fields populated.
        /// </summary>
        public bool IsValidStage()
        {
            // TODO: Add specific business validation rules per stage type if needed
            return !string.IsNullOrEmpty(ReturnRequestId)
                && EnergyKWh >= 0
                && LabourHours >= 0
                && MaterialsKg >= 0
                && CleaningSuppliesQty >= 0
                && WaterLitres >= 0
                && PackagingKg >= 0;
        }

        /// <summary>
        /// Returns the sum of all resource quantities for this stage.
        /// </summary>
        public double GetTotalResourceCount()
        {
            return EnergyKWh + LabourHours + MaterialsKg
                 + CleaningSuppliesQty + WaterLitres + PackagingKg;
        }
    }

    /// <summary>
    /// Represents a full carbon report generated for a return request.
    /// Used as the return type for GetCarbonReport().
    /// </summary>
    public class CarbonReport
    {
        public string ReturnRequestId { get; set; }
        public float TotalCarbon { get; set; }
        public float TotalSurcharge { get; set; }
        public List<ReturnStage> StageBreakdown { get; set; } = new List<ReturnStage>();
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
    }
}