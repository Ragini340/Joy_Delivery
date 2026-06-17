## Project Overview

### Welcome to JOY Delivery

JOY Delivery is a hyperlocal food and grocery delivery platform designed for real-life needs. It helps customers get food and essentials delivered quickly, conveniently, and reliably.

The platform is built around everyday situations — a working professional returning home late, a student needing groceries before an exam, or anyone who needs essential items without spending time shopping.

JOY Delivery brings food and groceries to customers’ doors through a seamless digital experience.

The application focuses on:

* Fast delivery
* Fresh products
* Easy ordering experience
* Reliable local vendors
* Better customer satisfaction

---

## Problem Statement

Customers commonly face challenges such as:

* Difficult product discovery and browsing
* Limited customization options
* Unclear order tracking and delivery updates
* Payment failures during checkout
* Lack of proper feedback channels

JOY Delivery addresses these problems by providing a technology-first delivery platform connecting customers with nearby stores and restaurants.

---

# Business Vision

JOY Delivery aims to:

* Provide unmatched customer experience
* Improve delivery efficiency
* Build a strong partner ecosystem
* Scale delivery operations across neighborhoods

The platform is designed to support increasing customer demand, smarter logistics, and reliable order processing.

---

# Application Overview

## Technology Stack

* Backend: ASP.NET Core Web API
* Language: C#
* Testing: MSTest
* Architecture: Layered Architecture

---

# Core Features Implemented

## 1. View Cart

Users can view their existing cart.

### Example Request

```http
GET /Cart/view?userId=user101
```

### Response

The API returns:

* Cart details
* Outlet information
* Products added

---

## 2. Add Product To Cart

Users can add grocery products from a specific store.

### Example Request

```http
POST /Cart/product
```

```json
{
  "userId": "user101",
  "productId": "product101",
  "outletId": "store101"
}
```

### Flow

The system:

1. Validates user
2. Finds user cart
3. Validates product
4. Adds product to cart
5. Returns updated cart information

---

## 3. Search Grocery Products By Name

Users can search grocery products using a complete or partial product name.

### Example Request

```http
GET /Product/search?name=Bread
```

### Example Response

```json
[
  {
    "id": "product101",
    "name": "Wheat Bread",
    "maxRecommendedPrice": 10.5
  }
]
```

### Flow

The system:

1. Accepts a product name
2. Searches inventory using a case-insensitive comparison
3. Finds matching products
4. Returns all matching products

### Status Codes

| Status Code               | Description                            |
| ------------------------- | -------------------------------------- |
| 200 OK                    | Products found or no matching products |
| 400 Bad Request           | Invalid or empty search text           |
| 500 Internal Server Error | Unexpected server error                |

---

# Architecture Explanation

The project follows a layered architecture pattern.

```text
Controller Layer
       ↓
Service Layer
       ↓
Models / DTOs
       ↓
Seed Data
```

---

# Controller Layer

Responsible for handling API requests and responses.

## CartController

### Endpoints

```http
POST /Cart/product

GET /Cart/view
```

### Responsibilities

* Accept client requests
* Call service layer
* Return HTTP responses

---

## ProductController

### Endpoint

```http
GET /Product/search?name={productName}
```

### Example

```http
GET /Product/search?name=Bread
```

### Responsibilities

* Search grocery products by name
* Support partial search
* Support case-insensitive search
* Return matching products
* Return appropriate HTTP status codes

---

# Service Layer

Contains the core business logic of the application.

---

## CartService

### Responsibilities

* Manage cart operations
* Validate users
* Validate carts
* Validate products
* Add products into cart

### Validation Logic

```csharp
if (user is null)
{
    throw new InvalidOperationException("User not found.");
}

if (cart is null)
{
    throw new InvalidOperationException("Cart not found.");
}

if (product is null)
{
    throw new InvalidOperationException("Product not found.");
}
```

### Add Product Flow

```csharp
cart.Products.Add(product);

return new CartProductInfo(
    cart,
    product,
    product.SellingPrice);
```

---

## ProductService

Responsible for product retrieval and search operations.

### Get Product

```csharp
GetProduct(productId, outletId)
```

Purpose:

* Retrieve product by ID
* Verify outlet ownership

### Search Products

```csharp
SearchProductsByName(productName)
```

Example:

```csharp
var products =
    productService.SearchProductsByName("Bread");
```

Responsibilities:

* Search grocery products by name
* Support partial matching
* Support case-insensitive search
* Return matching inventory products

---

## UserService

Responsible for user lookup operations.

### Example

```csharp
FetchUserById(userId)
```

Responsibilities:

* Retrieve users
* Validate user existence

---

# Sample Data

## Users

| UserId  | First Name | Last Name |
| ------- | ---------- | --------- |
| user101 | John       | Doe       |

---

## Stores

| StoreId  | Store Name     |
| -------- | -------------- |
| store101 | Fresh Picks    |
| store102 | Natural Choice |

---

## Products

| ProductId  | Product Name | Store    |
| ---------- | ------------ | -------- |
| product101 | Wheat Bread  | store101 |
| product102 | Spinach      | store101 |
| product103 | Crackers     | store101 |

---

# TDD Approach

I followed Test Driven Development (TDD).

## TDD Cycle

```text
Red → Green → Refactor
```

---

## 1. Red Phase

Created tests before implementing functionality.

Example:

```csharp
[TestMethod]
public void AddProductToCart_ValidRequest_AddsProduct()
{
    var result =
        cartService.AddProductToCartForUser(request);

    Assert.IsNotNull(result);
}
```

Initially the test failed.

---

## 2. Green Phase

Implemented the minimum code required to pass the test.

Example:

```csharp
cart.Products.Add(product);

return new CartProductInfo(
    cart,
    product,
    product.SellingPrice);
```

The test passed.

---

## 3. Refactor Phase

Improved code quality.

Added validations:

```csharp
if (user is null)
{
    throw new InvalidOperationException();
}
```

### Benefits

* Better error handling
* Cleaner code
* Improved maintainability
* Easier debugging

---

# MSTest Coverage

Created unit tests for all major components.

## CartService Tests

Covered:

* Add product successfully
* Retrieve existing cart
* Invalid user
* Invalid product
* Invalid cart
* Selling price validation

---

## ProductService Tests

Covered:

* Existing product retrieval
* Invalid product
* Invalid outlet
* Search product by name
* Search using partial product name
* Search with no matching products

Example:

```csharp
[TestMethod]
public void SearchProductsByName_ExistingName_ReturnsProducts()
{
    var result =
        service.SearchProductsByName("Bread");

    Assert.AreEqual(1, result.Count);
}
```

---

## UserService Tests

Covered:

* Existing user lookup
* Invalid user lookup

---

## Controller Tests

Covered:

* HTTP response validation
* Successful requests
* Response object verification
* Cart endpoints
* Product search endpoint

Example:

```csharp
Assert.IsInstanceOfType(
    result,
    typeof(OkObjectResult));
```

---

# Error Handling Improvements

Initially invalid data could cause runtime exceptions.

### Before

```text
NullReferenceException
```

### After

```text
User not found
Product not found
Cart not found
```

This makes the API predictable, maintainable, and production-friendly.

---