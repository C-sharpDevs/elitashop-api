using ElitaShop.DataAccess.Interfaces.EntityRepositories;
using ElitaShop.DataAccess.Paginations;
using ElitaShop.Services.Interfaces.Categories;
using ElitaShop.Services.Interfaces.Common;

namespace ElitaShop.Services.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _context;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public CategoryService(ICategoryRepository categoryRepository,
            IMapper mapper,
            IFileService fileService)
        {
            this._context = categoryRepository;
            this._mapper = mapper;
            this._fileService = fileService;
        }

        public Task<bool> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Category>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetByIdAsync(long categoryId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto categoryUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
