# LibraryOS Service-Oriented Application

This project is a service oriented CRM application which has been built on Senseframework. This project contains both host and client application and their tier developments.

Project consist of several layers.

## 1. Runtimes
  * Library.Console  (backend console application) which displays all the progress and hosting services.
  * Library.Services (backend windows service application) same as console app but which you will intall it as a window service.
  * Library.Web (ASP.Net MVC client application)
  * Library.Wpf (WPF client application which is currently in development)

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

# How does it works ?

## Installation
To install the application use LibraryOS_Installer.msi. After installation you need to configure Library.Console.exe.config file. This file includes several keys to work with. You must verify the connection string and you must run the application as an administrator.

If you enable migrations, it will trigger migrations which inserts default values to your database.

### Application Startup

Application must be run as an administator. Otherwise services will not be working. 
### Service bindings

At initial run services will be served from local ip adress from ports 8056 to 8098. You will not be able to change the port numbers.
### Connection string

By default, connection string will be configured for sqlexpress dafault instance with user Id and password. Change the string values if needed. 

### Configuration Settings (App.config)

Configuration consists of five different appSettings. End user should configure sql connection parameter to use database.
```javascript
<appSettings>
    <add key="TypeConfigurationAssembly" value="SenseFramework.Data.EntityFramework.dll;Library.Data.dll"/>
    <add key="SchemaName" value="dbo"/>
    <add key="TablePrefix" value="XXX"/>
    <add key="MigrationEnabled" value="false"/>
    <add key="UploadFile" value="E:\Uploads"/>
  </appSettings>
  <connectionStrings>
    <add name="Context" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=LibraryDB;User Id=sa;Password=demo2017;" providerName="System.Data.SqlClient"/>
  </connectionStrings> 
  ```

### AppKeys

* TypeConfigurationAssembly
Value : Name of the assembly or assemblies.
* SchemaName
Value : prefix of the database schema
* TablePrefix
Value : prefix of the database tables
* MigrationEnabled
Value : True if you want to enable migrations which will give default values
* UploadFile
Value : Name of the directory which will be used while recieving data from client.

