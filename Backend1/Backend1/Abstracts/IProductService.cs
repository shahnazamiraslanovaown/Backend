using Backend1.Models;

public interface IProductService
{
    GetProductDTO CreateProduct(CreateProductDTO productDto);
    List<GetProductDTO> GetProducts();
    GetProductDTO Update(int id, CreateProductDTO productDto);
    GetProductDTO Delete(int id);
}
