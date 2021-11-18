namespace Domain.Models
{
    public class PurchaseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public int Count { get; set; }
        public string CategoryId { get; set; }
    }
}
