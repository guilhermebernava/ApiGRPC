# Basic gRPC API and Console Client in .NET 6

This repository contains a simple gRPC API and a console client built with .NET 6. The API allows you to retrieve product information by ID or get a list of all products. The console client interacts with this API.

## Getting Started

### Prerequisites

Before you can run the API and console client, ensure that you have the following prerequisites installed on your system:

- .NET 6 SDK: [Download .NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)
- Protocol Buffers (protoc): [Download Protobuf](https://developers.google.com/protocol-buffers/docs/downloads)

### Installation

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/guilhermebernava/ApiGRPC.git
   ```

2. Navigate to the project directory:

   ```bash
   cd ApiGRPC
   ```

3. Build the project:

   ```bash
   dotnet build
   ```

## Running the API

To run the gRPC API, execute the following command:

```bash
dotnet run --project Api
```

The API will start and listen on `https://localhost:5001` by default. You can change the URL and port in the `appsettings.json` file within the `Api` project.

## Running the Console Client

To run the console client, execute the following commands:

```bash
cd ConsoleClient
dotnet build
dotnet run
```

The console client will start and interact with the API.

## Interacting with the API

The API provides two main endpoints:

### Get Product by ID

To retrieve a product by ID, you can make a gRPC request using your preferred gRPC client or the provided console client. Here's an example using the console client:

```bash
1. Select option 1 for "Get Product by ID."
2. Enter the product ID when prompted.
```

### Get All Products

To retrieve a list of all products, follow these steps:

```bash
1. Select option 2 for "Get All Products."
```

The console client will make a gRPC request to the API, and the product information will be displayed.

---
