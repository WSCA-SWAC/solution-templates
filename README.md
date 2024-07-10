# *** Update 2024-07 ***
A much better project than this can be found at https://github.com/jasontaylordev/CleanArchitecture

It takes care of concerns such as CQRS, Clean Architecture, includes all kinds of testing (bdd with Specflow). Users should familiarize themselves with this project instead of using this simple one. It shares some of the ame concepts but goes into much more detail.

---

# Solution templates (deprecated, kept for history)

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
