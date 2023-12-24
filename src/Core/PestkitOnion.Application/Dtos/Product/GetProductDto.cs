namespace PestkitOnion.Application.Dtos.Product
{
    public record GetProductDto(int id, string name, decimal price, string sku, string? description);
}
