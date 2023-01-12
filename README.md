# Welcome to User Operations with gRpc

Hi! I've written the code to have some basic CRUD operation using google remote procedure call and it is being consumed in the API with some end points.


# Basic KT

 - Create a gRPC project in Visual studio
 - Create a DB context with your Database table.
 - Create Entities(for Database)
 - Create a repository folder and add Interface and class accordingly.
 - Create the Proto file with all User operation
 - Override proto methods in gRPC service class and call the repository class's methods.
 - Register your gRPC service in Program.cs
	 - app.MapGrpcService<UserService>();
 -  Create a API project
 - Give the connected service reference of your Proto file
 - Make one gRPC service setting in appsettings and put the service URL
 - Consume the gRPC service methods in API end point and then you're good to go!
