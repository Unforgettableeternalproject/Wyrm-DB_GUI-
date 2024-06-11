# User Interface for DB_FinalProject


Origin: https://github.com/Unforgettableeternalproject/DB_FinalProject


This application is a Windows Forms application that allows users to connect to a MariaDB database and retrieve information. The application provides a user interface for entering information and querying the database, displaying the results directly in the application.

## Features

- **Database Connection:** Connect to a MariaDB database using user-provided credentials.
- **Retrieve Information:** Execute a SELECT query to retrieve information from the database and display it.

## Prerequisites

- .NET Framework (version compatible with your WinForms project, typically .NET Framework 4.6 or later)
- MariaDB Server
- MariaDB Connector/NET (to connect to MariaDB from your .NET application)

## Installation

1. **Install MariaDB Server:**
   - Download and install MariaDB Server from the official MariaDB website.
   - Create a database and necessary tables.

2. **Install MariaDB Connector/NET:**
   - Download and install MariaDB Connector/NET from the official MariaDB website or use NuGet package manager to install it:
     ```sh
     Install-Package MySql.Data
     ```

3. **Clone or Download the Project:**
   - Clone the repository or download the project files from the provided source.

4. **Open the Project:**
   - Open the project in Visual Studio.

## Configuration

1. **Set Up the Connection String:**
   - To be revised.

## Usage

1. **Initialize Database Connection:**
   - The application will try to connect to the database using the provided connection string. Ensure that the database server is running and accessible.

2. **Retrieve Information:**
   - To be revised.

## Running the Application

1. **Build the Project:**
   - Build the project in Visual Studio to ensure all dependencies are resolved and there are no compilation errors.

2. **Run the Application:**
   - Start the application. Use the provided user interface to input information and execute queries.
   - Ensure that the MariaDB server is running and the connection string is correctly configured.

## Troubleshooting

- **Connection Issues:** Ensure that the MariaDB server is running and the connection string parameters (server, port, database, user, password) are correct.
- **MariaDB Connector/NET:** Ensure that the MariaDB Connector/NET is installed and referenced in your project.
- **Permissions:** Ensure that the MariaDB user has the necessary permissions to access the database and perform SELECT and INSERT operations.

---