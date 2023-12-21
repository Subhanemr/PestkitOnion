namespace PestkitOnion.Application.Dtos.Product
{
    public record CreateProductDto(string name, decimal price, string sku, string? description);
}
