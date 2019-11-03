# GroceryListStoringApp

Grocery List Storing App 

Target Framework: 

* .NET Framework 4.7.2

Database: 

* PostgreSQL 10.10.2

NuGet Packages: 

* Npgsql 4.1.1

* FluentNHibernate 2.1.2
                
# Structure
* Form1.cs -- Main Form class

* NHibernateHelper.cs -- NHibernate Main Class

* DomainClasses/ -- NHibernate Tables Properties

* MappingClasses/ -- NHibernate Mapping Tables Classes

* RepositoryInteractions/ -- Classes interacting with Database

* InsertItemForm.cs -- Create new item in database Form class

* CreateListForm.cs -- Create new list in database Form class

* GroceryListStoringDB.sql -- Exported PostgreSQL Database
