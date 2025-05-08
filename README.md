# Entity Course UDE

This is a .NET MVC project designed for managing courses and entities. It uses ASP.NET Core MVC and Entity Framework Core.

## Features

- MVC architecture
- Entity Framework Core for database management
- Razor views for dynamic HTML rendering
- Bootstrap for responsive design
- Validation using jQuery plugins

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 9.0 or higher)
- SQL Server or any compatible database
- Node.js (optional, for managing frontend dependencies)

## Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/your-repo/entity-course-ude.git
   cd entity-course-ude
   ```
2. Restore dependencies:

   ```bash
   dotnet restore
   ```
3. Update the database:

   ```bash
   dotnet ef database update
   ```
4. Run the application:

   ```bash
   dotnet run
   ```
5. Open your browser and navigate to `http://localhost:5000`.

## Basic Concepts Applied

This project implements several key concepts of ASP.NET Core and Entity Framework Core:

1. **Entity Framework Core ORM**
   - Code-first approach with migrations
   - DbContext configuration and dependency injection
   - Entity relationships (one-to-many, many-to-many)

2. **Data Modeling**
   - Model classes with data annotations
   - Fluent API for advanced configurations
   - Composite keys (as seen in ProductTag entity)
   - Custom column names and types

3. **Database Operations**
   - CRUD operations for entities
   - Data seeding
   - Query optimization

4. **MVC Architecture**
   - Separation of concerns with Models, Views, and Controllers
   - Strongly-typed views with Razor syntax
   - Form handling and validation

5. **Relationship Management**
   - Navigation properties
   - Foreign keys
   - Cascade deletes

6. **View Features**
   - Tag helpers (asp-for, asp-action, etc.)
   - Model binding
   - Form validation using data annotations

7. **Best Practices**
   - Repository pattern
   - Service layer implementation
   - Input validation and error handling

## Advanced Concepts Applied

This project also implements several advanced concepts:

1. **Fluent API Configuration**
   - Complex relationship mapping beyond data annotations
   - Custom entity configurations in OnModelCreating
   - Table and column name customization (e.g., "Tbl_Product", "Product_Name")

2. **Advanced Entity Relationships**
   - Many-to-many relationships with join entities (ProductTag)
   - Composite keys implementation
   - Custom cascade delete behaviors

3. **Advanced Data Operations**
   - Bulk delete operations (Delete2Categories, Delete5Categories)
   - Batch processing of multiple entities
   - Transactional operations

4. **Custom Model Binding**
   - Complex model binding scenarios
   - Handling nested object structures
   - Binding collections in forms

5. **Query Optimization Techniques**
   - Eager loading with Include and ThenInclude
   - Projection queries with Select
   - Deferred execution with IQueryable

6. **Migration Management**
   - Incremental database schema changes
   - Migration scripting and versioning
   - Data preservation during schema changes

7. **Advanced View Components**
   - Partial views for reusable UI components
   - ViewComponent implementation
   - Dynamic content rendering

8. **Data Seeding Strategies**
   - Initial data population through migrations
   - Environment-specific seeding
   - Test data generation

9. **Performance Optimization**
   - Query optimization techniques
   - Database indexing strategies
   - Second-level caching implementation

## Project Structure

- **Controllers**: Handles HTTP requests and responses.
- **Models**: Represents the data and business logic.
- **Views**: Contains Razor files for rendering HTML.
- **wwwroot**: Static files like CSS, JS, and images.
