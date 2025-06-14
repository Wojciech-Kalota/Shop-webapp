namespace Server.Data.Services;

using Server.Data.Models;
using Shared;

public class ProductsService
{
    private AppDbContext _context;

    public ProductsService(AppDbContext context)
    {
        _context = context;
    }

    public void AddProduct(ProductEntity product)
    {
        var _product = new Product()
        {
            Name = product.Name,
            Description = product.Description,
            CreatedDate = DateTimeOffset.Now,
            UpdatedDate = DateTimeOffset.Now
        };

        _context.Products.Add(_product);
        _context.SaveChanges();
    }
}
