using ApiRestful.Service.Contexts;
using ApiRestful.Service.ExternalDtos;
using ApiRestful.Service.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace ApiRestful.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;

        public ProductController(ILogger<ProductController> logger, IMapper mapper)
        {
            _logger = logger;            
            _mapper = mapper;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<ProductExternalDto> Get()
        {
            List<ProductEntity> products;
            using (var context = new InventoryContext())
            {
                products = context.Products.ToList();
            }

            if (products != null)
            {
                List<ProductExternalDto> productsDto = _mapper.Map<List<ProductEntity>, List<ProductExternalDto>>(products);                
                _logger.LogInformation("Dont worry about a thing cause every little thing gonna be alright");
                return productsDto;
            }
            else
            {
                _logger.LogWarning("There is not product with this id");
                return null;
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ProductExternalDto Get(string id)
        {
            ProductEntity product;
            using (var context = new InventoryContext())
            {
                product = context.Products.FirstOrDefault(p => p.ProductId == id);
            }
            
            if (product != null)
            {
                ProductExternalDto productDto = _mapper.Map<ProductEntity, ProductExternalDto>(product);
                _logger.LogInformation("Dont worry about a thing cause every little thing gonna be alright");
                return productDto;
            }
            else {
                _logger.LogWarning("There is not product with this id");
                return null;
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] ProductExternalDto productDto)
        {            
            try
            {
                ProductEntity product = _mapper.Map<ProductExternalDto, ProductEntity>(productDto);

                using (var context = new InventoryContext())
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                }

                _logger.LogInformation("Dont worry about a thing cause every little thing gonna be alright");
                //Retorna un 200
                return Ok();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "something goes wrong, maybe you have to change your life ");
                //Retorna un 400, el servidor no supo interpretar la solicitud
                return BadRequest();
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult ActionResult(string id, [FromBody] ProductExternalDto productDto)
        {
            try
            {
                if (productDto.ProductId == id)
                {
                    ProductEntity product = _mapper.Map<ProductExternalDto, ProductEntity>(productDto);

                    using (var context = new InventoryContext())
                    {
                        context.Products.Update(product);
                        context.SaveChanges();
                    }

                    //Retorna un 200
                    _logger.LogInformation("Dont worry about a thing cause every little thing gonna be alright");
                    return Ok();
                }
                else {
                    //Retorna un 400, el servidor no supo interpretar la solicitud
                    _logger.LogWarning("There is not product with this id");
                    return BadRequest();
                }
            }
            catch (System.Exception ex)
            {
                //Retorna un 400, el servidor no supo interpretar la solicitud
                _logger.LogError(ex, "something goes wrong, maybe you have to change your life ");
                return BadRequest();
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                using (var context = new InventoryContext())
                {
                    var product = context.Products.FirstOrDefault(p => p.ProductId == id);
                    if (product != null)
                    {
                        context.Products.Remove(product);
                        context.SaveChanges();

                        //Retorna un 200
                        _logger.LogInformation("Dont worry about a thing cause every little thing gonna be alright");
                        return Ok();
                    }
                    else
                    {
                        //Retorna un 400, el servidor no supo interpretar la solicitud
                        _logger.LogWarning("There is not product with this id");
                        return BadRequest();
                    }
                }
            }
            catch (System.Exception ex)
            {
                //Retorna un 400, el servidor no supo interpretar la solicitud
                _logger.LogError(ex, "something goes wrong, maybe you have to change your life ");
                return BadRequest();
            }
        }
    }
}
