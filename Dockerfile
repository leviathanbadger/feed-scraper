

# docker image build -t feed-scraper-api --build-arg PROJECT_PATH=src/Hosts/Leviathanbadger.FeedScraper.Host.Api/ --build-arg PROJECT_NAME=Leviathanbadger.FeedScraper.Host.Api .
# docker image build -t feed-scraper-hangfire --build-arg PROJECT_PATH=src/Hosts/Leviathanbadger.FeedScraper.Host.Hangfire/ --build-arg PROJECT_NAME=Leviathanbadger.FeedScraper.Host.Hangfire .

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
WORKDIR /opt/build
COPY projects.tar .
ARG PROJECT_PATH
ARG PROJECT_NAME
RUN tar -xvf projects.tar . && rm projects.tar && dotnet restore "${PROJECT_PATH}${PROJECT_NAME}.csproj"
COPY ./src ./src
RUN dotnet publish "${PROJECT_PATH}${PROJECT_NAME}.csproj" -c Release -o artifact

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as final
WORKDIR /opt/app
COPY --from=build /opt/build/artifact ./
ENV ASPNETCORE_URLS="http://*:80"
ARG PROJECT_NAME
ENV PROJECT_NAME=${PROJECT_NAME}
ENTRYPOINT dotnet "${PROJECT_NAME}.dll"
