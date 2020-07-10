# WeatherForecast

## Scope

Create an ASP.NET MVC application that will display the weather forecast for the next 5 days in Belfast.

## Stories

- Application displays weather forecast from Meta Weather REST API
- Application displays weather forecast from Belfast
- Application denies access to unauthorised users
- Application allows User allows to register account

## Requeriments

- [ ] Consume Meta Weather REST API (Web Service)
- [ ] Ability to pull to refresh (Mobile Optimised)
- [ ] Forecast List must include (date, weather state and weather state image representation)
- [ ] Use out of the box AuthN/AuthZ mechanisms

## Development ToolKit

| Tool                                     | Use Case     |
|--------------------------------------    |----------    |
| VS Code                                  |              |
| .NET Core SDK (Angular SPA template)     |              |
| Node.js (Angular Cli)                    |              |
| GitHub                                   |              |

## Persistance

> docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=tsl4433#test' -e 'MSSQL_PID=Express' -name sql.data -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest-ubuntu

## Setup Notes

Ensure you have an environment variable called ASPNETCORE_Environment with a value of Development. On Windows (in non-PowerShell prompts), run SET ASPNETCORE_Environment=Development. On Linux or macOS, run export ASPNETCORE_Environment=Development.

Run dotnet build to verify the app builds correctly. On the first run, the build process restores npm dependencies, which can take several minutes. Subsequent builds are much faster.

Run dotnet run to start the app. A message similar to the following is logged:

```dotnetcli
    Now listening on: https://localhost:5001
```

Navigate to this URL in a browser.

### Connection Strategy

The project is configured to start its own instance of the Angular CLI server in the background when the ASP.NET Core app starts in development mode. This is convenient because you don't have to run a separate server manually.

#### Managed

From a command prompt, navigate to the ../ServerApp folder, and run the command
> dotnet watch run
Open a browser window and navigate to `https://localhost:5001` for the MVC server app and `https://localhost:5001/app` for the Angular client app.

#### Proxy

From a command prompt, navigate to the ../ClientApp folder, and run the command
> npm start
From a different command prompt, navigate to the ../ServerApp folder, and run the command
> dotnet watch run

## FAQs

### What is it?

A combined project includes Angular and ASP.NET Core MVC in a single folder
structure.

### Why is it useful?

A combined project makes it easy to develop both parts of an application using a single
IDE, such as Visual Studio, as well as simplifying the process of using an ASP.NET Core
MVC web service to provide data to Angular.

### How is it used?

The Angular application is created first, followed by ASP.NET Core MVC. Additional
NuGet packages are used to allow both parts of the project to work together at runtime.

### Are there any pitfalls or limitations?

A combined project makes managing the development process easier, but you still
need a good working knowledge of both Angular and ASP.NET Core MVC to create an
effective application.

### Are there alternatives?

You can develop the Angular and ASP.NET Core MVC parts of the application separately, although this tends to complicate the development process.
