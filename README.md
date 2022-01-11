# Finance Scheduler App Demo

This App should help with purchase planning and finance flow controlling.

### This repository for development purposes, contains BETA version of application

- Functionality is under development at the moment, when features ready, I will keep it updated here.
- Version v.1.0.
- [Learn Markdown](https://bitbucket.org/tutorials/markdowndemo)

### Set Up steps

- Download or clone the tutorial project code from [here](https://github.com/AlexanderZhadetskij/finance_scheduler_dev.git/).
- Start the project by running dotnet run from the command line in the project root folder (where the FinanceSchedulerDemo.csproj file is located), you should see the message Now listening on: http://localhost:5001.
- NOTE: You can also start the application in debug mode in VS Code by opening the project root folder in VS Code and pressing F5 or by selecting Debug -> Start Debugging from the top menu.
  Running in debug mode allows you to attach breakpoints to pause execution and step through the application code.
- Configuration: the app is configured by json configuration provider, so add necessary sections to the appsettings.json and use them via Options.
- To develop and run ASP.NET Core applications locally, download and install the following:
  - .NET Core 5 SDK - includes the .NET Core runtime and command line tools.
  - Visual Studio Code - code editor that runs on Windows, Mac and Linux.
  - C# extension for Visual Studio Code - adds support to VS Code for developing .NET Core applications.
- Database configuration: SQL Server is used, create your own instance and provide Connection String to the settings file (appsettings.json). In PMC run Update-Database.
- How to run tests: Run `dotnet run` command from project folder for BE, for FE run `ng test` via node package manager console from client app folder.
- Deployment instructions

### Contribution guidelines

- Writing tests: coming soon
- Code review: coming soon
- Other guidelines: coming soon

### Our community

- Repo owner: https://github.com/AlexanderZhadetskij
