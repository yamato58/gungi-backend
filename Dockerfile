# 1. 開発・ビルド用の環境
FROM ://microsoft.com AS build
WORKDIR /app

# プロジェクトファイルをコピーして復元
COPY *.csproj ./
RUN dotnet restore

# すべてのソースコードをコピーしてビルド
COPY . ./
RUN dotnet publish -c Release -o out

# 2. 実行用の軽量環境
FROM ://microsoft.com AS runtime
WORKDIR /app
COPY --from=build /app/out .

# すべての通信元からのアクセスを許可する設定
ENV ASPNETCORE_URLS=http://0.0.0
EXPOSE 8080

# あなたのcsprojのファイル名
ENTRYPOINT ["dotnet", "GunngiBackend.dll"]
