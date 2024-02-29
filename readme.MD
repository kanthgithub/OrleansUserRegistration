# User Registration Solution

This solution is a user registration system implemented using the Microsoft Orleans framework. It allows users to register, retrieve user information, and list all registered users.

## Technology Stack

- **Microsoft Orleans**: This is a framework that provides a straightforward approach to building distributed high-scale computing applications. It's used in this project to implement the core logic of the user registration system in a scalable and reliable way. The main components of Orleans used in this project are Grains, which are the building blocks of an Orleans application.

- **ASP.NET Core**: This is a framework for building web applications. It's used in this project to expose the functionality of the Orleans grains as RESTful APIs.

## REST APIs

The following REST APIs are implemented in the `WebApiClient` project:

- `POST /user`: Registers a new user. The request body should contain the user details in the form of a `UserRegisterRequest` object.

- `GET /user/{id}`: Retrieves the details of a user by their ID.

- `GET /user/username/{userName}`: Retrieves the details of a user by their username.

- `GET /user`: Retrieves the details of all registered users.

These APIs are implemented in the `UserController` class.

## Grains

The following grains are implemented in the `Grains` project:

- `UserGrain`: This grain provides the core functionality of the user registration system. It allows registering new users, retrieving user details by ID or username, and listing all registered users.

The `UserGrain` is implemented in the `UserGrain.cs` file and it implements the `IUserGrain` interface defined in `IUserGrain.cs`.

# User Registration Solution Setup

Follow these steps to set up the User Registration Solution on your local machine:

## Prerequisites

- .NET 5.0 SDK: The solution is built with .NET 5.0. Make sure you have the .NET 5.0 SDK installed on your machine. You can download it from the [official .NET website](https://dotnet.microsoft.com/download).

## Clone the Repository

First, clone the repository to your local machine. You can do this by running the following command in your terminal:

```bash
git clone <repository-url>
```

Replace <repository-url> with the URL of your Git repository.

### Install Dependencies

Navigate to the root directory of the solution (the directory that contains the .sln file) in your terminal, and run the following command to restore all NuGet packages:

```bash
dotnet restore
```

### Build the Solution

To build the solution, run the following command in your terminal:

```bash
dotnet build
```

## Running the Solution

To run the project, you need to start the `SiloHost` project to start the Orleans silo, and then start the `WebApiClient` project to start the ASP.NET Core web API. You can then use the web API to interact with the user registration system.

The solution consists of two projects that need to be run: the SiloHost project and the WebApiClient project.

First, navigate to the SiloHost project directory in your terminal and run the following command to start the Orleans silo:

```bash
dotnet run
```

Then, open a new terminal, navigate to the WebApiClient project directory, and run the following command to start the ASP.NET Core web API:

```bash
dotnet run
```

## Test the Solution
You can now test the solution by sending HTTP requests to the web API. For example, you can use curl, Postman, or the REST Client extension in Visual Studio Code to send a POST request to http://localhost:5000/user to register a new user.

## Troubleshooting
If you encounter any issues while setting up the solution, check the following:

- Make sure you have the correct .NET SDK version installed.
- Make sure all NuGet packages were restored successfully. If not, try running dotnet restore again.
- Check the error messages in the terminal for any clues about what might be going wrong.
- If you're having issues with the Orleans Dashboard, make sure you have the OrleansDashboard NuGet package installed. You can install it by running dotnet add package OrleansDashboard in your terminal.


## Accessing the Orleans Dashboard

Once the `SiloHost` project is running, you can access the Orleans Dashboard by navigating to `http://localhost:8080` in your web browser (replace `localhost` with the appropriate hostname if your silo is not running locally).

## Understanding the Dashboard Stats

The Orleans Dashboard provides a wealth of information about your Orleans application. Here's a brief overview of some of the key stats:

- **Silo Count**: The number of silos in the cluster.

- **Grain Types**: The different types of grains in your application. You can click on a grain type to see more details about it.

- **Total Activations**: The total number of grain activations across all silos. A grain activation is an instance of a grain that's currently in memory.

- **Total Requests**: The total number of requests that have been processed by the grains.

- **Throughput**: The number of requests per second that are being processed by the grains.

- **CPU Usage**: The CPU usage of each silo.

- **Memory Usage**: The memory usage of each silo.

Remember that the Orleans Dashboard should not be used in production environments, as it has some performance overhead and can expose sensitive information. For production environments, consider using a logging and monitoring solution like Application Insights, Prometheus, or Grafana.