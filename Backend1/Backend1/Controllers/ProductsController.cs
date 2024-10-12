using Backend1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly List<Category> _categories;
        private IProductService _productService;

        public ProductsController(IProductService service)
        {
            _productService = service;
            _categories = new List<Category>
    {
        new Category { Id = 1, Title = "Category 1" },
        new Category { Id = 2, Title = "Category 2" },
        new Category { Id = 3, Title = "Category 3" }
    };
        }



        [HttpGet("getAllProducts")]
        public List<GetProductDTO> getAllProducts()
        {
            return _productService.GetProducts();
        }


        [HttpPost("createProduct")]
        public GetProductDTO createProduct(CreateProductDTO newProduct)
        {
            var isThisCategoryExist = _categories.Find(x => x.Id == newProduct.categoryId);
            if (isThisCategoryExist != null)
            {
                var result = _productService.CreateProduct(newProduct);
                return result;
            }
            else
            {
                return null;
            }

        }


        [HttpPut("editProduct{id}")]
        public GetProductDTO updateProduct(int id, [FromBody] CreateProductDTO updatingProduct)
        {
            var updatedProduct = _productService.Update(id, updatingProduct);
            if (updatedProduct == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
            return updatedProduct;
        }




        [HttpDelete("deleteProduct{id}")]
        public void deleteProduct(int id)
        {
            var productExists = _productService.Delete(id);
            if (productExists == null)
            {
                throw new KeyNotFoundException("Product not found");
            }
        }


    }
}
