# CodingPrac
# RLB CodingPrac

The following repository represents a basic setup of an RLB project. It includes an n-tier project in dotnetCore with the client-facing application represented by an Angular web application which points to a dotnetCore API.

Currently the solution demontstrates a Domain Model with some sample repository setup. Repository work is provided through the Dapper ORM and Dapper.Contrib.Extensions. The project currently works off a local SQLLite database.

The Application comprises of other projects including:
* Data Access Layer for models, repositories and data access contracts
* Business logic layer for Common Access Work and Calculations.
* API and UI: a n all-in-one angular and API Project
* An XUnit test project for everthing.

The project is intended to be entirely open to allow various interpretations to common problems.
