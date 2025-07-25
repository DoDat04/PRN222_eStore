using Services.DTO;


namespace Services.Define
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task AddAsync(ProductDto productDto);
        Task<bool> UpdateAsync(ProductDto productDto);
        Task DeleteAsync(int id);
    }
}
