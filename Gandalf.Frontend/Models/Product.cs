namespace Gandalf.Frontend.Models
{
    public class Product
    {
        public int? Id { get; set; }
        public required string Name { get; set; }
        public required int CategoryId { get; set; }
        //public Category Category { get; set; }
        public string? ImageLink { get; set; }

    }
}
