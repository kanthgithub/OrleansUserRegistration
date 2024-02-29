# Orleans for Java and TypeScript Developers

Orleans is a framework for building distributed systems. It introduces the concept of "Virtual Actors" called grains to build components that are distributed and parallel. If you're familiar with the concept of objects in Java or TypeScript, you can think of grains as distributed objects.

## Grains
A grain is the fundamental unit of distribution and computation in Orleans. It's similar to an object in OOP, but it's distributed and virtual. Each grain has a unique ID and encapsulates state and behavior.

Grains are created and managed by the Orleans runtime. When you want to interact with a grain, you get a reference to it using its unique ID. If the grain is not currently in memory, the Orleans runtime will automatically activate it for you. This is similar to how you would create an object using the new keyword in Java or TypeScript, but the lifecycle of the grain is managed by the Orleans runtime, not by your code.

### The lifecycle of a grain is as follows:

1. Activation: When a request is made to a grain that's not currently in memory, the Orleans runtime will activate it. This involves creating an instance of the grain and loading its state from persistent storage if necessary.

2. Deactivation: When a grain has not been used for a certain period of time, the Orleans runtime will deactivate it to free up resources. This involves saving the grain's state to persistent storage if necessary and then removing the grain instance from memory.


## Grain State and State Management
å
Grains can have state, just like objects in Java or TypeScript can have fields. The state of a grain is automatically persisted and loaded by the Orleans runtime when the grain is activated and deactivated. This is similar to how an object's state would be saved to a database and loaded from it in a traditional web application, but it's handled automatically by the Orleans runtime.

Orleans provides built-in support for state persistence through the `IPersistentState<T>` interface. You can use this interface to declare persistent state in your grains. The state will be automatically saved to and loaded from a storage provider that you configure.

Orleans supports various storage providers out of the box, including Azure Table Storage, AWS DynamoDB, and SQL databases. For MongoDB, you would need to use a third-party package like `Orleans.Providers.MongoDB`.


## Silo Server

A silo is a server in an Orleans application. It's where grains live and execute. You can think of it as a container for grains.

The `Program.cs` file in the `SiloHost` project is where the silo is configured and started. Here's a step-by-step explanation of the code:

1. A new `SiloHostBuilder` is created. This is a builder object that's used to configure the silo.

2. `UseLocalhostClustering()` is called to configure the silo to use localhost clustering. This means that the silo will form a single-node cluster on the local machine. In a production environment, you would typically use a different clustering provider that supports multi-node clusters.

3. The `ClusterOptions` are configured with a cluster ID and service ID. These are identifiers for the Orleans application and are used for clustering and persistence.

4. The application parts are configured to include the assembly that contains the grain interfaces. This tells the Orleans runtime where to find the grain implementations.

5. Logging is configured to output to the console.

6. The Orleans Dashboard is enabled. This is a web UI that provides information about the Orleans application.

7. The silo is built and started. At this point, the silo is running and ready to activate grains and process requests.


## WebApiClient

The `WebApiClient` project is an ASP.NET Core web API that serves as a front-end for the Orleans application. It exposes HTTP endpoints that clients can call to interact with the grains.

The `WebApiClient` project contains controllers, which are classes that handle HTTP requests. Each controller has methods that correspond to different HTTP verbs (GET, POST, etc.). These methods call into the Orleans grains to perform operations and return responses to the clients.

The `WebApiClient` project also contains a Startup.cs file where the ASP.NET Core application is configured. This includes configuring the Orleans client, which is used to connect to the Orleans silo and get references to grains.

In the `Startup.cs` file, the Orleans client is configured with the same clustering provider and options as the silo. This allows the client to connect to the silo. The client is then built and connected in the `ConfigureServices` method, and it's registered with the dependency injection container so that it can be injected into the controllers.

In the controllers, the Orleans client is used to get references to grains using their unique IDs. The methods on the grain references can then be called to interact with the grains. The results of these calls are returned as HTTP responses.