using Domain.Entities;
using Infrastructure.ApiResponses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Product>>> GetAllAsync()
    {
        return await productService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<Response<Product>> GetByIdAsync(int id)
    {
        return await productService.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> CreateAsync(Product request)
    {
        return await productService.CreateAsync(request);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateAsync(Product request)
    {
        return await productService.UpdateAsync(request);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        return await productService.DeleteAsync(id);
    }
}