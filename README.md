# LibraryOS Service-Oriented Application

This project is a service oriented CRM application which has been built on Senseframework. This project contains both host and client application and their tier developments.

Project consist of several layers.

## 1. Runtimes
  * Library.Console  (backend console application) which displays all the progress and hosting services.
  * Library.Services (backend windows service application) same as console app but which you will intall it as a window service.
  * Library.Web (ASP.Net MVC client application)
  * Library.Wpf (WPF client application)

## 2. Tiers
  * Bussiness
    * Services (This layer containes services which are ready to be hosted as WCF services)
    * Library.UI.Services (This layers is a middleware for WPF application. It provides Models and controllers for the interface interactions)
  * Data (DataLayer uses entity framework with code first configuration.) Includes all repositories and entities.
  * MVC (This layers has two layers which provides support for Library.Web application.)

## 3. SenseFramework
SenseFramework is a tool to develop n-tier applications easily. It provides several ORM tools and NOSQL library with repository patterns, unit of work, typeconfigurations etc. The framework works with Castle.Windsor and configures services as a WCF. It provides base libraries for tier modules. 

In this project you will only see the compiled dlls.

## Requirements
* SQL Server 2015 or higher
* IIS server for ASP.NET MVC client application
