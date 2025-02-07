namespace Gandalf.Admin.Models
{
    public class Product
    {
        public int? Id { get; set; }
        public required string Name { get; set; }
        public required int CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public string? ImageLink { get; set; }

    }
}
