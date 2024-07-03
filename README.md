# Solution templates

This repository hosts solution templates that can be used to start new projects.

## Pre-Requisites
- .NET 8
- NodeJS

## Getting Started

All the templates are located inside the "templates" folder.

The templates can be installed by the dotnet tool with "dotnet install".

For example, from the templates/WscaBaseSolution folder, running the following command will create a custom dotnet template called "wsca_base_solution":

``` powershell
dotnet new install .
```

This template can then be used to create a new project with the specified name:

```
dotnet new wsca_base_solution -n MyNewProjectName
```