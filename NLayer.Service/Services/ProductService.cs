using AutoMapper;
using NLayer.Core.DTO_S;
using NLayer.Core.Models;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productrepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork,IMapper mapper,IProductRepository productRepository):base (repository,unitOfWork) 
        {
            _mapper = mapper;
            _productrepository = productRepository;
        }

        public async Task<CustomResponseDTO<List<ProductWithCategoryDto>>> GetProductWitCategory()
        {
            var products = await _productrepository.GetProductsWithCategory();
            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return CustomResponseDTO<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }
    }
}
