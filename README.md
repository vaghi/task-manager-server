# Task Manager Backend

A RESTful API built with ASP.NET Core Web API for managing tasks.

## How to Run

1.  **Prerequisites**: Ensure you have the .NET 10.0 SDK installed.
2.  **Restore & Run**:
    ```bash
    dotnet restore
    dotnet run
    ```
3.  **Access**: The API will start on `http://localhost:5000`.

## Design Decisions

- **Architecture**: Clean separation of concerns (Controller -> Service -> Model).
- **Persistence**: In-memory `ConcurrentDictionary` used for thread-safe storage without a database.
- **CORS**: Enabled for `http://localhost:5173` to allow frontend integration.
- **Simplicity**: Focused on meeting requirements with minimal boilerplate (e.g., no unnecessary interfaces or layers beyond what's needed for testing/separation).
