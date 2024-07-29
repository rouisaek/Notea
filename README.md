# Notea

Notea is a note-taking application designed to help users efficiently manage and organize their notes. This README file provides instructions on setting up and running the application.

## Prerequisites

Before you begin, ensure you have met the following requirements:

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine (version 8.0 or higher recommended)
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) for a better development experience
- [SQL Server](https://www.microsoft.com/en-us/sql-server) database for data storage

## Setup

1. **Clone the repository:**

   `git clone https://github.com/yourusername/notea.git
cd notea`

2. **Configure the database:**

   Update the `appsettings.json` file with your database connection string:

   ```json
   {
     "ConnectionStrings": {
       "DevelopmentConnection": "YourConnectionStringHere"
     }
   }
   ```

3. **Restore dependencies:**

   `dotnet restore`

4. **Apply migrations (if applicable):**

   If your project uses Entity Framework Core for database management, apply migrations to set up the database schema:

   `dotnet ef database update`

## Running the Application

1. **Build the application:**

   `dotnet build`

2. **Run the application:**

   `dotnet run`

   The application will be available at `https://localhost:7255` (or another port if configured).

## Additional Resources

- [Official .NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [Entity Framework Core Documentation](https://docs.microsoft.com/en-us/ef/core/)

## License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/rouisaek/Notea/blob/master/LICENSE.txt) file for details.

## Contact

If you have any questions or suggestions, feel free to reach out!

- **Author:** Rouis Abdelkader
- **Email:** abdelkaderrouis22@gmail.com
