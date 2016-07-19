# Task 1 (NHibernate)

This task is designed at getting you use to creating domain model objects and configuring
NHibernate to use the correct relationships between objects. You should have by the end of this
objects utilising:
* One-to-one relationship
* One-to-many relationship
* Many-to-many relationship

Thoughout this task structure the classes using namespaces within the Domain project as you see fit/makes sense to you.

N.B. Remember all objects that are to be stored in the database need to derive from `BaseEntity`.

>Be Aware - In the class `AppConfig.cs` there is code designed to update the DB schema everytime the Web API starts it looks like this:
```C#
    var dbConfig = container.Resolve<IDatabaseConfig>();
    dbConfig.UpdateDbSchema();
```
>Comment this out if you want to prevent DB Schema changes whilst you refine your domain model. Or change it to `dbConfig.CreateDbSchema();` to wipe the DB and recreate from the current domain model schema.

## 1.1

1. Create `Event` class
2. Create `Role` class
3. Create `Group` class

## 1.2

1. Create a many to many relationship between Events and Roles
  * Create list of roles and events on each others classes
  * Create ManyToMany mapping in Repository/Mappings/{Name of MappingClass}.cs 
2. Create a new class called `GroupPerson`.
3. Create an enum called `GroupPersonRelationshipType`
  * Add properties to this enum called GroupMember, PrimaryMember.
4. Setup propeties on the `GroupPerson` class to include the previously mentioned enum, the `Group` and the already existing `Person` class.
5. Create list of `GroupPerson` on the `Group`.

## 1.3

1. Create class called `ContactDetail`
2. Add property to person for this new class.
3. On `ContactDetail` class added Email and Phone number