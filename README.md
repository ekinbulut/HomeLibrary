# LibraryOS Service-Oriented Application

This project is a service oriented application which has no dependicies on UI. 

Project consist of several layers.

## 1. Runtimes
  * Library.Console  (backend console application) which displays all the progress.
  * Library.Services (backend windows service application) same as console app but which you will intall it as a window service.
  * Library.Web (ASP.Net MVC application to use the library)
  * Library.Wpf (WPF application to use the library)

## 2. Tiers
  * Bussiness
    * Services (This layer consists of mutliple layers which are created as WCF services)
    * Library.UI.Services (This layers is a middleware for WPF application. It provides Models and controllers for the interface interactions)
  * Data (DataLayer uses entity framework with code first) Includes all repositories and entities.
  * MVC (This layers has two layers which provides support for Library.Web application.)

## 3. SenseFramework
SenseFramework is a tool to develop n-tier applications easily. It provides several ORM tools and NOSQL library with repository patterns, unit of work, typeconfigurations etc. The framework works with Castle.Windsor and configures services as WCF apis. It provides base libraries for tier modules. 

In this project you will only see the library files.

## Requirements
* SQL Server 2015 or higher
* IIS server for ASP.NET MVC to serve application.
