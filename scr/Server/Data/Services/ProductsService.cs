namespace Server.Data.Services;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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

    //public List<Product> GetProductsContaining(string substring)
    //{
    //    return _context.Products.Where(n => !n.IsDeleted && n.Name.Contains(substring)).ToList();
    //}

    //public List<Product> GetProductsByPage(int page, int pageSize)
    //{
    //    var totalCount = _context.Products.Count();
    //    var totalPages = Math.Ceiling((decimal)totalCount / pageSize);
    //    var products = _context.Products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
    //    return products;

    //}

    public PageResult<Product> GetProducts(string search, int page, int pageSize)
    {
        var query = _context.Products.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(p => !p.IsDeleted && p.Name.Contains(search));
        }
        else
        {
            query = query.Where(p => !p.IsDeleted);
        }

        var totalCount = query.Count();

        var items = query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new PageResult<Product>
        {
            Items = items,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize,
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
        };

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
        var product = _context.Products
            .Include(p => p.Comments)
            .FirstOrDefault(p => p.Id == productId && !p.IsDeleted);

        if (product != null)
        {
            product.IsDeleted = true;

            if (product.Comments != null)
            {
                foreach (var comment in product.Comments)
                {
                    comment.IsDeleted = true;
                }
            }

            _context.SaveChanges();
        }
    }

    public List<Comment> GetAllProductComments(Guid productId)
    {
        return _context.Comments.Where(n => n.ProductId == productId && !n.IsDeleted).ToList();
    }



}
