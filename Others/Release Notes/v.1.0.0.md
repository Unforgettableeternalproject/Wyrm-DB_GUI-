---

# Release Documentation for Wyrm

## Release Version: v1.0.0

### Release Date: 2024/06/12

![User_Interface_Snapshot](https://github.com/Unforgettableeternalproject/Wyrm-DB_GUI-/assets/95599456/8d1d5476-65b9-41d9-a795-57224600b9ae)

---

## Overview

Wyrm is a Windows Forms application designed to provide a user-friendly interface for interacting with a MariaDB database. This release, version 1.0.0, includes all the core features necessary for database management and data querying, as well as several enhancements for better user experience.

---

## Features

### Core Features

1. **Database Connection**
   - Connect to a MariaDB database using custom server IP, port, database name, username, and password.
   - Validate connection credentials and database existence before initializing the connection.

2. **Data Querying**
   - Execute SELECT and SHOW queries to retrieve data from the database.
   - Display query results in a DataGridView.

3. **User Interface Enhancements**
   - Toggle password visibility for easier input of database credentials.
   - Keyboard shortcuts for query execution:
     - Shift+Enter: Add query to the query history.
     - Enter: Execute the query.
     - Alt+Enter: Clear the query input.

4. **Error Handling**
   - Capture and display SQL syntax errors, connection issues, and other common exceptions.

5. **Export Data**
   - Export DataGridView data to a CSV file for external use.

### Additional Features

1. **User Manual**
   - Access a comprehensive user manual from the menu strip, which provides detailed information about the application's features and usage.

---

## Installation

To install Wyrm, follow these steps:

1. **Download the Release**
   - Download the latest release package from the [Releases](https://github.com/Unforgettableeternalproject/DB_GUI/releases) page on GitHub.

2. **Extract the Files**
   - Extract the downloaded ZIP file to your desired location.

3. **Run the Application**
   - Double-click the executable file (`DB_GUI.exe`) to launch the application.

---

## Usage

1. **Connecting to the Database**
   - Open the application.
   - Enter the server IP, port, database name, username, and password in the respective fields.
   - Click the "Connect" button to establish a connection.

2. **Executing Queries**
   - Enter your SQL query in the query input box.
   - Use the keyboard shortcuts or click the "Execute" button to run the query.
   - View the results in the DataGridView.

3. **Exporting Data**
   - Click the "Export" button to save the current DataGridView data to a CSV file.
   - Choose the save location and filename in the dialog that appears.

4. **Accessing the User Manual**
   - Click on the "Help" menu and select "User Manual" to open the manual in a new window.

5. **Exiting the Application**
   - Click the "X" button on the top-right corner of the window.
   - Confirm the exit in the prompt that appears.

---

## Known Issues

- Currently None.

---

## Future Improvements

1. **Enhanced Query Support**
   - Allow more types of SQL queries while ensuring database integrity.

2. **Improved Error Handling**
   - Provide more detailed error messages and potential solutions.

3. **Additional Export Formats**
   - Support exporting data to Excel and other formats.

4. **User Interface Enhancements**
   - Add more customization options and improve the overall user experience.

---

## Support

For any issues, bugs, or feature requests, please open an issue on the [GitHub Issues](https://github.com/Unforgettableeternalproject/Wyrm-DB_GUI-/issues) page.

---

Thank you for using Wyrm! It was for a Database term project, but we managed to make it a complete application!

---

**Full Changelog**: https://github.com/Unforgettableeternalproject/Wyrm-DB_GUI-/compare/Wyrm...v.1.0.0