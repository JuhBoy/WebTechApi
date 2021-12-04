using System;
using System.Threading.Tasks;
using CommandLib;
using EcoApiEscen.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EcoApiEscen.Controllers {
    [ApiController, // Register the controller for the DI
     Route("products")] // Register the access (i.e. http://localhost:5000/products
    public class ProductController : ControllerBase {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger) {
            _productService = productService; // DI for service
            _logger = logger; // DI for logger
        }

        [HttpGet("all"), // Simple GET URL (i.e. http://localhost:5000/products/all)
         Produces(typeof(Product[])), // Add info on return type (will be used by swagger to generate a json example value)
         ProducesResponseType(StatusCodes.Status204NoContent), // add possible response type (on error)
         ProducesResponseType(StatusCodes.Status200OK) // add possible response type (on Ok)
        ]
        public async Task<IActionResult> GetAll() {
            _logger.Log(LogLevel.Information, "Get: all products"); // Simply add logging to console

            try { // Make sure to control errors
                var products = await _productService.GetAllProducts(); // Async call
                return Ok(products); // Return 200, Body contains the product array
            } catch (Exception ex) {
                _logger.Log(LogLevel.Error, $"{ex.Message} \n {ex.InnerException?.Message}"); // Log the error message
                return NoContent(); // An Error should not be forwarded to client side so, return nothing.
            }
        }

        [HttpPost("create"), Produces(typeof(Product)), ProducesResponseType(StatusCodes.Status204NoContent), ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Create() {
            _logger.Log(LogLevel.Information, "Post: create product");

            try {
                Product product = await _productService.Create();
                return Ok(product);
            } catch (Exception ex) {
                _logger.Log(LogLevel.Error, $"{ex.Message} \n {ex.InnerException?.Message}");
                return NoContent();
            }
        }
    }
}