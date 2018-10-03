# LibraryOS Service-Oriented Application

This project is a service oriented CRM application which has been built on Senseframework. This project contains both host and client application and their tier developments.

Project consist of several layers.

[![Build status](https://ci.appveyor.com/api/projects/status/0aq4xhqco0tjd1ac?svg=true)](https://ci.appveyor.com/project/ekinbulut/homelibrary)

## 1. Runtimes
  * Library.Console  - self hosted console application
  * Library.Services - self hosted windows service
  * Library.Web - ASP.Net MVC client application
  * Library.Wpf - WPF client version of the application which is under development

## 2. Tiers
  * Bussiness
    * Services - Provides and registers WCF services.
    * Library.UI.Services - Contains model and controllers for WPF
  * Data - Includes all repositories and entities.
  * MVC - Provides support for Library.Web application.

## 3. SenseFramework
SenseFramework is a tool to develop n-tier applications easily. It provides several ORM tools and NOSQL library. The framework works with Castle.Windsor and supports WCF as service.

## Requirements
* SQL Server 2015 or higher
* IIS server for ASP.NET MVC client application

# How does it works ?

## Configure workspace

After pulling the project, you need to open PM from Visual Studio and type Update-Database command. Database will be created initially. If you want to add users and roles to your database so that you need to write your own code on HomeLibrary/Tiers/Data/Library.Data/Migrations/Configuration.cs to insert records.

add users and roles for initial usage.
### Application Startup

Library.Console application must be run as an administator. It will be hosting services as a WCF endpoint.

### Service bindings

At initial run services will be served from local ip adress from ports 8095 to 8098. You will not be able to change the port numbers.

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

