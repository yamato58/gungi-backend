# 1. 開発・ビルド用の環境
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# プロジェクトファイルをコピーして復元
COPY *.csproj ./
RUN dotnet restore

# すべてのソースコードをコピーしてビルド
COPY . ./
RUN dotnet publish -c Release -o out

# 2. 実行用の軽量環境
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Renderが指定するポート（10000）で起動するための設定
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

# あなたのcsprojのファイル名に合わせてここを書き換えてください
ENTRYPOINT ["dotnet", "GunngiBackend.dll"]
