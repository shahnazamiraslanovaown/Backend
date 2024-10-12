namespace Backend1.Models
{
    public class GetProductDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public bool IsInStock { get; set; }
        public int categoryId { get; set; }
    }
}
