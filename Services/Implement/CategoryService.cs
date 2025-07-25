using DataAccessObjects.Define;
using Services.Define;
using Services.DTO;

namespace Services.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = _unitOfWork.Categorys.GetAll();
            return categories.Select(p => new CategoryDto
            {
                CategoryId = p.CategoryId,
                CategoryName = p.CategoryName,
                Description = p.Description
            });
        }
    }
}
