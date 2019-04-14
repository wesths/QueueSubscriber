FROM microsoft/dotnet:2.2-sdk-stretch
WORKDIR /app
WORKDIR /src
COPY ["QueueSubscriber/QueueSubscriber.csproj", "QueueSubscriber/"]
COPY ["QueueSubscriber.Service/QueueSubscriber.Service.csproj", "QueueSubscriber.Service/"]
COPY ["QueueSubscriber.Interface/QueueSubscriber.Interface.csproj", "QueueSubscriber.Interface/"]
COPY ["QueueSubscriber.Infrastructure/QueueSubscriber.Infrastructure.csproj", "QueueSubscriber.Infrastructure/"]
RUN dotnet restore "QueueSubscriber/QueueSubscriber.csproj"
COPY . .
#WORKDIR "/src/"
RUN dotnet build "QueueSubscriber/QueueSubscriber.csproj" -c Release -o /app
RUN dotnet publish "QueueSubscriber/QueueSubscriber.csproj" -c Release -o /app
WORKDIR /app
#COPY --from=publish /app .
ENTRYPOINT ["dotnet", "QueueSubscriber.dll"]