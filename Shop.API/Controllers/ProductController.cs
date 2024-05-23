﻿using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.API.Extensions;
using Shop.API.Repositories.Contracts;
using Shop.Models.Dtos;
using Shop.Models.Requests;
using System.Text.Json;

namespace Shop.API.Controllers
{
    /// <summary>
    ///     Controller for handling product-related requests.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly ILogger _logger;
        readonly IProductRepository productRepository;
        // Create the private instance field for the blob service client
        private readonly BlobServiceClient _blobServiceClient;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ProductController" /> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="blobServiceClient"></param>
        public ProductController(IProductRepository productRepository, BlobServiceClient blobServiceClient, ILogger<ProductController> logger)
        {
            this.productRepository = productRepository;
            _logger = logger;
            _blobServiceClient = blobServiceClient;
        }

        /// <summary>
        ///     Gets all items from the product repository.
        /// </summary>
        /// <returns>A list of product DTOs.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            // Try to execute the following code
            try
            {
                // Get the container "test" within the blob service
                var containerClient = _blobServiceClient.GetBlobContainerClient("test").GetBlobsAsync();
                // Output all items in the blob container
                await foreach (var item in containerClient)
                {
                    // Log each property of the object to the console
                    _logger.LogDebug(JsonSerializer.Serialize(item, new JsonSerializerOptions { WriteIndented = true }));
                }



                // Fetch all products from the repository
                var products = await productRepository.GetProducts();
                // Fetch all product categories from the repository
                var productCategories = await productRepository.GetCategories();

                // If either products or product categories are null, return a NotFound status
                if (products == null || productCategories == null)
                {
                    return NotFound();
                }
                // Convert the products to DTOs using the fetched categories
                var productDtos = products.ConvertToDto(productCategories);
                // Return the converted DTOs with an Ok status
                return Ok(productDtos);
            }
            // If any exception occurs during the execution of the try block
            catch (Exception)
            {
                // Return a 500 Internal Server Error status with a custom error message
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProduct([FromRoute]int id)
        {
            var product = await productRepository.GetProduct(id);
            if (product == null) return NotFound();

            var productCategory = await productRepository.GetCategory(product.CategoryId);
            if (productCategory == null) return NotFound();

            var productDto = product.ConvertToDto(productCategory);
            return Ok(productDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct([FromRoute]int id, [FromBody]ProductDto productDto)
        {
            if (id != productDto.Id) return BadRequest();

            var product = productDto.ConvertToEntity();

            try
            {
                product = await productRepository.UpdateProduct(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ProductExists(id))
                    return NotFound();
                throw;
            }

            var productCategory = await productRepository.GetCategory(product.CategoryId);
            if (productCategory == null) return NotFound();

            var updatedProductDto = product.ConvertToDto(productCategory);
            return Ok(updatedProductDto);
        }

        async Task<bool> ProductExists([FromRoute]int id)
        {
            var product = await productRepository.GetProduct(id);
            return product != null;
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProduct([FromRoute]int id)
        {
            var product = await productRepository.GetProduct(id);
            if (product == null) return NotFound();

            try
            {
                await productRepository.DeleteProduct(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error deleting data from the database");
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddProduct([FromBody]NewProductDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Attempt to convert the DTO to an entity before adding it to the repository


            // Return a 400 Bad Request status if the conversion fails
            if (productDto.ConvertToEntity() != null)
                try
                {
                    var product = await productRepository.AddProduct(productDto.ConvertToEntity());
                    var productCategory = await productRepository.GetCategory(product.CategoryId);
                    return Ok(product.ConvertToDto(productCategory));

                }
                catch (Exception exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                    exception.Message);
                }
            return BadRequest(productDto);
        }
    }
}
