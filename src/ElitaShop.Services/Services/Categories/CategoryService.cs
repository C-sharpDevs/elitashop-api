﻿using ElitaShop.Domain.Exceptions.Categories;
using ElitaShop.Services.Interfaces.Categories;

namespace ElitaShop.Services.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileService _fileService;

        public CategoryService(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IFileService fileService)
        {
            this._categoryRepository = unitOfWork.CategoryRepository;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._fileService = fileService;
        }

        public async Task<bool> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            string imagePath = await _fileService.UploadImageAsync(categoryCreateDto.CategoryImage);

            Category? category = _mapper.Map<Category>(categoryCreateDto);
            category.CategoryImage = imagePath;
            await _categoryRepository.AddAsync(category);
            int result = await _unitOfWork.CommitAsync();

            return result > 0;
        }

        public async Task<bool> DeleteAsync(long categoryId)
        {
            Category category = await _categoryRepository.GetAsync(category => category.Id == categoryId);
            if (category is null) throw new CategoryNotFoundException();

            var image = await _fileService.DeleteImageAsync(category.CategoryImage);
            if (image == false) throw new ImageNotFoundException();

            _categoryRepository.Remove(category);
            int result = await _unitOfWork.CommitAsync();

            return result > 0;
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.ToList();
        }

        public async Task<Category> GetByIdAsync(long categoryId)
        {
            var category = await _categoryRepository.GetAsync(category => category.Id == categoryId);
            if (category is null) throw new CategoryNotFoundException();

            return category;
        }

        public async Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto categoryUpdateDto)
        {
            Category category = await _categoryRepository.GetAsync(category => category.Id == categoryId);
            if (category is null) throw new CategoryNotFoundException();

            Category categoryMap = _mapper.Map<Category>(categoryUpdateDto);
            categoryMap.Id = categoryId;

            if (categoryUpdateDto.CategoryImage is not null)
            {
                var image = await _fileService.DeleteImageAsync(category.CategoryImage);
                if (image == false) throw new ImageNotFoundException();

                string newImagePath = await _fileService.UploadImageAsync(categoryUpdateDto.CategoryImage);
                categoryMap.CategoryImage = newImagePath;
            }

            categoryMap.UpdatedAt = DateTime.UtcNow;

            _categoryRepository.Update(categoryMap);
            int result = await _unitOfWork.CommitAsync();

            return result > 0;
        }

    }
}
