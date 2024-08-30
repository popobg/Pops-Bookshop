# Explanations about the project structure

"Explain to me your project as if I was a complete noob in programming."

I want to make a web application in C#.\
I choose to use **ASP.NET MVC structure**, a robust framework for developing modern web applications. This structure is clear and neat, and facilitates the apply of "separation of concerns" principle into my code, making it more maintenable and reliable.

Creating an MVC project comes with a predefined structure of files and folders. I will explain to you the purpose of each generic file.

# MVC architecture
MVC framework is a software architecture that **separates the user interface (View) from the data storage (Model) and the business logic (Controller-Service)**.

## Models folder
It represents the entities of the database, the classes containing the properties of our data.\
It can be passed to the View by the Controller as a response to a GET request.

In my case, the data manipulation is set in the **Repositories folder** that communicates with the database.

## Views folder
It contains the `.cshtml` files, **displaying the model data**.\
A `.cshtml` file has a html structure and some C# logic embedded.

It is also the user interface, so users make requests through Views.

## Controllers folder
It contains the Controller files that **receive the user's request via routing**, handle it and respond a View.

In my case, there is a specific **Service** between controller and data to make sure the request is safe and without error, to handle the logic and to make requests to the Repository.

---

### Properties folder
It is a folder containing **configuration files and settings** related to the development environment.

For example, it contains a `launchSettings.json`, which is a configuration file for project's basic settings and adjustments. As its name suggests it, its primary use is to specify how the application should be launched and debugged locally.\
It contains among other things informations about IIS (Internet Information Services) Express settings. **Application Settings**: specifies the .NET version in which the project is compiled.

### wwwRoot folder
`wwwroot` is a folder containing **static files**, like CSS stylesheets, JS files or images.\
Everything is organized in subfolder as `css/`, `js/`...

The url to access the file is : `http://<yourdomain>/subfolder/filename`.

Static files are served to the client thanks to the `app.UseStaticFiles();` line in the `Program.cs`.

### appSettings.json file
It is a **settings file** in ASP.NET Core.\
It centralizes environment-specific configuration and settings for the app in an easy-to-read format (JSON).\
We can typically find connection strings in it (database connection details), logging configuration or other app settings such as API keys.

This file is read by the system each time an ASP .NET Core application starts, and is used to configure services, middleware...

### Program.cs file
As any .NET Core project, the `Program.cs` file is the "entry point" of the application and contains the `Main` static class that is read at the run of the app. In ASP .NET, it is essential to configure and initialize the application.\
To be more precise, its purpose is to "**build and configure the host**"; the host is an object that encapsulates the ressources the application needs: dependency injection, logging, config, server features...

We always find this few lines in it:
```C#
public static void Main(string[] args)
{
    var builder = WebApplication.CreateBuilder(args);

    // configuration to use MVC architecture
    builder.Services.AddControllersWithViews();

    builder.Services.AddRazorPages();

    var app = builder.Build();

    app.UseRouting();
}
```