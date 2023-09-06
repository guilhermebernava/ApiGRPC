var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();
var app = builder.Build();

app.MapGrpcService<Api.Services.ProductServices>();
app.MapGet("/", () => "Basic API using gRPC for get products");
app.Run();
