## GridTariff Api

GridTariff Api is an Api intended for for offering variable electrical grid tariffs.
GridTariff Api exposes the following services:

* Retrieve all available available tariffs (api/{v:apiVersion}/tarifftype)
* Retrieve tariff prices per hour for a given tariff for a given timeperiod (api/{v:apiVersion}/tariffquery)

### Retrieve all available available tariffs (api/{v:apiVersion}/tarifftype)
Service takes zero parameters
Service returns json containing information about all tarrifs

### Retrieve tariff prices per hour for a given tariff for a given timeperiod (api/{v:apiVersion}/tariffquery)
Service takes two parameters.
Parameter one is the tariff which the service is to return data for.
Parameter two is the timeperiod in question.
The timperiod can be specified in two ways.
Either specify timeperiod using paramater Range. Valid values are 'yesterday','today' or 'tomorrow'.
Or specify timeperiod using StartTime and EndTime.

The service will return tariffs per hour for the given tariff and timeperiod.
For each hour there will be returned a fixed price element, and a variable price element.
The variable price element can change for each hour during the day.
On public holidays, Saturdays and Sundays the variable price elements is always the cheapest available, for all hours of the day.

## Overview of projects in solution

### Project GridTariffApi.lib
Contains all business logic for Api.

### Project GridTariffApi.lib.Tests
Unit tests for project GridTarifApi.lib

### Project GridTariffApi
Project which uses GridTariffApi.lib to and hosts the services.
This project is native to Elvia and is intended to serve as an example of how to host the services.

## Project GridTariffApi.lib folders

### Config
Contains classes for configuration of the project.

### Controllers
Contains controllers for the offered functionality

### EntityFramework
Contains Entity Framework classes for database persisting tariff information

### Models 
Contains classes for request/response objects used by controllers

### Services
Contains classes with business logic used by controllers

###  SQL
Contains sql statements for creating required tables in database

###  SQL
Contains sql statements for creating required tables in database

### Swagger
Contains classes related to documentation of of Api.


## Project GridTariffApi folders

### Auth
Contains classes for basic authentication for the Api.

### Controllers
Contains controllers not related to GridTariffApi

### SQL 
Contains sample sql insert statements for populating the database persisting tariff information

## Most important datbase tables used by GridTariff Api
Script for creating SQL Server database and sample data exists in folder 'SQL' in the solution.

### Table 'tarifftype'
This table contains all tariffs.

### Table 'fixedpriceconfig'
This table contains fixed price element for tariffs.
Fixed prices is specified as the fixed price for a given month.
(The Api will calculate fixed price element per hour based on total amount of hours for a given month).
Fixed prices have a validity interval (pricefromdate/pricetodate).
Fixed price validity interval can not be arbitrary, they must start/stop at beginning/end of month

### Table 'variablepriceconfig'
This table contains variable price elements for a given tariff.
Each tariff may have one or more rows of variable price elements for a given day.
The column 'Hours' specify which hours of the day the variable price elements is valid.
Variable prices have a validity interval (pricefromdate/pricetodate).
Variable price validity interval can not be arbitrary, they must start/stop at beginning/end of month

### Table 'publicholiday'
This table contains public holidays.
(For these days the cheapest variable price element valid for the day is used, for all hours of the day).

## Overview of solution folders

### CI
Sample build/deployment files.
These project is native to Elvia.

### Solution Items 
Contains this file
Contains Dockerfile native to Elvia.


## Authentication
Controllers in project GridTariffApi.Lib require authentication, but does not contain files for authentication.
Authentication should be added by the hosting project.

#Getting started
---------------
### Installation
You'll need the following tools to get started:
* [Git](https://git-scm.com/downloads)
* [.NET Core 3.1 or later](https://dotnet.microsoft.com/download)

### Cloning, building and testing
Start by cloning this repo. Then navigate into the `/GridTariffApi` folder and start the application with `dotnet run`:
```shell
$ GridTariffApi> dotnet run	
```

Open your favorite browser, and navigate to [localhost:5000/swagger](http://localhost:5000/swagger). This should open [Swagger UI](https://swagger.io/tools/swagger-ui/), where you can try out the Api.

If you want to run the tests, navigate into the `/GridTariffApi.Lib` folder and run `dotnet test`:
```shell
$ GridTariffApi.Lib> dotnet test
```

### Authorizing Swagger UI
Swagger is configured for an Api using basic authentication.

#### Using basic authentication with Swagger UI
To authorize Swagger UI, you start by clicking on the "Authorize"-button. Then add the username and password and click "Authorize".


## Configuration
-------------
GridTariffApi.lib uses classes under the Config directory for containing configuration.
THese classes may be configured from appsettings.json, or any other mechanism.

## Azure Api Management.
GridTariff Api can be used as is with basic authentication.
GridTariff Api has also been successfully deployed with Azure Api Management in front.
Deployment was done using [Api Management Suite] (https://marketplace.visualstudio.com/items?itemName=stephane-eyskens.apim) , but other deployment strategies may also work.

