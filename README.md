# CodingPrac

## Introduction to RLB Concepts. Current systems

In order to think clearly abotu what software projects in RLB are intended to achieve. It makes sense to start with an especially simple model and then to increase the complexity progressively to understand which features in the application suite are the most valuable. We can start off that process by outlining the software solutions currently under maintenance or development. THese include the following: 
* ROSS 5D for building up and elaborating upon Estimates of Construction Projects using first principles
* RLB OData and Analytics: Power BI integrations for single project analytics - using the ROSS5D system as the data source (mostly pre-contract analysis)
* RLB Pulse: Post Contract Management of Construction Projects for Quantity Surveyors and Project Managers
* ROSS Classic: A legacy system equivalent to RLB Pulse but designed for Quantity Surveyors.
* Global Benchmarking: Post-Construction Project Search and Analysis (cuurently an ICMS model)

A client could engage with RLB at any and all stage of the project. A client is generally the funder of the project.

Currently each solution proposes a different project model (albeit with some distinct similarities). Nonetheless, each solution is project driven with minimal sharing between projects (other than versions of the same project).

In general, the basis is often cost accounting, management and estimation of a construction project which means that the nomenclature shares between accountancy and construction. Project management adds the complexity of managing timelines of work, changes and payments which is the cause of several divergences between the models.

As a side note, the ICMS standard attempted to create a single universal model to describe the entire construction lifecycle. Adoption has been limited thus far.

## Domain Models

## A Software Developer's approach.

A software developer is generally comfortable with text based interfaces. So one 

## RLB CodingPrac

The following repository represents a basic setup of an RLB project. It includes an n-tier project in dotnetCore with the client-facing application represented by an Angular web application which points to a dotnetCore API.

Currently the solution demontstrates a Domain Model with some sample repository setup. Repository work is provided through the Dapper ORM and Dapper.Contrib.Extensions. The project currently works off a local SQLLite database.

The Application comprises of other projects including:
* Data Access Layer for models, repositories and data access contracts
* Business logic layer for Common Access Work and Calculations.
* API and UI: a n all-in-one angular and API Project
* An XUnit test project for everthing.

The project is intended to be entirely open to allow various interpretations to common problems.
