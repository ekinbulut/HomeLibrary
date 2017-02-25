# LibraryOS

This project is service oriented application which has no dependicies on UI. 

Project consist of several layers.

## 1. Runtimes
  * Library.Console  (backend console application) which displays all the progress.
  * Library.Services (backend windows service application) same as console app but which you will intall it as a window service.
  * Library.Web (ASP.Net MVC application to use the library)
  * Library.Wpf (WPF application to use the library)

## 2.Tiers
  * Bussiness
    * Services (This layer consists of mutliple layers which are created as WCF services)
    * Library.UI.Services (This layers is a middleware for WPF application. It provides Models and controllers for the interface interactions)
  * Data (DataLayer uses entity framework with code first) Includes all repositories and entities.
  * MVC (This layers has two layers which provides support for Library.Web application.)
