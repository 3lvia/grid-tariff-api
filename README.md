## Grid-Tariff-Api

Grid-Tariff-Api is an implementation of "Nettariff API" specified by DiginEnergi.

"Nettariff-API" is a specification for an API which purpose is to serve information regarding electrical grid tariffs including prices per hour.

DiginEnergi is a Norwegian consortium working with information models and standards related to the national electricity grid of Norway.  

"Nettariff-API" specification is available for download from github [here](https://github.com/digin-energi/API-nettleie-for-styring)  
Further information regarding DiginEnergy is available [here](https://diginenergi.no/hva-gjor-vi/nettariff-api/) (in Norwegian).  

Please read and adhere to [terms and conditions ](https://diginenergi.no/hva-gjor-vi/nettariff-api/) (in Norwegian)

## The following endpoints is available
#### Retrieve list of available tariffs
Returns a list of available tariffs

#### Query a tariff for prices per hour for a given timeperiod
Returns prices per hour for the given tariff for the given timeperiod.

####  Query prices per hour for a list of meteringpoints for a given timeperiod
Returns prices per hour for given timeperiod for the unique tariffs connected to the list of meteringpoints.  
Each tariff contains a list of meteringpoints using the tariff.  
Attached to each meteringpoint is a reference to a fixedpricelevel which currently applies to the meteringpoint.  
The reference to fixedpricelevel is deduced by max consumption (kWh) for the meteringpoint for the current month.


## Overview of projects in solution

#### GridTariffApi.lib
Implementation of the API.

#### GridTariffApi.lib.Tests
Unit tests for the implementation of the API.

#### GridTariffApi (Elvia Specific)
Project for hosting the API.
The purpose of this project is to handle everything regarding setup, hosting and security of the API.  
Anyone wanting to utilize GridTariffApi.lib for implementing "Nettariff-API" is required to write their own project for hosting the API.  
This particual implementation is used by Elvia AS.  
 

#### Project GridTariffApiSynchronizer.lib (Elvia Specific)
Not needed for GridTariffApi.lib.  
The project is Elvia AS specific and is responsible for synchronizing meteringpoints and their relation to grid tariffs.  
It is only used for an earlier version of the API not specified by DiginEnergi.  
This project is to be phased out at a later time.

#### Project GridTariffApiSynchronizer.libTests (Elvia Specific)
Unit tests for project GridTariffApiSynchronizer.lib


## Project GridTariffApi.lib folders

All folders with name "Pilot" is related to an earlier version of the API not specificed by DiginEnergi.  
The content of these folders is not needed for the implementation of API specified by DiginEneregi.  
These folders are scheduled for removal.

#### Config
Contains classes for configuration of the project.

#### Controllers
Contains controllers for the offered functionality  
Subfolder v1 containts controllers for the "Nettariff-API" specified by DiginEnergi.  
Subfolder Pilot is to be removed, it is an earlier version of the API not specified by DiginEnergi.

#### EntityFramework (Elvia Specific)
Contains Entity Framework classes for database persisting tariff information.  
The content of this project is only used by an earlier version of the API not specified by DiginEnergi.  
It is to be phased out at a later time

#### Interfaces
Interfaces used by GridTariff.lib to fetch data.  
These are to be implemented by anyone wanting to use GridTariff.lib.

#### Models 
Contains classes for request/response objects used by controllers,  
Subfolder Pilot is to be removed, it is related to an earlier version of the API not specified by DiginEnergi.

#### Services
Contains classes with business logic used by controllers
Subfolder Pilot is to be removed, it is related to an earlier version of the API not specified by DiginEnergi

####  SQL
This folder is to be removed, it is related to an earlier version of the API not specified by DiginEnergi

#### Swagger
Contains classes related to documentation of Api.


## Overview of solution folders

#### CI
Sample build/deployment files.  
These project is native to Elvia.

#### Solution Items 
Contains this file.  
Contains Dockerfile native to Elvia.

## Getting started

#### Installation
You'll need the following tools to get started:
* [Git](https://git-scm.com/downloads)
* [.NET Core 3.1 or later](https://dotnet.microsoft.com/download)

###### Cloning, building and testing
Start by cloning this repo.  
Then navigate into the `/GridTariffApi` folder and start the application with `dotnet run`:
```shell
$ GridTariffApi> dotnet run	
```
Note that API will fail at startup outside Elvia environment.  
This is due to project GridTariffAPI is using Elvia-specific components.
See paragraph [GridTariffApi](#gridtariffapi-elvia-specific) for details.

If you want to run the tests, navigate into the `/GridTariffApi.Lib` folder and run `dotnet test`:
```shell
$ GridTariffApi.Lib> dotnet test
```

## Configuration
-------------
GridTariffApi.lib uses classes under the Config directory for containing configuration.  
These classes may be configured from appsettings.json, or any other mechanism.

## Azure Api Management.  
GridTariff Api has been successfully deployed with Azure Api Management in front.

Deployment was done using [Api Management Suite] (https://marketplace.visualstudio.com/items?itemName=stephane-eyskens.apim) , but other deployment strategies may also work.

