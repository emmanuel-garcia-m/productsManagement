
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
    public class ProviderController : ControllerBase
    {        
        private readonly ILogger<ProviderController> _logger;
        private readonly IMapper _mapper;
        private readonly IProviderService _providerService;

        public ProviderController(ILogger<ProviderController> logger, IMapper mapper, IProviderService productService)
        {
            _logger = logger;
            _mapper = mapper;
            _providerService = productService;
        }

        /// <summary>
        /// Lista los proveedores creados en el sistema
        /// </summary>
        /// <param name="pageNumber">Numero de la pagina</param>
        /// <param name="take"></param>       
        /// <returns></returns>       
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(DataCollection<ProductCreateOrEditModel>))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll(int pageNumber = 1, int take = 10)
        {
            try
            {
                DataCollection<Domain.Provider> selected = await _providerService.GetAllAsync(pageNumber, take);
                IEnumerable<Provider> providerselected = _mapper.Map<IEnumerable<Provider>>(selected.Items);

                var result = new DataCollection<Provider>
                {
                    Items = providerselected,
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
        /// Obtiene un proveedor por su código
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>        
        [HttpGet("{code}")]
        [ProducesResponseType(200, Type = typeof(Provider))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetByCode(int code)
        {
            try
            {
                Domain.Provider selected = await _providerService.GetByCodeAsync(code);
                Provider providerelected = _mapper.Map<Provider>(selected);

                if (providerelected == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(providerelected);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }

        }

        /// <summary>
        ///  Crear nuevo proveedor
        /// </summary>
        /// <param name="requestInfo"></param>
        /// <returns></returns> 
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Provider))]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create(ProviderCreateOrEditModel requestInfo)
        {
            try
            {                
                Domain.Provider providerToCrete = _mapper.Map<Domain.Provider>(requestInfo);
                Domain.Provider created = await _providerService.CreateAsync(providerToCrete);
                Provider providerCreated = _mapper.Map<Provider>(created);                
                return Ok(providerCreated);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }

        }
    }
}
