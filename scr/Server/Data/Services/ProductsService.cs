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
            Description = product.Description
        };

        _context.Products.Add(_product);
        _context.SaveChanges();
    }

    public Product GetProductById(Guid productId)
    {
        return _context.Products.Where(n => !n.IsDeleted).FirstOrDefault(n => n.Id == productId);
    }

    public List<Product> GetAllProducts()
    {
        return _context.Products.Where(n => !n.IsDeleted).ToList();
    }

    public Product UpdateProductById(Guid productId, ProductEntity product)
    {
        var _product = _context.Products.Where(n => !n.IsDeleted).FirstOrDefault(n => n.Id == productId);
        if (_product != null)
        {
            _product.Name = product.Name;
            _product.Description = product.Description;
            _product.UpdatedDate = DateTime.Now;

            _context.SaveChanges();
        }

        return _product;
    }

    public void DeledeProductById(Guid productId)
    {
        var _product = _context.Products.Where(n => !n.IsDeleted).FirstOrDefault();
        if (_product != null)
        {
            _product.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
