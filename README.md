## About the architecture of application

I applied the Clean Architecture and Clean Code for building this application. Follow bellow the packages used.

- EntityFrameworkCore - Used for building an in Memory Database (InMemory extension) and for access the data using ORM. I prefered to use Entity than Dapper because last versions of entity are more flexible and fast than dapper.

- FluentValidation - Used for create validations of business and for implement the Notification Partner

- XUnit - Used for building the tests case (Tests only to simulate a project with tests)

## How to use/run the API

# Docker

- Install docker https://docs.docker.com/get-docker/ and docker-compose https://docs.docker.com/compose/install/

- After install, clone this repository

- Access the repository folder and executing the command: docker-compose up -d

- Access the path in your browser: http://localhost:5236/swagger

# Executing the application without Docker

- Install the .NET SDK 8 https://dotnet.microsoft.com/en-us/download/dotnet/8.0

- Install Visual Studio or Visual Studio Code 

- Execute the application using **dotnet run RealEstateListing.Api**

# Improvements

- Generate Listing Id using the entityframework (Identity column) 

- Added any stack to monitoring this application even in the early stage (Datadog, Elastic Stack, New Relic and etc..)