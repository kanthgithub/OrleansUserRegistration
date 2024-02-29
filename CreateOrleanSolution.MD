# Creating a New Orleans Project

Here are the steps to create a new Orleans project with Grains, SiloHost, and WebApiClient modules:

## Prerequisites

- .NET 5.0 SDK: The solution is built with .NET 5.0. Make sure you have the .NET 5.0 SDK installed on your machine. You can download it from the [official .NET website](https://dotnet.microsoft.com/download).

## Create the Solution and Projects

1. Open a terminal and navigate to the directory where you want to create the solution.

2. Run the following command to create a new solution:

```sh
dotnet new sln -n MyOrleansSolution
```

3. Navigate to the newly created solution directory:

```sh
cd MyOrleansSolution
```

4. Run the following commands to create the Grains, SiloHost, and WebApiClient projects:


```sh
dotnet new classlib -n Grains
dotnet new console -n SiloHost
dotnet new webapi -n WebApiClient
```

5. Run the following commands to add the projects to the solution:

```sh
dotnet sln add Grains
dotnet sln add SiloHost
dotnet sln add WebApiClient
```

## Install Dependencies

1. Navigate to the Grains project directory and run the following commands to install the Orleans packages:

```sh
cd Grains
dotnet add package Microsoft.Orleans.Core.Abstractions --version 3.5.2
dotnet add package Microsoft.Orleans.OrleansCodeGenerator.Build --version 3.5.2
cd ..
```

2. Navigate to the SiloHost project directory and run the following commands to install the Orleans packages:

```sh
cd SiloHost
dotnet add package Microsoft.Orleans.Core --version 3.5.2
dotnet add package Microsoft.Orleans.Server --version 3.5.2
dotnet add package Microsoft.Orleans.OrleansCodeGenerator.Build --version 3.5.2
dotnet add package Microsoft.Orleans.OrleansDashboard --version 3.5.2
cd ..
```

3. Navigate to the WebApiClient project directory and run the following commands to install the Orleans packages:

```sh
cd WebApiClient
dotnet add package Microsoft.Orleans.Core.Abstractions --version 3.5.2
dotnet add package Microsoft.Orleans.Client --version 3.5.2
cd ..
```

## Implement the Grains, SiloHost, and WebApiClient

At this point, you have a basic Orleans solution structure. You can now start implementing your grains in the Grains project, configure and start your silo in the SiloHost project, and implement your web API in the WebApiClient project.

Remember to reference the Grains project from the SiloHost and WebApiClient projects. You can do this by running dotnet add reference ../Grains in the SiloHost and WebApiClient project directories.

Also, don't forget to add the necessary using directives in your code files to use the Orleans namespaces. For example, using Microsoft.Orleans;.

## Run the Solution
To run the solution, you need to start the SiloHost project to start the Orleans silo, and then start the WebApiClient project to start the ASP.NET Core web API. You can do this by navigating to the respective project directories in your terminal and running dotnet run.

You can now test the solution by sending HTTP requests to the web API. For example, you can use curl, Postman, or the REST Client extension in Visual Studio Code to send a POST request to http://localhost:5000/user to register a new user (assuming you have implemented a user registration endpoint). ```