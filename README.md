1. Full Project Source Code
GitHub Repository Link: https://github.com/AngarajKalita/LibraryManagementSystem.git

Instructions to Run the Project Locally
### Prerequisites
- Visual Studio 2022
- .NET 8.0 SDK
- SQL Server


2. Steps to Run the Project Locally

a. Clone the Repository:
git clone https://github.com/AngarajKalita/LibraryManagementSystem.git cd LibraryManagementSystem



b. Open the Project in Visual Studio:
- Open Visual Studio 2022.
- Select `File` > `Open` > `Project/Solution`.
- Navigate to the cloned repository folder and open the `.sln` file.

c. Update Connection String:
- Open `appsettings.json` in the project.
Update the connection string to point to your local SQL Server instance

"ConnectionStrings": {
  "LibraryContext": " Server=YOUR_SERVER_NAME;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=true;"

d. Run Migrations:
- Open the Package Manager Console in Visual Studio (`Tools` > `NuGet Package Manager` > `Package Manager Console`).
- Run the following command to apply migrations and create the database:

Add-Migration InitialCreate
Update-Database


e. Run the Project:
- Press `F5` or click the `Run` button in Visual Studio to start the project.
- The application should open in your default web browser.


f. Test the API using Postman:
- Use Postman to test the API endpoints as required.



3. SQL Script to Initialize Test Data
-- SQL script to initialize test data
USE LibraryManagementSystem;

-- Insert sample data into Books table
INSERT INTO Books (Title, Author, Genre, PublishedYear, AvailabilityStatus) 
VALUES 
('Atomic Habits', 'James Clear', 'Self-help', 2018, 'Available'),
('The Silent Patient', 'Alex Michaelides', 'Psychological Thriller', 2019, 'Available'),
('The Alchemist', 'Paulo Coelho', 'Fiction', 1988, 'Available'),
('Sapiens: A Brief History of Humankind', 'Yuval Noah Harari', 'History', 2011, 'Available'),
('The Pragmatic Programmer', 'Andrew Hunt, David Thomas', 'Technology', 1999, 'Available'),
('The Subtle Art of Not Giving a F*ck', 'Mark Manson', 'Self-help', 2016, 'Available'),
('Dune', 'Frank Herbert', 'Science Fiction', 1965, 'Available');

-- Insert sample data into UserModel table
INSERT INTO UserModel(Email, Password)
VALUES
('user@gmail.com', 'password123'),

	
4. Admin Credential
Email == "Admin@gmail.com" && Password == "Admin@123"
