# Dezrez Rezi BE Training
Project designed with helping to understand the core concepts behind the technologies used in Rezi and
also within a context similar to that which we use.

## Installation
Git clone the repo from url:

`git clone https://dezrez-be-training.visualstudio.com/_git/Dezrez.Rezi.Training`

Username: marc.harry@dezrez.com
Password: Dezrez2016

Open in VS2013 or above and build, n.b. you might need to turn on 'Enable nuget package restore'

You will need SQL Server to be installed on localhost and to create a db on there called 'DezrezBETraining'

## Layout
The project is designed to be in a layout similar to that of the Rezi BE project. It has of course been slimed
down for the purposes of training.

It targets these areas of rezi:-
1. Domain Model
2. AutoMapper
3. ASP.NET Web API 2
4. NHibernate
5. Autofac
6. Repository and UnitOfWork Pattern

Feel free to do more reading around those areas and we also use in the full Rezi solution:-
* ElasticSearch.NET with NEST
* MS Azure Service Bus
* Azure Worker Roles (JobHandlers)
* Azure Document Storage (Blob Storage)
* Redis
* FluentMigrator (NHibernate Schema Changes/Similar to Entity Framework Migrations)

## Using the api

Once your set up you can use the existing endpoints or newly created ones through tools such
as Postman.
The project currently runs on localhost with port 59199.

Example Api Url: [http://localhost:59199/api/person](http://localhost:59199/api/person)

## Contributing
1. Clone it!
2. Create your own branch: `git checkout -b {your-name}`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin {your-name}`
5. Joint code review

Or working in teams on a branch for group of you working together as this would be how it would happen in the team.

## Credits
Written and Developed by Marc Harry
