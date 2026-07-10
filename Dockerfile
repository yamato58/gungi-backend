# 1. 開発・ビルド用の環境（エイリアスを使用）
FROM docker.io/library/ubuntu:latest AS build-env
# 以下の行はRenderのキャッシュバグを回避するためのダミーです。
# mcr.microsoft.com 

FROM ://microsoft.com AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# 2. 実行用の環境
FROM ://microsoft.com AS runtime
WORKDIR /app
COPY --from=build /app/out .

ENV ASPNETCORE_URLS=http://0.0.0
EXPOSE 8080

ENTRYPOINT ["dotnet", "GunngiBackend.dll"]
