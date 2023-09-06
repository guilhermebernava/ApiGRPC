using Grpc.Net.Client;
using ProductServices;


var channel = GrpcChannel.ForAddress("https://localhost:5001");

while (true)
{
    PrintMenu();
    if (int.TryParse(Console.ReadLine(), out int choice))
    {
        switch (choice)
        {
            case 1:
                await GetProductAsync(channel);
                break;

            case 2:
                await GetProductsAsync(channel);
                break;

            case 3:
                await ShutdownAndExitAsync(channel);
                return;

            default:
                Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid choice (1, 2, or 3).");
    }

    Console.WriteLine();
}


static void PrintMenu()
{
    Console.WriteLine("Select an option:");
    Console.WriteLine("1. Get Product by ID");
    Console.WriteLine("2. Get All Products");
    Console.WriteLine("3. Exit");
    Console.Write("Enter your choice (1/2/3): ");
}

static async Task GetProductAsync(GrpcChannel channel)
{
    Console.Write("Enter product ID: ");
    if (int.TryParse(Console.ReadLine(), out int productId))
    {
        var client = new Product.ProductClient(channel);
        var productRequest = new ProductRequest { Id = productId };
        var productResponse = await client.GetProductAsync(productRequest);
        Console.WriteLine($"Product - Id: {productResponse.Id}, Name: {productResponse.Name}, Price: {productResponse.Price}");
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter a valid integer for product ID.");
    }
}

static async Task GetProductsAsync(GrpcChannel channel)
{
    var client = new Product.ProductClient(channel);
    var emptyRequest = new Empty();
    var productListResponse = await client.GetProductsAsync(emptyRequest);
    foreach (var product in productListResponse.Products)
    {
        Console.WriteLine($"Product - Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
    }
}

static async Task ShutdownAndExitAsync(GrpcChannel channel)
{
    await channel.ShutdownAsync();
    Environment.Exit(0);
}

