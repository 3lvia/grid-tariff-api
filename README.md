GridTariff API
=========
GridTariff API is an API intended for use by Norwegian Electrical Grid Utility companies.
GridTariff API exposes the following services:

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

## Most important datbase tables used by GridTariff API
Script for creating SQL Server database and sample data exists in folder 'SQL' in the solution.

### Table 'tarifftype'
This table contains all tariffs

### Table 'fixedpriceconfig'
This table contains fixed price element for tariffs.
Fixed prices is specified as the fixed price for a given month.
(The API will calculate fixed price element per hour based on total amount of hours for a given month).
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

### Kunde.TariffAPI\Auth
Classes related to (basic) authentication of API.

### Kunde.TariffAPI\Config
Classes for containing configuration.

### Kunde.TariffAPI\Controllers
Controllers for exposed API services.

### Kunde.TariffAPI\EntityFramework
Entity framework for database.

### Kunde.TariffAPI\Models
Object models userd by API services.

### Kunde.TariffAPI\Services
Services containing logic used by Controllers.
Abstraction of Configurarition.
Abstraction of Logging.

### Kunde.TariffAPI\SQL
Scripts for creating database,tables and sample data.

### Kunde.TariffAPI\Swagger
Classes related to Swagger.

#Getting started
---------------

### Installation
You'll need the following tools to get started:
* [Git](https://git-scm.com/downloads)
* [.NET Core 3.1 or later](https://dotnet.microsoft.com/download)

### Cloning, building and testing
Start by cloning this repo. Then navigate into the `/Kunde.TariffApi` folder and start the application with `dotnet run`:
```shell
$ Kunde.TariffApi> 	
```

Open your favorite browser, and navigate to [localhost:5000/swagger](http://localhost:5000/swagger). This should open [Swagger UI](https://swagger.io/tools/swagger-ui/), where you can try out the API.

If you want to run the tests, navigate into the `/Kunde.TariffApiTests` folder and run `dotnet test`:
```shell
$ Kunde.TariffApiTests> dotnet test
```

### Authorizing Swagger UI
GridTariff API is authorizing users using basic authentication, so before using Swagger UI to test out any other request than /ping, you'll need to authorize Swagger UI. In order to do this, you need basic authentication username and password.

#### Using basic authentication with Swagger UI
To authorize Swagger UI, you start by clicking on the "Authorize"-button. Then add the username and password and click "Authorize".


## Configuration
-------------
GridTariff API uses appsettings.json for configuration variables.
Alternative source of configuration can be implemented by implementing interface IConfigHandler and extending class GridTariffApiConfigFactory.
There exists two different ways to specify override of default appsettings.json configuration.
1. Set value AlternativeSource in appsettings.json
2. Set OS environment variable alternativeSource

### Development configuration
If you wish to override any of the configuration when developing, create a new file in `/Kunde.TariffApi` called `appsettings.Development.json`, and copy the contents of [Kunde.TariffApi/appsettings.json](Kunde.TariffApi/appsettings.json) into this file.

## Logging
Logging to vanilla Azure Application Insights is supported.
Alternative implementation of logging can be implementetd by extending LoggingHandler.

### SwaggerSettings
**UseSwaggerUI** is a boolean that determines whether or not Swagger UI is served by GridTariff API.

## Azure API Management.
GridTariff API can be used as is with basic authentication.
GridTariff API has also been successfully deployed with Azure API Management in front.
Deployment was done using [API Management Suite] (https://marketplace.visualstudio.com/items?itemName=stephane-eyskens.apim) , but other deployment strategies may also work.

## Other 
Solution includes the following two nuget packages mantained by Elvia AS.
* Elvia Configuration
* Elvia Telemetry
These nuget packages deal with configuration values and logging.
These are not needed if using appsettings.json for configuration/vanilla Azure Application Insights, or if alternative configuration source/logging has been implemented.

