# Stock and buy
Task description: [Task](https://www.loom.com/share/a7e55a5e5b9043eb939c43092b462959?sid=960583b9-f413-43ae-8a6e-1f6fc67de958)

## Table of contents
1. [Installation and Launch Instructions](#installation-and-launch-instructions)
2. [Application architecture](#application-architecture)
3. [Database diagram](#database-diagram)
4. [Api docs](#api-docs)

## Installation and Launch Instructions

To get started with the application, follow these steps:

1. **Clone the Repository**: 
   Begin by cloning the repository to your local machine.
2. **Database Setup**:
   - The application uses MSSQL as its database.
   - You have two options for setting up MSSQL:
     - **Local Installation**: Ensure MSSQL is installed on your device.
     - **Docker**: Alternatively, you can run MSSQL in a Docker container.
   - Upon the first launch of the application, a new empty database will be automatically created.
3. **Start the API**:
     1. Start project *StockAndBuyTestApp.Api* from IDE
     2. Enter ``` dotnet run StockAndBuyTestApp.Api``` in StockAndBuyTestApp.Api folder from PowerShell
  

## Application Architecture
The application is designed in accordance with a DDD, Clean Architecture and CQRS was also used.

## Database Diagram

In this project, I employed a Code First approach to align DDD entities with the database schema, ensuring cohesion between domain models and the database structure.

### Database Structure Highlights:

- **"Bundles" Aggregate Context**: Central to the design, it encapsulates related entities and business logic.

- **Relationship Tables**: `BundleToProductRelationshipIds` and `BundleToBundleRelationshipIds` within the "Bundles" context manage relationships without direct `DbContext` manipulation.

- **Entity-to-Database Mappings**: Configuration files are used for precise mapping between domain entities and database tables. These configurations dictate relationships and constraints, accurately reflecting the domain in the database. For more details, see the [Configuration Files](https://github.com/dima-ma/StockAndBuyTestApp/tree/master/StockAndBuyTestApp.Infrastructure/Persistance/Configurations).

This architecture combines DDD principles with practical database design, facilitating adaptability and future growth.

![image](https://github.com/dima-ma/StockAndBuyTestApp/assets/124355677/98f4b2fd-a6bc-4ed5-98cc-aad77e25fd06)

## API Documentation

This section provides an overview of the various endpoints available in the API, you can see a clearer description in Swagger.

1. **Product Endpoints**:
    - **Create New Product**: Add a new product to the system.
    - **List All Products**: Retrieve a list of all available products.

2. **Stock Endpoints**:
    - **Create New Stock Record**: Record new stock for a specific product.
    - **List All Stock Records**: Access a comprehensive list of all stock records.

3. **Bundle Endpoints**:
    - **Create New Empty Bundle**: Initiate a new bundle without any products.
    - **List All Bundles**: View all existing bundles.
    - **Get Bundle by ID**: Fetch detailed information about a specific bundle, including all associated products and nested bundles.
    - **Attach Product to Bundle**: Add a product to an existing bundle.
    - **Attach Bundle to Bundle**: Link one bundle to another as a nested bundle.
    - **Calculate Max Bundle Quantity**: Determine the maximum number of a specific bundle that can be assembled based on the current stock of its components and nested bundles. 
