FROM microsoft/dotnet:2.0-sdk-stretch
#ENV AppSettings_QueueHostName="my-rabbit"
WORKDIR /src
COPY ["QueueSubscriber/QueueSubscriber.csproj", "QueueSubscriber/"]
COPY ["QueueSubscriber.Service/QueueSubscriber.Service.csproj", "QueueSubscriber.Service/"]
COPY ["QueueSubscriber.Interface/QueueSubscriber.Interface.csproj", "QueueSubscriber.Interface/"]
RUN dotnet restore "QueueSubscriber/QueueSubscriber.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "QueueSubscriber/QueueSubscriber.csproj" -c Release -o /app
RUN dotnet publish "QueueSubscriber/QueueSubscriber.csproj" -c Release -o /app
WORKDIR /app
ENTRYPOINT ["dotnet", "QueueSubscriber.dll"]