GridTariff API
=========
_API for retrieving tariffs ([kunde-tariff-api](https://github.com/3lvia/kunde-tariff-api)). Visit [Swagger UI in dev](https://kunde.dev-elvia.io/tariff-api/swagger/index.html) for more information about resources and schemas._

| Build Pipeline | Dev Release | Test Release | Prod Release |
| -------------- | ----------- | ------------ | ------------ |
| [![Build Status](https://dev.azure.com/3lvia/kunde/_apis/build/status/kunde-portal-api?branchName=trunk)](https://dev.azure.com/3lvia/kunde/_build/results?buildId=13447&view=results) | [![Dev Status](https://vsrm.dev.azure.com/3lvia/_apis/public/Release/badge/971f9125-7038-4151-8cc9-a914ea10cd85/2/11)](https://dev.azure.com/3lvia/kunde/_release?_a=releases&view=mine&definitionId=15) | [![Test Status](https://vsrm.dev.azure.com/3lvia/_apis/public/Release/badge/971f9125-7038-4151-8cc9-a914ea10cd85/2/3)](https://dev.azure.com/3lvia/kunde/_release?_a=releases&view=mine&definitionId=15) | [![Prod Status](https://vsrm.dev.azure.com/3lvia/_apis/public/Release/badge/971f9125-7038-4151-8cc9-a914ea10cd85/2/5)](https://dev.azure.com/3lvia/kunde/_release?_a=releases&view=mine&definitionId=15) |

Getting started
---------------

### Installation
You'll need the following tools to get started:
* [Git](https://git-scm.com/downloads)
* [.NET Core 3.1 or later](https://dotnet.microsoft.com/download)

### Cloning, building and testing
Start by cloning this repo. Then navigate into the `/Kunde.TariffApi` folder and start the application with `dotnet run`:
```shell
$ Kunde.TariffApi> dotnet run
```

Open your favorite browser, and navigate to [localhost:5000/swagger](http://localhost:5000/swagger). This should open [Swagger UI](https://swagger.io/tools/swagger-ui/), where you can try out the API.

If you want to run the tests, navigate into the `/Kunde.TariffApiTests` folder and run `dotnet test`:
```shell
$ Kunde.TariffApiTests> dotnet test
```

### Authorizing Swagger UI
GridTariff API is authorizing users using basic authentication, so before using Swagger UI to test out any other request than /ping, you'll need to authorize Swagger UI. In order to do this, you need basic authentication username and password.

#### Retrieving basic authentication username and password
Basic authentication username and password is stored in Hashicorp vault. As an example username and password for dev environment can be retrievede[here] (https://vault.dev-elvia.io/ui/vault/secrets/kunde%2Fkv/show/nett-tariff-api)

#### Using basic authentication with Swagger UI
To authorize Swagger UI, you start by clicking on the "Authorize"-button. Then add the username and password and click "Authorize".

Environments with Swagger UI:
* Dev: [kunde.dev-elvia.io/tariff-api/swagger/](https://kunde.dev-elvia.io/tariff-api/swagger/index.html)
* Test: [kunde.test-elvia.io/tariff-api/swagger/](https://kunde.test-elvia.io/tariff-api/swagger/index.html)


Configuration
-------------

### Development configuration
If you wish to override any of the configuration when developing, create a new file in `/Louvre.ImageImportAPI` called `appsettings.Development.json`, and copy the contents of [Louvre.ImageImportAPI/appsettings.json](Louvre.ImageImportAPI/appsettings.json) into this file.

Any setting in `appsettings.Development.json` will override the settings in `appsettings.json`, but `appsettings.Development.json` is ignored by git, so you're less likely to check in secrets to source control. If secrets ever are checked in by accident, the most important thing is not to try to gloss over the accident. Instead you should:
1. [Rotate the exposed secrets](https://hafslundnett.atlassian.net/wiki/spaces/ISOA/pages/1469481180/Rullering+av+hemmeligheter?atlOrigin=eyJpIjoiYzI1Y2U2NjE3MDlhNGEzNWIxOGNmMmQ4OWYxMGMwYmQiLCJwIjoiYyJ9). Talk to your team or the core-team if you're uncertain about how to do this.
2. Determine the severity of the potential breach caused by exposing the secrets. You'll want to consider how the secret was exposed, how long it was exposed, and what kind of data could be accessed by an attacker using the secret. Usually the severity will be less severe, since the secret might have been only exposed in a private repo for a short while, giving access to only test-data, but this is not always the case. It's usually easier to determine the severity by discussing with your team, or another developer.
3. Depending on the severity of the breach, you should consider reporting it to head of IT security (sikkerhetsansvarlig). If you're uncertain about whether or not you should report a security incident, you should probably report it.

### SwaggerSettings
**UseSwaggerUI** is a boolean that determines whether or not Swagger UI is served by ImageImport API. It is currently configured to be true in dev and test, but should be false in prod, to avoid unintentional changes to production data.

**PathPrefix** Is a URL-prefix used when serving the Open API specification from behind an ingress, or another proxy that rewrites the URL using a base path. When running locally, it should be set to `""`. When deployed to Kubernetes, PathPrefix should correspond to `path`-value in the ingress.
