# ReadingIsGood-DotNETApplication

Please see wiki for details:
https://github.com/addu143/ReadingIsGood-DotNETApplication/wiki

## Brief explanation of Design <br><br>
This application build on the Clean Architecture, hence its layers are loosely copuples and can be tested independendly. 
and later we can change the database e.g. EF/SQL to any other DB provider. I believe still its need some imrovements, suggestions are open :)

## TechStack <br><br>
1. .NET 5.0 Core
2. EntityFramework Core
3. ASP Identity
4. Docker Container
5. SQLlite
6. AutoMapper
7. Swagger

## Access Endpoints
Application is deployed on Azure on the following link and APIs can be tested on. <br> But you need to Register first and get a token to access other APIs endpoints :)
**You can access the Logging endpoint (without authentication) anytime and see what is happening behind the scenes**
https://readingisgood.azurewebsites.net/swagger/index.html

## Application Flow
1. User will Register 

