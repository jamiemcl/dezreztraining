# Task 4 (NHibernate)

Sticking with NHibernate however focusing on Interceptors.

## 4.1

1. Modify the `BasicInterceptor` to override the OnFlushDirty method. (N.B. This is called whenever a property is changed or updated on an object at commit to the DB)
2. Extend the `BaseEntity` class to have an UpdatedDate property.

## 4.2
1. Using both the OnSave and OnFlushDirty methods determine if an object is being created or updated and set the relevant date property of that object.
2. Override `AfterTransactionCompletion` and for now just log to the debugger a message.