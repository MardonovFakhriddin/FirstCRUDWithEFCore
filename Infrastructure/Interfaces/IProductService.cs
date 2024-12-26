using Domain.Entities;
using Infrastructure.ApiResponses;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    Task<Response<List<Product>>> GetAllAsync();
    Task<Response<Product>> GetByIdAsync(int id);
    Task<Response<string>> CreateAsync(Product request);
    Task<Response<string>> UpdateAsync(Product request);
    Task<Response<string>> DeleteAsync(int id);
}