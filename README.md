**microIMDB**

**Description:**

microIMDB is a .NET Core 6+ Web API project that enables registered users to login, view movies, and rate movies. Admin users have additional privileges such as adding, editing, and soft deleting movies. The project implements various design patterns and principles for a scalable and maintainable solution.

**Features:**

- User authentication with JWT Token
- Role-based authorization (User, Admin)
- CRUD operations for movies (Admin)
- Movie rating system (User)
- N-Tiers Architectural Pattern
- Repository Design Pattern
- Dependency Injection Design Pattern
- Singleton Design Pattern
- ASP.NET Identity User
- Default admin user setup during API startup
- Swagger API documentation support
- Application of SOLID principles

**API Endpoints:**

- **Authentication:**
  - `POST /api/auth/login` - Login and receive JWT token
  - `POST /api/auth/register` - Register a new user

- **Movies:**
  - `GET /api/movies` - Get all movies
  - `GET /api/movies/{id}` - Get a specific movie by ID
  - `POST /api/movies` - Add a new movie (Admin only)
  - `PUT /api/movies/{id}` - Update a movie (Admin only)
  - `DELETE /api/movies/{id}` - Soft delete a movie (Admin only)

- **Ratings:**
  - `POST /api/ratings` - Rate a movie (User only)

**Getting Started:**

1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```

2. Install .NET Core SDK 6+ if not already installed.

3. Configure the database connection string in `appsettings.json`.

4. Run the following commands to apply database migrations:
   ```bash
   cd microIMDB
   dotnet ef database update
   ```

5. Build and run the project:
   ```bash
   dotnet build
   dotnet run
   ```

6. Access Swagger UI to explore and test API endpoints:
   ```
   https://localhost:<port>/swagger
   ```

7. Use the provided default admin user credentials to log in as an admin.

**Usage:**

- Use the provided default admin user credentials to log in as an admin.
- Explore Swagger UI to view available endpoints and perform actions.

**Contributing:**

Contributions are welcome! Please follow these steps:

1. Fork the repository.
2. Create your feature branch: `git checkout -b feature/new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin feature/new-feature`
5. Submit a pull request.

**Acknowledgments:**

Thank you to all the contributors who helped make this project better.

**Contact:**

For any inquiries or feedback, please contact me at rewanabdelqader@gmail.com.

**Enjoy!**
