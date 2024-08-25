# Web MVC POC Application

This is a Proof of Concept (POC) web application built using the ASP.NET Core MVC framework with .NET 8.0.

## Prerequisites

- Visual Studio 2022 (or later)
- .NET 8.0 installed

### Getting Started

### 1. Clone the repository:
    
    git clone  https://github.com/dariomessina1991/gls_assignment.git
    
### 2. Open the Solution

  - Open Visual Studio.
  - Navigate to `File -> Open -> Project/Solution`.
  - Select the `.sln` file from the cloned repository.

### 3. Build the Solution

  - Once the solution is opened in Visual Studio:
  - Ensure the solution is selected in the Solution Explorer.
  - Click on `Build -> Build Solution` or press `Ctrl+Shift+B`.

### 4. Run the Application

  - After successfully building the solution, follow these steps to run the application:
  - In the toolbar at the top, next to the play button (▶️), select `"http"` from the dropdown (this sets the application to run using HTTP).
  - Click the play button (▶️) or press `F5` to start the application.

### 5. Access the Web Interface

  - Once the application is running, your default browser should automatically open and navigate to the application's web interface. The application is configured to run on port 5073, so you can manually navigate to:

    http://localhost:5073

    This is the default port specified in the solution's properties.

    ### Using the Application

The web interface consists of a form where users can input parameters to retrieve data:

- **ID:** Enter the unique ID of the data you want to retrieve.
- **Start Date:** Enter the start date in ISO 8601 format (e.g., YYYY-MM-DD).
- **End Date:** Enter the end date in ISO 8601 format (e.g., YYYY-MM-DD).

After filling in the fields, click on the **"Esegui"** button. The application will process the input and display the corresponding data results below the form.

### Example Use Case

- **ID:** 2
- **Start Date:** 2021-02-01
- **End Date:** 2021-02-05

Click **"Esegui"** and the data corresponding to the input parameters will be shown on the page.

### Error Handling

- Ensure that all fields are filled in before submitting.
- Dates should be in the correct format (YYYY-MM-DD).
- If invalid data is entered, appropriate error messages will be displayed.

### Troubleshooting

- **Build Issues:** If there are issues building the project, ensure all dependencies are properly installed via NuGet, and check that you are targeting .NET 8.0.
- **Port Issues:** If the default port 5073 is in use by another application, Visual Studio may assign a different port. Check the output window for the correct URL or manually configure the port in the project settings.

### Technologies Used

- **ASP.NET Core MVC** - for the backend and web interface
- **C#** - primary language used for development
- **.NET 8.0** - runtime framework

### License

This project is licensed under the MIT License - see the LICENSE file for details.
