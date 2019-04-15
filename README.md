# QueueSubscriber

## Prerequisites
Ensure you have a RabbitMQ up and running on localhost. If not run the following:

Pull the docker image

`docker pull rabbitmq:3-management`

Run the docker image in a container

`docker run -d --network my-rabbit --hostname rabbithost --name rabbitmng -p 8081:15672 -p 5672:5672 rabbitmq:3-management`

In a browser go to http://localhost:8081. You sould see the management log in screen for RabbitMQ. Use the default username and password "guest"

## Run the app
This is a .Net Core 2.0 console application. 

- Clone the repo to a local directory (e.g. c:\git\myrepo)
- Go to powershell or command line to that directory and build the application

`dotnet build`
- Once the application has been build successfully, publish the application 

`dotnet publish QueueSubscriber/QueueSubscriber.csproj -c Release -o /mysubapp`
- Once successfully published go to the directory where your project was published to 

`cd /mysubapp`
- Run the following command to start the console application and listen to Rabbit

`dotnet .\QueueSubscriber.dll`

The console application will appear and will connect to the RabbitMQ instance. It will consume any messages currently on the queue. It will convert the message into “Hello {ReceivedName}, I am your father!” and display it in the console.
