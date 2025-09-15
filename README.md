# XenoTerra_API — Modular, High-Performance GraphQL Backend for Modern Applications

## Project Overview

This project focuses on designing a **fully functional and performant GraphQL API** that mirrors the behavior of a real-world social media backend. The implementation includes:

- A modular structure based on clean architecture principles
- Full CRUD support with modular and dynamic GraphQL query construction
- Real-time event delivery via subscriptions
- Dynamic filtering, sorting, and pagination logic
- Custom projection and expression building
- Centralized error management and type-safe responses
- Developer-friendly abstractions and reusable patterns that enable flexible query composition without backend modification

This project showcases a well-architected, scalable GraphQL backend solution that aligns with modern development standards and real-world application needs.

## Installation

Clone the repository and install required packages including `EntityFramework` and `HotChocolate`. Once dependencies are installed, your API is ready to run.

---

## Features

### General Architecture

- The project is built using a layered (n-tier) architecture.  
- Each layer is responsible only for its own task and aims to perform it in the most efficient manner.
- The application receives a GraphQL schema input, which is processed through each layer to produce the corresponding output.

---

## Technical Highlights

### GraphQL-Based API

- The core of this project is based on GraphQL using **HotChocolate**.
- The goal was to build a robust API that supports **queries**, **mutations**, and **subscriptions** effectively.
- GraphQL features such as **pagination**, **filtering**, **sorting**, **input validation**, **payload handling**, **event systems**, **custom resolvers**, **DataLoader integration**, **attribute-based configurations**, and **middleware extensions** are all implemented and extended for enhanced flexibility, performance, and developer experience.

---

### Query

- Each query is dynamically built based on the fields requested in the schema to optimize database access.
- Centralized error handling is used; GraphQL exceptions are thrown appropriately.
- The results are mapped to DTOs. Collections are returned in a `Connection` object, while single entities are returned directly.

---

### Projection

- Only the requested fields are fetched from the database by building expression trees at runtime.
- Custom logic allows fetching nested relational entities **only with the selected fields**.
- This approach ensures maximum performance **without sacrificing functionality**.

---

### Pagination

- All queries returning collections use a custom `Connection` class that handles pagination.
- The `totalCount` field is queried **only if explicitly selected** in the schema, avoiding unnecessary database calls.

---

### Sorting

- Sorting can be defined using the `order` parameter in the schema.
- It supports sorting by any field of the entity, including nested fields.
- Sorting expressions are generated dynamically and inserted in the query pipeline with `ASC` or `DESC` options.

---

### Filtering

- Filtering is defined using the `where` parameter in GraphQL.
- Logical conditions (e.g., `AND`, `OR`) and a variety of operators can be applied to entity fields or related entity fields.
- Filter expressions are injected dynamically into the query.

---

### Custom Enhancements Over HotChocolate

> The above capabilities are **heavily enhanced** with custom logic.  
> Instead of replacing all built-in features, HotChocolate's core mechanisms were extended where beneficial.

- These enhancements offer **greater flexibility and better performance** than the default GraphQL setup.
- The result is a reusable and adaptable GraphQL API model that minimizes the need for frontend developers to request backend changes.

---

## Mutation

- Mutations accept custom inputs structured according to GraphQL best practices.
- Only GraphQL-supported types are allowed, and inputs are converted to correct internal types before being mapped to DTOs.
- Error handling is performed, and results are returned via customizable payloads instead of throwing direct errors.
- Payloads can be customized per entity.

---

## Subscription

- Subscription methods are implemented to observe specific entity events.
- Events are dispatched with customizable payloads according to the use case.

---

## Additional Features

### GraphQL-Specific Enhancements

- **DataLoader**: To eliminate N+1 problems, `DataLoader` is used. Custom logic ensures only selected fields are retrieved.
- **Attributes**: Custom attributes are defined and applied throughout the codebase for added control and modularity.
- **Middlewares**: Custom middlewares are introduced to handle cross-cutting concerns cleanly and effectively.
- **Resolvers**: Queries are resolved through structured resolvers, ensuring layered validation and transformation.

### Code Quality & Architecture

- **Data Security**: Thanks to Admin and User-based DTOs, data exposure is minimized and security is enforced at the highest level.
- **Strong Type Support**: Each major structure has a dedicated and extensible type.
- **Clean Code**: The codebase is written with readability and maintainability in mind.
- **Organized Folder Structure**: Each module is clearly separated to simplify navigation and maintenance.
- **Proper Naming Conventions**: Consistent and descriptive naming helps minimize confusion and improves clarity.


## Technologies Used

- **.NET Core 8.0**
- **C#**
- **Entity Framework Core**
- **GraphQL (HotChocolate)**
- **MSSQL**
- **DataLoader (GreenDonut)**

---
## Contributions

This project allowed me to dive deep into advanced GraphQL architecture and explore the inner workings of the HotChocolate framework. In many areas, the built-in capabilities of HotChocolate fell short of my specific needs, which led me to implement several modules manually.

Throughout development, I rewrote large portions of the code multiple times, experimenting with different patterns to strike the right balance between functionality, performance, and code clarity. Some designs delivered excellent results but introduced unnecessary complexity, which pushed me to simplify the design while preserving extensibility. In certain areas, I consciously sacrificed some performance in favor of maintainability and cleaner abstractions.

Ultimately, this journey not only helped me build a powerful and extensible API, but also led to the creation of a personal standard that I plan to apply across future projects.

