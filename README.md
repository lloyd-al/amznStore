# amznStore

Build Amazon Clone e-commerce website using ASP.NET core and ReactJS based on Microservice Architecture.
Other tool stack include Docker, RabbitMQ, Ocelot API Gateway, Atlas MongoDB, Redis, SqlServer.

**Frontend application built using ReactJS**
State Management using Redux, Thunk, Saga, Reselect, Hooks \
Local Storage using Persist \
API Calls using Axios \
Logging using Logger

![plot](./Documents/amznStore_UI.PNG)

## Architecture

The overall project is based on microservice architecture. APIs build based on Onion Architecture\
Authentication using IdentityServer4

![plot](./Documents/amznStore.png)

## Common Library

All your files and folders are presented as a tree in the file explorer. You can switch from one to another by clicking a file in the tree.

### Common -> Core

> Install-Package Microsoft.AspNetCore.Http

### Common -> Infrastructure

> Install-Package Microsoft.EntityFrameworkCore

> Install-Package MailKit

> Install-Package Microsoft.AspNetCore.Mvc.Versioning

> Install-Package Microsoft.AspNetCore.Mvc.Versioning.ApiExplorer

> Install-Package Microsoft.AspNetCore.Mvc.ApiExplorer

> Install-Package Swashbuckle.AspNetCore

> Install-Package Serilog

#

## ApiGateway

### ApiGateway.Web
> Install-Package Ocelot

#

## Product Catalog Service

**MongoDB Set-up for the Catalog Database**
Use [MongoDB Cloud](https://www.mongodb.com/cloud) to create Catalog Database

### Services -> Catalog -> Catalog.Core**

> Install-Package MongoDB.Driver

> Install-Package MongoDB.Bson


### Services -> Catalog -> Catalog.Infrastructure
> Install-Package ServiceStack

> Install-Package Microsoft.Extensions.Configuration

> Install-Package MongoDB.Driver

### Services -> Catalog -> Catalog.Application
> Install-Package AutoMapper

> Install-Package Microsoft.Extensions.DependencyInjection

> Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection

### Services -> Catalog -> Catalog.Api
> Install-Package AspNetCore.HealthChecks.MongoDb

> Install-Package Swashbuckle.AspNetCore

> Install-Package Serilog

> Install-Package Serilog.Extensions.Logging

> Install-Package Serilog.Extensions.Hosting

> Install-Package Serilog.Settings.Configuration

> Install-Package Newtonsoft.Json

> Install-Package Microsoft.AspNetCore.Mvc.NewtonsoftJson

> Install-Package Microsoft.AspNetCore.Authentication.JwtBearer

### Services -> Catalog -> Catalog.Test
> Install-Package FluentAssertions

> Install-Package Microsoft.AspNetCore.Mvc.Testing

> Install-Package RESTFulSense

### Services -> Catalog -> Catalog.Test
> Install-Package FluentAssertions

> Install-Package Microsoft.AspNetCore.Mvc.Testing

> Install-Package RESTFulSense

### Services -> Basket -> Basket.Core
> Install-Package StackExchange.Redis

### Services -> Basket -> Basket.Infrastructure
> Install-Package Microsoft.EntityFrameworkCore

> Install-Package Microsoft.Extensions.Configuration

> Install-Package Newtonsoft.Json

> Install-Package StackExchange.Redis

### Services -> Basket -> Basket.Application
> Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection

### Services -> Basket -> Basket.API
> Install-Package Microsoft.Extensions.Caching.StackExchangeRedis

> Install-Package Serilog

> Install-Package Serilog.Extensions.Logging

> Install-Package Serilog.Extensions.Hosting

> Install-Package Serilog.Settings.Configuration

> Install-Package Newtonsoft.Json

> Install-Package Microsoft.AspNetCore.Mvc.NewtonsoftJson

> Install-Package Microsoft.AspNetCore.Authentication.JwtBearer

> Install-Package Microsoft.AspNetCore.Mvc.Versioning

> Install-Package AutoMapper

> Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection

> Install-Package Microsoft.AspNetCore.Authentication.OpenIdConnect

### Services -> Discount -> Discount.Core
> Install-Package Microsoft.Extensions.Configuration

> Install-Package Npgsql

> Install-Package Dapper

### Services -> Discount -> Discount.Api
> Install-Package Microsoft.AspNetCore.Mvc.Versioning

> Install-Package Serilog

> Install-Package Serilog.Extensions.Logging

> Install-Package Serilog.Extensions.Hosting

> Install-Package Serilog.Settings.Configuration

> Install-Package Newtonsoft.Json

> Install-Package Npgsql

> Install-Package Dapper

### Services -> Discount -> Discount.Grpc
> Install-Package Serilog

> Install-Package Newtonsoft.Json

> Install-Package Npgsql

> Install-Package Dapper

> Install-Package Polly

> Install-Package AutoMapper

> Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection

> Install-Package Grpc.AspNetCore

### Services -> Ordering -> Ordering.Infrastructure
> Install-Package Microsoft.EntityFrameworkCore

> Install-Package Microsoft.EntityFrameworkCore.SqlServer

> Install-Package Microsoft.EntityFrameworkCore.Tools

> Install-Package Microsoft.Extensions.Configuration

> Install-Package Microsoft.Extensions.Options

> Install-Package Newtonsoft.Json

### Services -> Ordering -> Ordering.Application
> Install-Package AutoMapper

> Install-Package AutoMapper.Extensions.Microsoft.DependencyInjection

> Install-Package FluentValidation

> Install-Package FluentValidation.DependencyInjectionExtensions

> Install-Package MediatR

> Install-Package MediatR.Extensions.Microsoft.DependencyInjection

> Install-Package Microsoft.Extensions.Options

## Client -> WebStore
> npm install @material-ui/core --save

> npm install @material-ui/lab --save

> npm install @material-ui/icons --save

> npm install react-flags-select --save

> npm install react-icons --save

> npm install redux react-redux redux-logger redux-thunk --save

> npm install reselect --save

> npm install redux-persist --save

> npm install redux-saga --save

> npm install axios --save

> npm install formik --save

> npm install yup --save

> npm install rxjs --save
 
> npm install react-currency-format --save
