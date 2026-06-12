# Joy Delivery – Project Explanation

## Project Overview

**Welcome to JOI Delivery**

JOI Delivery is a hyperlocal food and grocery delivery platform designed for real-life needs. It helps customers get food and essentials delivered quickly, conveniently, and reliably.

The platform is built around everyday situations — a working professional returning home late, a student needing groceries before an exam, or anyone who needs essential items without spending time shopping.

JOI Delivery brings food and groceries to customers’ doors through a seamless digital experience.

The application focuses on:

* Fast delivery
* Fresh products
* Easy ordering experience
* Reliable local vendors
* Better customer satisfaction

## Problem Statement

Customers commonly face challenges such as:

* Difficult product discovery and browsing
* Limited customization options
* Unclear order tracking and delivery updates
* Payment failures during checkout
* Lack of proper feedback channels

JOI Delivery addresses these problems by providing a technology-first delivery platform connecting customers with nearby stores and restaurants.

---

# Business Vision

JOI Delivery aims to:

* Provide unmatched customer experience
* Improve delivery efficiency
* Build a strong partner ecosystem
* Scale delivery operations across neighborhoods

The platform is designed to support increasing customer demand, smarter logistics, and reliable order processing.

---

# Application Overview

**Technology Stack**

* Backend: ASP.NET Core Web API
* Language: C#
* Testing: MSTest
* BDD: SpecFlow + Gherkin
* Architecture: Layered Architecture

---

# Core Features Implemented

## Customer Features

### 1. View Cart

Users can view their existing cart.

Example:

```
GET /Cart/view?userId=user101
```

The API returns:

* Cart details
* Outlet information
* Products added

### 2. Add Product To Cart

Users can add grocery products from a specific store.

Example request:

```json
{
  "userId": "user101",
  "productId": "product101",
  "outletId": "store101"
}
```

The system:

1. Validates user
2. Finds user cart
3. Validates product
4. Adds product
5. Returns updated cart information

---

# Architecture Explanation

The project follows layered architecture.

## Controller Layer

Responsible for handling API requests.

Example:

CartController

Endpoints:

```
POST /Cart/product

GET /Cart/view
```

Responsibilities:

* Accept client request
* Call service layer
* Return HTTP response

---

## Service Layer

Contains business logic.

### CartService

Responsibilities:

* Manage cart operations
* Validate users
* Validate products
* Add products into cart

Example validation:

```csharp
if(user is null)
{
    throw new InvalidOperationException("User not found.");
}

if(product is null)
{
    throw new InvalidOperationException("Product not found.");
}
```

---

## ProductService

Responsible for retrieving products.

Example:

```csharp
GetProduct(productId, outletId)
```

It verifies that the product belongs to the requested outlet.

---

## UserService

Responsible for user lookup.

Example:

```csharp
FetchUserById(userId)
```

---

# Sample Data

## Users

| UserId  | First Name | Last Name |
| ------- | ---------- | --------- |
| user101 | John       | Doe       |

## Stores

| StoreId  | Store Name     |
| -------- | -------------- |
| store101 | Fresh Picks    |
| store102 | Natural Choice |

## Products

| ProductId  | Product Name | Store    |
| ---------- | ------------ | -------- |
| product101 | Wheat Bread  | store101 |
| product102 | Spinach      | store101 |
| product103 | Crackers     | store101 |

---

# TDD Approach

I followed Test Driven Development.

TDD cycle:

```
Red → Green → Refactor
```

## 1. Red Phase

First I created test cases before implementing functionality.

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

Implemented minimum code required.

Example:

```csharp
cart.Products.Add(product);

return new CartProductInfo(
    cart,
    product,
    product.SellingPrice);
```

The test started passing.

---

## 3. Refactor Phase

Improved the implementation.

Added validations:

```csharp
if(user is null)
{
    throw new InvalidOperationException();
}
```

Benefits:

* Better error handling
* Cleaner code
* Easier maintenance

---

# MSTest Coverage

Created unit tests for:

## CartService Tests

Covered:

* Add product successfully
* Invalid user
* Invalid product
* View cart
* Selling price validation

## ProductService Tests

Covered:

* Existing product retrieval
* Invalid product
* Invalid outlet

## UserService Tests

Covered:

* Existing user lookup
* Invalid user

## Controller Tests

Covered:

* API response status
* Returned objects
* Cart endpoints

Example:

```csharp
Assert.IsInstanceOfType(
result,
typeof(OkObjectResult));
```

---

# BDD Approach (SpecFlow)

For business behavior validation, I implemented BDD using SpecFlow.

BDD follows:

```
Given → When → Then
```

Example:

```gherkin
Scenario: Add product to cart successfully

Given a user with id "user101" exists

And a product with id "product101" exists

When the user adds the product to the cart

Then the product should be added
```

BDD benefits:

* Business readable tests
* Better collaboration
* Validates real user scenarios

---

# Error Handling Improvements

Initially invalid data could cause runtime exceptions.

Improved behavior:

Before:

```
NullReferenceException
```

After:

```
User not found
Product not found
Cart not found
```

This makes the API predictable and production friendly.

---

# My Contribution

I worked on:

* Designing REST APIs
* Implementing cart management
* Creating service layer logic
* Adding validation
* Writing MSTest unit tests
* Creating SpecFlow BDD scenarios
* Following TDD methodology
* Improving maintainability and error handling

---

# Short Interview Summary

"Joy Delivery is a grocery and food delivery Web API built using ASP.NET Core. I implemented cart management functionality where users can add products and view carts. The application follows layered architecture with Controllers, Services, DTOs, and Models. I followed TDD by writing MSTest cases first, implementing functionality, and then refactoring. I also created BDD scenarios using SpecFlow and Gherkin to validate business workflows. The focus was clean architecture, reliable APIs, and maintainable code."
