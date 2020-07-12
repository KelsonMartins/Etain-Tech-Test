# WeatherForecast

This Weather Forecast Application, was scaffolded using a SPA (single page application) template and built using mainly the dotnet cli. It allows for minimal configuration as for a faster getting started, it already comes set up with:

- **Client-side navigation**. For example, click _Weather Forecast_ then _Home_ to return here.
- **Angular CLI integration**. In development mode, there's no need to run `ng serve`. It runs in the background automatically, so client-side resources are dynamically built on demand and the page refreshes when modifying any file.
- **Efficient production builds**. In production mode, development-time features are disabled, and `dotnet publish` configuration automatically invokes `ng build` to produce minified, ahead-of-time compiled JavaScript files.
- **Authentication and Authorization**. Out of the box Identity Server core features, including Angular service integrations.

The `ClientApp` directory is a standard Angular CLI application. If you open a command prompt in that directory, you can run any `ng` command (e.g., `ng test`), or use `npm` to install extra packages into it.

The `ServerApp` directory is a standard ASP.NET Core Web Application (MVC or Razor Pages). If you open a command prompt in that directory, you can run any `dotnet` command (e.g., `dotnet build`), or use any other cli tools to manage and build the application. In it's essence is running as a protected web service, consumed by the `ClientApp`.

## Scope

Create an ASP.NET MVC application that will display the weather forecast for the next 5 days in Belfast.

## Requeriments

- [ ] Consume Meta Weather REST API (Web Service)
- [ ] Ability to pull to refresh (Mobile Optimised)
- [ ] Forecast List must include (date, weather state and weather state image representation)
- [ ] Use out of the box AuthN/AuthZ mechanisms. Only allow AutnN/Z access.

## Development ToolKit

| Tool                                     | Use Case     |
|--------------------------------------    |----------    |
| VS Code                                  | I've used VS Code, as my prefered IDE tool, not only for it's light-weight capabilities and modular features through extensions, but mainly due to the limitations with my development machine.             |
| .NET Core SDK (Angular SPA template)     | I've used ASP.NET Core and C# for cross-platform server-side code.             |
| Node.js (Angular Cli)                    | I've used Angular w/ TypeScript for client-side code, and Bootstrap for layout and styling.             |
| GitHub                                   | I've used for source control.             |

## Unit test

When I started developing this app, I was planning on writting a few Unit tests for best practice. However, due to a couple of factors, such as test time limitations, application complexity and personal preference, I've opted for using Swagger and rely on Open API specifications. Also this can take some time to setup properly.

If you wish to test the `WeatherService.cs` web-service, please use `https://localhost:5001/swagger`.

> Please, do disreagard the Unit Testing project.

## Setup Notes

In order to get the app up and running, just follow the steps below:

1. Clone the repo to your local development machine.
2. Open a command prompt in the directory `ServerApp`.
3. Run dotnet build to verify the app builds correctly.
4. Run dotnet run to start the app. A message similar to the following is logged:

```dotnetcli
    Now listening on: https://localhost:5001
```

5. Navigate to this URL in a browser.

> On the first run, the build process restores npm dependencies, which can take several minutes. Subsequent builds are much faster.
> Ensure you have an environment variable called ASPNETCORE_Environment with a value of Development. On Windows (in non-PowerShell prompts), run SET ASPNETCORE_Environment=Development. On Linux or macOS, run export ASPNETCORE_Environment=Development.

### Connection Strategy

The project is configured to start its own instance of the Angular CLI server in the background when the ASP.NET Core app starts in development mode. This is convenient because you don't have to run a separate server manually.

#### Managed

From a command prompt, navigate to the `../ServerApp` folder, and run the command `dotnet watch run`
Open a browser window and navigate to `https://localhost:5001` for the MVC server app and `https://localhost:5001/app` for the Angular client app.

#### Proxy

From a command prompt, navigate to the ../ClientApp folder, and run the command `npm start`
From a different command prompt, navigate to the ../ServerApp folder, and run the command `dotnet watch run`

## FAQs

Breadown of the scaffolded template constituting parts in form of an helpful FAQ.

### What is it?

A combined project includes Angular and ASP.NET Core MVC in a single folder structure.

### Why is it useful?

A combined project makes it easy to develop both parts of an application using a single IDE, such as Visual Studio Code, as well as simplifying the process of using an ASP.NET Core
MVC web service to provide data to Angular.

### How is it used?

The Angular application is created first, followed by ASP.NET Core MVC. Additional NuGet packages are used to allow both parts of the project to work together at runtime.

### Are there any pitfalls or limitations?

A combined project makes managing the development process easier, but you still need a good working knowledge of both Angular and ASP.NET Core MVC to create an
effective application.

### Are there alternatives?

You can develop the Angular and ASP.NET Core MVC parts of the application separately, although this tends to complicate the development process.
