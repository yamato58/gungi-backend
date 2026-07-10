FROM ://microsoft.com AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM ://microsoft.com AS runtime
WORKDIR /app
COPY --from=build /app/out .

ENV ASPNETCORE_URLS=http://0.0.0
EXPOSE 8080

ENTRYPOINT ["dotnet", "GunngiBackend.dll"]
