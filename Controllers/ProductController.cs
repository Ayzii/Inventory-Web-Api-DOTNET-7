using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.DTOs;
using Server.Models;
using Server.Services;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ProductsService _ProductsService;

        public ProductController(ProductsService productsService, IMapper mapper)
        {
            _ProductsService = productsService;
            _mapper = mapper;

        }

        [HttpGet("GetProductById/{id}")]
        public IActionResult GetSingleProducts(int id)
        {
            Products_DTO prodDtos = _mapper.Map<Products_DTO>(_ProductsService.GetById(id));
            if (prodDtos != null)
                return Ok(prodDtos);

            return NotFound();
        }


        [HttpGet("GetAllProducts")]
        public IActionResult GetProducts()
        {
            List<Products_DTO> prodDtos = _mapper.Map<List<Products_DTO>>(_ProductsService.Getall());
            return Ok(prodDtos);
        }


        [HttpPost("AddProduct")]
        public async Task<ActionResult<Products_DTO>> AddProduct([FromBody] Products_DTO productDto)
        {
            if (_ProductsService.IsProductExist(productDto))
            {
                return BadRequest("Product alredy Exist");
            }
            return Ok(_mapper.Map<Products_DTO>(_ProductsService.Add(_mapper.Map<Products>(productDto))));
        }


        [HttpPut("UpdateProduct")]
        public Products_DTO UpdateProduct([FromBody] Products_DTO productDTO)
        {
            var updatedProductDto = _mapper.Map<Products_DTO>(_ProductsService.Update(_mapper.Map<Products>(productDTO)));
            return updatedProductDto;
        }

        [HttpDelete("DeleteProduct/{id}")]
        public string DeleteProduct(int id)
        {
            var product = _ProductsService.GetById(id);
            if (product != null)
            {
                _ProductsService.Delete(product);
                return "Product deleted Successfully";
            }
            else
            {
                return "Not Found";
            }
        }

    }
}
