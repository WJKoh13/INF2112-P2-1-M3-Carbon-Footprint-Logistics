using System.Collections.Generic;

namespace BatchDelivery.Models
{
    public enum BatchStatus
    {
        Pending,
        InProgress,
        Delivered,
        Cancelled
    }


    public class DeliveryBatch 
    {
        public string SourceHub { get; set; }
        public string DestinationAddress { get; set; }
        public string DeliveryBatchIdentifier { get; set; }
        public BatchStatus DeliveryBatchStatus { get; set; }
        public int TotalOrders { get; set; }
        public float CarbonSavings { get; set; }
        public List<string> ListOfOrders { get; set; } = new List<string>();


        public bool AddOrder(string orderId)
        {
            if (string.IsNullOrEmpty(orderId) || ListOfOrders.Contains(orderId))
                return false;

            ListOfOrders.Add(orderId);
            TotalOrders = ListOfOrders.Count;
            return true;
        }

        public bool RemoveOrder(string orderId)
        {
            var removed = ListOfOrders.Remove(orderId);
            if (removed)
                TotalOrders = ListOfOrders.Count;
            return removed;
        }

          
    }
}