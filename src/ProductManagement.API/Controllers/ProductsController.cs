
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductManagement.API.DTOs;
using ProductsManagement.Domain.Common;
using ProductsManagement.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain = ProductsManagement.Domain.Domain;

namespace ProductManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {        
        private readonly ILogger<ProductsController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductsController(ILogger<ProductsController> logger, IMapper mapper, IProductService productService)
        {
            _logger = logger;
            _mapper = mapper;
            _productService = productService;
        }

        /// <summary>
        /// Lista los productos creados en el sistema
        /// </summary>
        /// <param name="pageNumber">Numero de la pagina</param>
        /// <param name="take"></param>       
        /// <returns></returns>       
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(DataCollection<Product>))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int take = 10)
        {
            try
            {
                DataCollection<Domain.Product> selected = await _productService.GetAllAsync(pageNumber, take);
                IEnumerable<Product> productselected = _mapper.Map<IEnumerable<Product>>(selected.Items);

                var result = new DataCollection<Product>
                {
                    Items = productselected,
                    Total = selected.Total,
                    Page = selected.Page,
                    Pages = selected.Pages
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }

        }


        /// <summary>
        /// Obtiene un producto por su código
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>        
        [HttpGet("{code}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetByCode(int code)
        {
            try
            {
                Domain.Product selected = await _productService.GetByCodeAsync(code);
                Product productselected = _mapper.Map<Product>(selected);

                if (productselected == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(productselected);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }

        }


        /// <summary>
        ///  Crear nuevo producto
        /// </summary>
        /// <param name="requestInfo"></param>
        /// <returns></returns> 
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Product))]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create(ProductCreateOrEditModel requestInfo)
        {
            try
            {                
                Domain.Product productToCrete = _mapper.Map<Domain.Product>(requestInfo);
                Domain.Product created = await _productService.CreateAsync(productToCrete, requestInfo.ProviderCode);
                Product productCreated = _mapper.Map<Product>(created);                
                return Ok(productCreated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }

        }


        /// <summary>
        /// Actualiza un producto
        /// </summary>
        /// <param name="code"></param>
        /// <param name="requestInfo"></param>
        /// <returns></returns>
        [HttpPut("{code}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update(int code, ProductCreateOrEditModel requestInfo)
        {
            try
            {
                Domain.Product selected = await _productService.GetByCodeAsync(code);
               

                if (selected == null)
                {
                    return NotFound();
                }
                else
                {
                    Domain.Product productToUpdate= _mapper.Map<Domain.Product>(requestInfo);
                    _productService.UpdateAsync(productToUpdate);
                    return NoContent(); ;
                }                    
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Elimina un producto
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpDelete("{code}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteByCode(int code)
        {
            try
            {
                Domain.Product selected = await _productService.GetByCodeAsync(code);                

                if (selected == null)
                {
                    return NotFound();
                }
                else
                {
                    _productService.DeleteAsync(code);
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }

        }


    }
}
