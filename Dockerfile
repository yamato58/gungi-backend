# 1. 開発・ビルド用の環境
FROM ://microsoft.com AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# 2. 実行用の軽量環境
FROM ://microsoft.com AS runtime
WORKDIR /app
COPY --from=build /app/out .

# ★ここを「+:8080」から「http://0.0.0」に変更します
ENV ASPNETCORE_URLS=http://0.0.0
EXPOSE 8080

ENTRYPOINT ["dotnet", "GunngiBackend.dll"]
