# Task 3 (NHibernate)

This task turns our focus back onto NHibernate and specifically the repositories.

## 3.1

1. Create a new repository in the Repository project called `GroupRepository`
2. Using NHibernate ICriteria create a query to search for groups with an email address that matches a search term passed to the repository.

## 3.2
1. Create an Interface for this new repository and inject it into your `GroupDomainService`
2. Using your new repository create a method to get a group by email address.
3. Surface this new domain service method by added a new web api endpoint to get a group by taking an email address in `GET` query string.

