namespace MaalSuchiAPI.Models
{
    public class StoreItem
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Quantity { get; set; }
        public int VendorId { get; set; }
        public string? Notes { get; set; }
        public decimal TotalQuantity { get; set; }
    }
}
