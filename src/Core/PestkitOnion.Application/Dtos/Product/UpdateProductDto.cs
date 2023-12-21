namespace PestkitOnion.Application.Dtos.Product
{
    public record UpdateProductDto(string name, decimal price, string sku, string? description);
}
