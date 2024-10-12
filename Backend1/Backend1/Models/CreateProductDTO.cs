namespace Backend1.Models
{
    public class CreateProductDTO
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool IsInStock { get; set; }
        public int categoryId { get; set; }
    }
}
