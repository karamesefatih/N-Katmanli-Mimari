using NLayer.Core.DTO_S;
using NLayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface ICategoryService:IService<Category>
    {
        public  Task<CustomResponseDTO<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductAsync(int categoryId);
        Task<CustomResponseDTO<object>> GetSingleCategoryByIdWithProductsAsync(int categoryId);
    }
}
