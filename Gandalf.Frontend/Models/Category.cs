using System.Collections.ObjectModel;

namespace Gandalf.Frontend.Models;

public class Category
{
    public Category()
    {
        Products = new Collection<Product>();
    }

    public int Id { get; set; }
    public required string Name { get; set; }
    public Collection<Product> Products { get; set; }

}
