namespace PestkitOnion.Domain.Entities
{
    public class Product:BaseNameEntity
    {
        public decimal Price { get; set; }
        public string SKU { get; set; } = null!;
        public string? Description { get; set; }
    }
}
