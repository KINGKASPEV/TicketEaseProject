# TicketEase Project

TicketEase is a .NET 6 application designed to manage tickets and provide various services related to managing task activities. This project is organized into several distinct components, each serving a specific purpose within the application's architecture.

## Project Structure

### TicketEase
- **Controllers:** Contains the controllers responsible for handling various HTTP requests and responses.
- **Mapper:** Includes AutoMapper profiles for mapping between different data transfer objects (DTOs) and domain entities.
- **Configuration:** Contains extension methods for Swagger, IdentityService, MailService, LogSettings, and other configurations.
- **ConfigurationSetupExtension:** Extension methods for setting up and configuring the application.
- **AuthenticationServiceExtension:** Extensions related to the authentication service setup.

### TicketEase.Application
- **DTO:** Data transfer objects used for transferring data between layers.
- **Validators:** Validation logic for DTOs and other input data.
- **Interfaces:** Includes interfaces for repositories and services, defining contracts for the application.
- **ServiceImplementation:** Contains implementations for various services used within the application.

### TicketEase.Common
- **Utilities:** Helper classes such as Pagination and DateTime Formatter that are shared across different parts of the application.

### TicketEase.Domain
- **Entities:** Domain entities representing the core business objects within the application.
- **Enums:** Enumerations used within the domain.

### TicketEase.Persistence
- **Contexts:** Contains the DbContext class, which represents the database context for the application.
- **Repositories:** Includes all repositories responsible for data access and manipulation.
- **Extensions:** Database configurations and dependency injection registrations.
