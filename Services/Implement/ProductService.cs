using BusinessObjects;
using DataAccessObjects.Define;
using Services.Define;
using Services.DTO;

namespace Services.Implement
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public Task AddAsync(ProductDto productDto)
        {
            var product = new Product
            {
                ProductId = productDto.ProductId,
                CategoryId = productDto.CategoryId,
                ProductName = productDto.ProductName,
                Weight = productDto.Weight,
                UnitPrice = productDto.UnitPrice,
                UnitsInStock = productDto.UnitsInStock,
                ImageUrl = productDto.ImageUrl,
                Discount = productDto.Discount
            };
            _unitOfWork.Products.Add(product);
            _unitOfWork.Save();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            if (product != null)
            {
                product.IsActive = false;
                _unitOfWork.Products.Update(product);
                _unitOfWork.Save();
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = _unitOfWork.Products.GetAll(x => x.IsActive == true, x => x.Category);
            var result = products.Select(p => new ProductDto
            {
                ProductId = p.ProductId,
                CategoryId = p.CategoryId,
                ProductName = p.ProductName,
                Weight = p.Weight,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                ImageUrl = p.ImageUrl,
                Discount = p.Discount,
                CategoryName = p.Category != null ? p.Category.CategoryName : string.Empty,
                IsActive = p.IsActive
            });
            return Task.FromResult(result);
        }

        public Task<ProductDto?> GetByIdAsync(int id)
        {
            var existingProduct = _unitOfWork.Products.GetById(id);
            if (existingProduct == null)
                return Task.FromResult<ProductDto?>(null);

            var result = new ProductDto
            {
                ProductId = existingProduct.ProductId,
                CategoryId = existingProduct.CategoryId,
                ProductName = existingProduct.ProductName,
                Weight = existingProduct.Weight,
                UnitPrice = existingProduct.UnitPrice,
                UnitsInStock = existingProduct.UnitsInStock,
                ImageUrl = existingProduct.ImageUrl,
                Discount = existingProduct.Discount,
                IsActive = existingProduct.IsActive
            };
            return Task.FromResult<ProductDto?>(result);
        }

        public Task<bool> UpdateAsync(ProductDto productDto)
        {
            try
            {
                var existingProduct = _unitOfWork.Products.GetById(productDto.ProductId);
                if (existingProduct == null)
                    return Task.FromResult(false);

                existingProduct.CategoryId = productDto.CategoryId;
                existingProduct.ProductName = productDto.ProductName;
                existingProduct.Weight = productDto.Weight;
                existingProduct.UnitPrice = productDto.UnitPrice;
                existingProduct.UnitsInStock = productDto.UnitsInStock;
                existingProduct.ImageUrl = productDto.ImageUrl;
                existingProduct.Discount = productDto.Discount;
                existingProduct.IsActive = productDto.IsActive;

                _unitOfWork.Products.Update(existingProduct);
                _unitOfWork.Save();

                Console.WriteLine("Update completed successfully!");
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating product: {ex.Message}");
                return Task.FromResult(false);
            }
        }
    }
}