# Task 2 (WebAPI, Autofac, AutoMapper)

This task will look at creating the endpoints and structuring of data contracts.

## 2.1

> N.B As part of this part of the task you will also need to create Data contracts in the DataContracts project

1. Create an endpoint for creating an event.
2. Create an endpoint for creating a group with people on a group with group relationships.
3. Create an endpoint for creating a role.
4. Also create a get endpoint each of these 3 classes.

## 2.2

1. Create domain services for each class type.
2. Create methods for saving and getting on those domain services.
3. Using Autofac and constructor injection, setup dependency injection for your new domain services on the web api controllers.

## 2.3

1. Using AutoMapper create mappings form the datacontracts to the domain model classes.
2. Create mappings for the Domain model classes to the Get DataContracts.
3. Use these mappings within your domain services to reduce code duplication in future.