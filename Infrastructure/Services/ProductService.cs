using System.Net;
using Domain.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ProductService(DataContext context) : IProductService
{
    public async Task<Response<List<Product>>> GetAllAsync()
    {
        var products = await context.Products.ToListAsync();
        return new Response<List<Product>>(products);
    }

    public async Task<Response<Product>> GetByIdAsync(int id)
    {
        var product = await context.Products.FirstOrDefaultAsync((p => p.Id == id));
        return product == null
            ? new Response<Product>(HttpStatusCode.NotFound, "Product not found")
            : new Response<Product>(product);
    }

    public async Task<Response<string>> CreateAsync(Product request)
    {
        await context.Products.AddAsync(request);
        var result = await context.SaveChangesAsync();
        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Product not created")
            : new Response<string>("Product created successfully");
    }

    public async Task<Response<string>> UpdateAsync(Product request)
    {
        var existingProduct = await context.Products.FirstOrDefaultAsync(p => p.Id == request.Id);
        if (existingProduct == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Product not found");
        }

        existingProduct.Name = request.Name;
        existingProduct.Price = request.Price;
        existingProduct.Category = request.Category;

        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "product not updated")
            : new Response<string>("Product updated successfully");
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var existingProduct = await context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (existingProduct == null)
        {
            return new Response<string>(HttpStatusCode.NotFound, "Product not found");
        }

        context.Remove(existingProduct);
        var result = await context.SaveChangesAsync();

        return result == 0
            ? new Response<string>(HttpStatusCode.InternalServerError, "Product not deleted")
            : new Response<string>("Product deleted successfully");
    }
}