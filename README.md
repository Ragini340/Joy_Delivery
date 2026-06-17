# JOY Delivery

A hyperlocal grocery and food delivery platform built using ASP.NET Core Web API.

## Overview

JOY Delivery is designed to help customers order groceries and food from nearby stores and restaurants quickly and conveniently.

The platform focuses on:

* Fast delivery
* Easy ordering experience
* Reliable local vendors
* Better customer satisfaction
* Simple and maintainable architecture

---

## Features

### View Cart

Retrieve the current cart for a user.

```http
GET /Cart/view?userId=user101
```

---

### Add Product To Cart

Add a grocery product to a user's cart.

```http
POST /Cart/product
```

Request:

```json
{
  "userId": "user101",
  "productId": "product101",
  "outletId": "store101"
}
```

---

### Search Grocery Products

Search grocery products by name.

```http
GET /Product/search?name=Bread
```

Example Response:

```json
[
  {
    "id": "product101",
    "name": "Wheat Bread",
    "maxRecommendedPrice": 10.5
  }
]
```

---

## Project Structure

```text
Joy_Delivery
│
├── Controllers
│   ├── CartController.cs
│   └── ProductController.cs
│
├── Services
│   ├── CartService.cs
│   ├── ProductService.cs
│   └── UserService.cs
│
├── Models
│   ├── Cart.cs
│   ├── Product.cs
│   ├── GroceryProduct.cs
│   ├── GroceryStore.cs
│   ├── Outlet.cs
│   └── User.cs
│
├── Dtos
│   ├── AddProductRequest.cs
│   └── CartProductInfo.cs
│
├── Seed
│   └── SeedData.cs
│
└── Program.cs
```

---

## Architecture

The project follows a layered architecture.

```text
Controller Layer
       ↓
Service Layer
       ↓
Models / DTOs
       ↓
Seed Data
```

### Controller Layer

Responsible for:

* Receiving HTTP requests
* Returning HTTP responses
* Delegating work to services

### Service Layer

Responsible for:

* Business logic
* Validation
* Product retrieval
* Cart management

### Models and DTOs

Responsible for:

* Data representation
* Request and response contracts

---

## API Endpoints

| Method | Endpoint        | Description             |
| ------ | --------------- | ----------------------- |
| GET    | /Cart/view      | View user cart          |
| POST   | /Cart/product   | Add product to cart     |
| GET    | /Product/search | Search products by name |

---

## Sample Data

### Users

| UserId  | First Name | Last Name |
| ------- | ---------- | --------- |
| user101 | John       | Doe       |

---

### Stores

| StoreId  | Store Name     |
| -------- | -------------- |
| store101 | Fresh Picks    |
| store102 | Natural Choice |

---

### Products

| ProductId  | Product Name | Store    |
| ---------- | ------------ | -------- |
| product101 | Wheat Bread  | store101 |
| product102 | Spinach      | store101 |
| product103 | Crackers     | store101 |

---

## Running the Application

### Prerequisites

* .NET 8 SDK (or project target version)
* Visual Studio 2022 / VS Code

### Restore Packages

```bash
dotnet restore
```

### Build Project

```bash
dotnet build
```

### Run Application

```bash
dotnet run
```

---

## Running Unit Tests

Execute all MSTest unit tests:

```bash
dotnet test
```

---

## Test Coverage

### CartService Tests

* Add product successfully
* Retrieve cart
* Invalid user validation
* Invalid product validation
* Invalid cart validation

### ProductService Tests

* Valid product retrieval
* Invalid product retrieval
* Invalid outlet retrieval
* Product search by name
* Empty search result

### ProductController Tests

* Search endpoint returns HTTP 200
* Search endpoint returns products
* Search endpoint returns empty list
* Case-insensitive search validation

### UserService Tests

* Existing user lookup
* Invalid user lookup

---

## Error Handling

The application provides meaningful validation errors.

Examples:

```text
User not found.
Product not found.
Cart not found.
```

---

## Development Approach

This project follows Test Driven Development (TDD).

### TDD Cycle

```text
Red → Green → Refactor
```

1. Write failing tests.
2. Implement minimum code.
3. Refactor while keeping tests green.

Benefits:

* Improved code quality
* Better maintainability
* Reduced defects
* Safer refactoring

---

## Future Enhancements

* Product pagination
* Product filtering
* Authentication and Authorization
* Order placement
* Real-time delivery tracking
* Payment integration
* Inventory management
* Database persistence using Entity Framework Core
