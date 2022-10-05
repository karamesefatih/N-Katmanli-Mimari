﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTO_S;
using NLayer.Core.Models;
using NLayer.Core.Services;
using NLayer.API.Controllers;

namespace NLayer.API.Controllers
{

    public class ProductsController : BaseController
    {
        private readonly IMapper _mapper;
   
        private readonly IProductService _service;
        public ProductsController(IService<Product> service, IMapper mapper, IProductService productService = null)
        {
         
            _mapper = mapper;
            _service = productService;
        }


        //GET api/products/GetProductsWithCategory
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductWithCategory()
        {
            return CreateActionResult(await _service.GetProductWitCategory());


        }








        [HttpGet]
        public async Task<IActionResult> All(){
        var products = await _service.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult<List<ProductDto>>(CustomResponseDTO<List<ProductDto>>.Success(200, productDtos));
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDTO<ProductDto>.Success(200, productsDto));
        }
        [HttpPost()]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDTO<ProductDto>.Success(201, productsDto));
        }
        [HttpPut()]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));

            return CreateActionResult(CustomResponseDTO<NoContentDto>.Success(204));
        }
        [HttpDelete("id")]
        public async Task<IActionResult> Remove(int id)
        {
            
            var product = await _service.GetByIdAsync(id);
            if (product == null)
            {
                return CreateActionResult(CustomResponseDTO<NoContentDto>.Fail(404, "Bulunamadı"));
            }
                await _service.RemoveAsync(product);
          
            return CreateActionResult(CustomResponseDTO<NoContentDto>.Success(204));
        }


    }
}
