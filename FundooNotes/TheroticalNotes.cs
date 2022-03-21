
//What is Api

//Api is an abbreviation for Application Program Interface.
// It is a code that allows communication between two software programs.
// It delivers a request from the source to the destination and then brings back the response to the source. 
//it transfers the data between the two systems.
//It is comprised of related elements.
//It can be viewed as a set of rules and tools which are used to design various softwares.
//It is used in procedural languages, object-oriented languages, frameworks, etc.
//The most common APIs are REST API and SOAP API.
//Though APIs are designed using a number of techniques, among them,
//one is done using information hiding by dividing the software into multiple modules wherein each has a unique interface. 
//A real-time example of an API is booking a flight. 

//Advantages: 
//APIs are of great use because without writing the complete code themselves, they can add specifications to the application.
//APIs can be used to access data from applications.
//APIs are useful for customizing and enhancing applications.
//These ensure high speed of functioning of the application
//Data sharing becomes easier.

//Disadvantages: 
//Being a gateway, it is most vulnerable to be hacked.
//Once it is hacked, other applications in the system are automatically prone to threat.
//System can crash during the testing of an API
//Maintenance of an API is difficult
//Providing an API is expensive , so its cost is too high.

//as we know that there are various techniques to create Api but our main focus is RESTAPI and soap

//what is RESTAPI

//REpresentational State Transfer (REST)
//is an architectural style that defines a set of constraints to be used for creating web services.
//REST API is a way of accessing web services in a simple and flexible way without having any processing.
//REST technology is generally preferred to the more robust Simple Object Access Protocol (SOAP) technology
//because REST uses less bandwidth, simple and flexible making it more suitable for internet usage.
//It’s used to fetch or give some information from a web service.
//All communication done via REST API uses only HTTP request. 
//basically CRUD opreations we perform on RESTAPI
//A request is send to server through a http request from client and in result we get HTML, XML, Image or JSON.
//But now JSON is the most popular format being used in Web Services. 
//Idempotence is neccessary here
//An idempotent HTTP method is a HTTP method that can be called many times without different outcomes.
//It would not matter if the method is called only once, or ten times over.
//The result should be the same.
//Again, this only applies to the result, not the resource itself.

//Difference between REST API and SOAP API
//SOAP stands for Simple Object Access Protocol and REST stands for REpresentational State Transfer.
//Since SOAP is a protocol, it follows a strict standard to allow communication between
//the client and the server whereas REST is an architectural style that doesn’t follow any strict standard
//but follows six constraints  Those constraints are – Uniform Interface, Client-Server, Stateless, Cacheable, Layered System, Code on Demand.

//SOAP uses only XML for exchanging information in its message format
//whereas REST is not restricted to XML and its the choice of implementer which Media-Type to use like XML, JSON, Plain-text.
//Moreover, REST can use SOAP protocol but SOAP cannot use REST.

//On behalf of services interfaces to business logic, SOAP uses @WebService whereas REST instead of using interfaces uses URI like @Path.

//SOAP is difficult to implement and it requires more bandwidth
//whereas REST is easy to implement and requires less bandwidth such as smartphones.
//Benefits of SOAP over REST as SOAP has ACID compliance transaction. Some of the applications require transaction ability which is accepted by SOAP whereas REST lacks in it.
//On the basis of Security, SOAP has SSL( Secure Socket Layer) and WS-security whereas REST has SSL and HTTPS.
//In the case of Bank Account Password, Card Number, etc.
//SOAP is preferred over REST.
//The security issue is all about your application requirement,
//you have to build security on your own. It’s about what type of protocol you use.

//What is the differnce between .NET framework and .NET core 
//The .NET Framework
//supports Windows and Web applications.
//Today, you can use Windows Forms, WPF, and UWP to build Windows applications in .NET Framework.
//ASP.NET MVC is used to build Web applications in .NET Framework.

//what is UWP
//Universal Windows Platform
//is a computing platform created by Microsoft and first introduced in Windows 10.
//The purpose of this platform is to help
//develop universal apps that run on Windows 10, Windows 10 Mobile, Windows 11, Xbox One, Xbox Series X/S and HoloLens
//without the need to be rewritten for each.

//The .Net core
//is the new open- source and cross-platform framework
//to build applications for all operating systems including Windows, Mac, and Linux.
//.NET Core supports UWP and ASP.NET Core only.
//UWP is used to build Windows 10 targets Windows and mobile applications.
//ASP.NET Core is used to build browser-based web applications. 

//what is webapi controller
//It handles incoming HTTP requests and send response back to the caller.
//Web API controller is a class which can be created under the Controllers folder or any other folder under your project's root folder.
//The name of a controller class must end with "Controller" and it must be derived from System.Web.Http.ApiController class.
//All the public methods of the controller are called action methods.

//Role of Startup.cs class in Asp.net core web api project
//startup class called first when application run.
//Startup class includes two public methods:
//ConfigureServices and Configure.

//ConfigureServices Method Role
//The ConfigureServices method is a place where you can register your dependent classes
//with the built-in IoC container.
//After registering dependent class, it can be used anywhere in the application.
//You just need to include it in the parameter of the constructor of a class where you want to use it.
//The IoC container will inject it automatically.

//Configure Method Role 
//Method called at run time
//Method configure http request pipeline.
//the Configure method includes three parameters IApplicationBuilder, IHostingEnvironment, and ILoggerFactory
//by default. These services are framework services injected by built-in IoC container.

// Role of controller classes
// it must be raised under controller folder 
//classes in controller folder derived from system.web.http.apicontroller
//it have all the apis that are going to be work when an http request trigered.
//apicontroller detect it self which api is to be triggred based on the http verbs

//what is IOC
//abbrebriation of Inversion of Control
//it is a design principal which main focus is to achieve loosely coupling between classes by using object oriented principal
//control refers to any additional responsibilities a class has, other than its main responsibility,
//such as control over the flow of an application, or control over the dependent object creation and binding 

//what is DIP(Dependency Inversion Principle)
//The DIP principle also helps in achieving loose coupling between classes.
//It is highly recommended to use DIP and IoC together in order to achieve loose coupling.
//DIP suggests that high-level modules should not depend on low level modules.
//Both should depend on abstraction.

//what is DI(Dependency Injection)
//Dependency Injection (DI) is a design pattern
//which implements the IoC principle to invert the creation of dependent objects.
//It allows the creation of dependent objects outside of a class and provides those objects to a class
//through different ways.
//Using DI, we move the creation and binding of the dependent objects outside of the class that depends on them.
//The Dependency Injection pattern involves 3 types of classes.

//Client Class: The client class (dependent class) is a class which depends on the service class
//Service Class: The service class (dependency) is a class that provides service to the client class.
//Injector Class: The injector class injects the service class object into the client class.
//the injector class creates an object of the service class, and injects that object to a client object

//there are basically three types of Di
//Constructor Injection:
//In the constructor injection, the injector supplies the service (dependency) through the client class constructor.

//Property Injection: In the property injection (aka the Setter Injection), the injector supplies the dependency through a public property of the client class.

//Method Injection: In this //type of injection, the client class implements an interface which declares the method(s) to supply the dependency and the injector uses this interface to supply the dependency to the client class.

//in breif client class demands for service ,service class provide it and to maintain loose coupling 
//we satisfy the need of client through a injector and we return an object of service class 
//through constructor ,property,Method






//what is IOC container
//The IoC container is a framework used to manage automatic dependency injection throughout the application,
//so that we as programmers do not need to put more time and effort into it.
//It automatically manage object and also injects all the dependency objects through a constructor, a property or a method
//at run time and disposes it at the appropriate time.
//This is done so that we don't have to create and manage objects manually.


//what is middleware
//A middleware is nothing but a component (class) which is executed on every request in ASP.NET Core application.
//middleware is connfigured in the configure method of the startup.cs class using IApplicationBuilder instance.


//what is JWT
//json web token
//JWT stands for JSON Web Token digitally signed using a secret key by a token provider.
//It helps the resource server to verify the token data using the same secret key.

//JWT consists of three parts:

//Header: encoded data of the token type and the algorithm used to sign the data.
//Payload: encoded data of claims intended to share.
//Signature: created by signing (encoded header + encoded payload) using a secret key.
//Header contains algorithm & type of token which is jwt
//Payload contains claims (key/value pairs) + expiration date + aud/issuer etc. 
//Signature is HASH value computed using Base64(Header) +"." + Base64(Payload).
//This information is passed to an algorithm with a secret key.

























