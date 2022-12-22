dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Pomelo.EntityFrameworkCore.MySql  

dotnet tool install -g dotnet-ef
dotnet tool update -g dotnet-ef
dotnet ef migrations add InitialCreate
