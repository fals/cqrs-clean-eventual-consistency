# ![Guaraci](docs/guaraci-icon.png) Clean Arquiteture CQRS with Derived Data  

CQRS, using Clean Architecture, multiple databases and Eventual Consistency

[![CodeFactor](https://www.codefactor.io/repository/github/fals/cqrs-clean-eventual-consistency/badge)](https://www.codefactor.io/repository/github/fals/cqrs-clean-eventual-consistency)
[![Build status](https://ci.appveyor.com/api/projects/status/github/fals/cqrs-clean-eventual-consistency?branch=master&svg=true)](https://ci.appveyor.com/project/fals/cqrs-clean-eventual-consistency)
[![codecov](https://codecov.io/gh/fals/cqrs-clean-eventual-consistency/branch/master/graph/badge.svg)](https://codecov.io/gh/fals/cqrs-clean-eventual-consistency)

## :floppy_disk: How do I use it?

Coming soon.

## :dart: Clean Architecture

>The strategy behind that facilitation is to leave as many options open as possible, for as long as possible. 
-Robin C. Martin

Clean Architecture has lots of different interpretations and implementations around. I've tried to implement CQRS with Clean in the best way to take advantage of the main concepts of this architectural pattern, making this microservice template flexible, maintainable, evolvable, testable, detached from technology and what I think as more important respecting the policy rule below:

>Source Code dependencies must point only inward, towards higher-level policy.

![cqrs-clean](https://github.com/fals/cqrs-clean-eventual-consistency/blob/master/docs/cqrs-clean.png)

This implementation brings as inner ring what I call **Core**, where you should implement you business rules, and keep the base of you microservice itself, such as: important interfaces, business entities, base classes, events. You're going to find that I'm using DDD here, with entities, aggregates, value objects and repository pattern. I've seem some implementations calling it Domain, but we shouldn't restrict this as a pattern name, because what we can have there is more than what the DDD pattern does, is the heart of the application itself. Also, even if CQRS and DDD are likely to be used together, you can implement your business the way you want and take advantage of what is more important in this sample, data intensive applications.

The next ring, which many implementations call it **Application** contains our Use Cases. CQRS has an strict way to implement these Use Cases, we have an stack responsible for dealing directly with your Business Entities, adding, updating or removing, residing inside **Command**. Those Use Cases that require reading data are inside **Query**, and also the ways to transform business entities to Derived Data format, which is more suitable for reading. Consider both layers **Application**, they are at the same level, but in different assemblies with different responsibilities. 

The **Infrastructure** is responsible strictly to keep technology. You can find there the implementations of repositories for business entities, message brokers, dependency injection and any other thing that represents a detail for Clean architecture, mostly framework dependent, external dependencies, etc.

The outer ring contains a way for users to communicate with our application, the **UI**. This layer can be anything which can read and write data. For this implementation I'm using ASP.NET as UI.

## :scissors: CQRS

Coming soon.

### :arrow_down: Command Stack

Coming soon.

### :arrow_up: Query Stack

Coming soon.

## :books: DDD

Coming soon.

## :heavy_check_mark: TDD

Coming soon.

## :bar_chart: Data Intensive Microservice

Coming soon.

## :page_facing_up: Derived Data

Coming soon.

## :envelope: Message Broker

Coming soon.

## :straight_ruler: Linearizability

Coming soon.

## :loop: Eventual Consistency

Coming soon.

## :clipboard: References

Here's a list of reliable information used to bring this project to life.

* <a href="https://www.amazon.com/Clean-Architecture-Craftsmans-Software-Structure/dp/0134494164" target="_blank">Clean Architecture, Robbin C. Marting</a>