using ApiRestfulSample.Contexts;
using ApiRestfulSample.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestfulSample.Controllers
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
            _logger.LogInformation("Dont worry about a thing cause every little thing gonna be alright");
            return _context.Products.ToList();            
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ProductEntity Get(string id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            return product;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult Post([FromBody] ProductEntity product)
        {            
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                //Retorna un 200
                return Ok();
            }
            catch (System.Exception ex)
            {
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
                    return Ok();
                }
                else {
                    //Retorna un 400, el servidor no supo interpretar la solicitud
                    return BadRequest();
                }
            }
            catch (System.Exception ex)
            {
                //Retorna un 400, el servidor no supo interpretar la solicitud
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
                    return Ok();
                }
                else
                {
                    //Retorna un 400, el servidor no supo interpretar la solicitud
                    return BadRequest();
                }
            }
            catch (System.Exception ex)
            {
                //Retorna un 400, el servidor no supo interpretar la solicitud
                return BadRequest();
            }
        }
    }
}
