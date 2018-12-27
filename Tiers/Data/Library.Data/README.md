### How to Enable Migrations

##### 1-  Add keys setting to startup application

```xml  
<appSettings>
	<add key="SchemaName" value="dbo"/>
	<add key="TablePrefix" value="XXX"/>
</appSettings>
  ```

##### 2 - Add connection string to app.config

```xml
  <connectionStrings>
	<add name="Context" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=LibraryDB;User Id=demo;Password=demo2017;" providerName="System.Data.SqlClient"/>
  </connectionStrings>
```


##### 3 - Open Package Manager run commands below.

	> Enable-Migrations
	> add-migration Initial
	> update-database

At the end of the migration Roles will be added to table.