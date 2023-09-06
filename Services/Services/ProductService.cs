using Grpc.Core;
using ProductServices;

namespace Api.Services;

public class ProductServices : Product.ProductBase
{

    public override Task<ProductResponse> GetProduct(ProductRequest request, ServerCallContext context)
    {
        var product = new ProductResponse { Id = request.Id, Name = "Product", Price = 15.43f };
        return Task.FromResult(product);
    }

    public override Task<ProductList> GetProducts(Empty request, ServerCallContext context)
    {
        var products = Enumerable.Range(1, 39)
            .Select(i => new ProductResponse
            {
                Id = i,
                Name = $"Product - {i}",
                Price = 15.43f * i
            })
            .ToList();

        return Task.FromResult(new ProductList { Products = { products } });
    }
}
