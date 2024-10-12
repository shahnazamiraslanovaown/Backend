using Backend1.Models;

namespace Backend1.Concretes
{
    public class ProductService :IProductService
    {
        private readonly List<GetProductDTO> _products; 
        private int _nextId; 

        public ProductService()
        {
            
            _products = new List<GetProductDTO>
            {
                new GetProductDTO { Id = _nextId++, Title = "Product 1", Price = 9.99m, IsInStock = true, categoryId=1 },
                new GetProductDTO { Id = _nextId++, Title = "Product 2", Price = 19.99m, IsInStock = true,categoryId=1 },
                new GetProductDTO { Id = _nextId++, Title = "Product 3", Price = 29.99m, IsInStock = false,categoryId=2 }
            };
        }
        public GetProductDTO CreateProduct(CreateProductDTO productDto)
        {
            var createdProduct = new GetProductDTO
            {
                Id = _nextId++, 
                Title = productDto.Title,
                Price = productDto.Price,
                IsInStock = productDto.IsInStock,
                categoryId=productDto.categoryId
                
            };

            _products.Add(createdProduct); 

            
            return new GetProductDTO
            {
                Id = createdProduct.Id,
                Title = createdProduct.Title,
                Price = createdProduct.Price,
                IsInStock = createdProduct.IsInStock,
                categoryId=createdProduct.categoryId
            };
        }




        public List<GetProductDTO> GetProducts()
        {
            return _products.Select(product => new GetProductDTO
            {
                Id = product.Id,
                Title = product.Title,
                Price = product.Price,
                IsInStock = product.IsInStock,
                categoryId=product.categoryId
            }).ToList();
        }


        public GetProductDTO Update(int id, CreateProductDTO productWhichIsUpDating)
        {
            var updatingProduct = _products.Find(x => x.Id == id);
            if (updatingProduct != null)
            {
                updatingProduct.Title = productWhichIsUpDating.Title;
                updatingProduct.Price = productWhichIsUpDating.Price;
                updatingProduct.IsInStock = productWhichIsUpDating.IsInStock;
                updatingProduct.categoryId = productWhichIsUpDating.categoryId;

                return updatingProduct; 
            }

            return null; 
        }



        public GetProductDTO Delete(int id)
        {
            var deletingProduct = _products.Find(x => x.Id == id);
            if (deletingProduct != null)
            {
               
                _products.Remove(deletingProduct);
            }
            return deletingProduct;

            
        }

    }
}
