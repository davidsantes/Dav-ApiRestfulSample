using ApiRestful.Core.Entities;
using ApiRestful.Service.Contexts;
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
        private readonly InventoryContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(InventoryContext context, ILogger<ProductController> logger)
        {
            _logger = logger;
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<ProductEntity> Get()
        {
            List<ProductEntity> products = _context.Products.ToList();
            if (products != null)
            {
                _logger.LogInformation("Dont worry about a thing cause every little thing gonna be alright");
                return products;
            }
            else
            {
                _logger.LogWarning("There is not product with this id");
                return null;
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ProductEntity Get(string id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                _logger.LogInformation("Dont worry about a thing cause every little thing gonna be alright");
                return product;
            }
            else {
                _logger.LogWarning("There is not product with this id");
                return null;
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] ProductEntity product)
        {            
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
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
        public ActionResult ActionResult(string id, [FromBody] ProductEntity product)
        {
            try
            {
                if (product.ProductId == id)
                {
                    _context.Entry(product).State = EntityState.Modified;
                    _context.SaveChanges();

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
                var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();

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
            catch (System.Exception ex)
            {
                //Retorna un 400, el servidor no supo interpretar la solicitud
                _logger.LogError(ex, "something goes wrong, maybe you have to change your life ");
                return BadRequest();
            }
        }
    }
}
