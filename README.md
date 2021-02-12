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

A software developer is generally comfortable with text based interfaces. So one could:

* git checkout -b 380-St-Kilda-Road-Estimate
* git checkout -b 380-St-Kilda-Road-Estimate-initial 

* Create a new tempalte file (in json or xml)
`rlb create project --type RLBPulse --name '380 St Kilda Road'`

* Edit the json / xml file 380-st-kilda-road.xml
```
<Project type="Estimate" OrgUnitId="1" name="380 St Kilda Road">
   <Funder Id="1" Name="PDG">
   <ReportingPeriods>
      <period id="1" startDate="2020-01-01" endDate="2020-31-01" status="Active" />
   </ReportingPeriods>
   <CostCategories>
      <Category ID="1" Name="Foundations" CurrentValue="100000.00" startActivity="" endActivity="" cashflowCurve=""
   </CostCategories>
   <Acitivities />
   <Periods />
</Project>
```

* Compile and Validate Project
`rlb compile 380-st-kilda-road.xml` > 380-st-kilda-road.compiled.xml

* Which would tell you validation issues - like "cannot create payapp unless contract is approved"
* On successful compile, we could run
`rlb calculate 380-st-kilda-road.compiled.xml`

* This would create a file 380-st-kilda-road.calculated.xml

* Then build reports:
`rlb build 380-st-kilda-road.calculated.xml`
* Which which generate a full suite of reports for the client.

* Upload proposed changes
`git add / commit`

* Create a pull request for a senior user to review and approve the pull request

* Latest reports are sent online with latest models.

## Current QS Approach
An Excel spreadsheet with sheets for (RLB Pulse Project:
* Project Details and top level calulcations
* Forecast
* Cost Categories
* Contracts
* Contract Items (all in 1 sheet but references to contract)
* PayApps (all in 1 sheet but references to contract). Contingency included. Could Also be linked to Contract Item
* Change registrar (All contracts)
* Cashflow - maybe

Alternatively, there may be one excel file per contract. 
* NB: Lots of calculations between sheets.
* NB2: No formal validation
* Revision Control based on File naming conventions or maybe metadata.
* Potentially with imports from other software like Microsoft Project.


## RLB CodingPrac

The following repository represents a basic setup of an RLB project. It includes an n-tier project in dotnetCore with the client-facing application represented by an Angular web application which points to a dotnetCore API.

Currently the solution demontstrates a Domain Model with some sample repository setup. Repository work is provided through the Dapper ORM and Dapper.Contrib.Extensions. The project currently works off a local SQLLite database.

The Application comprises of other projects including:
* Data Access Layer for models, repositories and data access contracts
* Business logic layer for Common Access Work and Calculations.
* API and UI: a n all-in-one angular and API Project
* An XUnit test project for everthing.

The project is intended to be entirely open to allow various interpretations to common problems.
