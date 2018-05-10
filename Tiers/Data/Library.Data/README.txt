How to Enable Migrations

1 - Add 

  <appSettings>
	<add key="SchemaName" value="dbo"/>
	<add key="TablePrefix" value="XXX"/>
  </appSettings>

  Keys to app.config


2 - Add connection string to app.config

  <connectionStrings>
	<!--<add name="Context" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=LibraryDB;User Id=demo;Password=demo2017;" providerName="System.Data.SqlClient"/>-->
  </connectionStrings>



3 - Open Package Manager run commands below.

	> Enable-Migrations
	> add-migration Initial
	> update-database