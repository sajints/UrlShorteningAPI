URL Shortening Service
Shortening: Take a URL and return a much shorter URL.

The input URL format must be valid
Maximum character length for the hash portion of the URL is 6
The Service should return a meaningful message with a suitable status code
Additionally we would like to add an analytics feature to track the success of our service.

Analytics: Usage statistics for site owner. How many people clicked the shortened URL in the last day?

The API should provide an endpoint with the URL as input and the statistical data as result.
URLs that have been shortened should be discarded to free up the hash space.

Initial setup - Reference for Entity Framework
https://docs.microsoft.com/de-de/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
Set up local DB:
Type `dotnet restore` in order to retrieve the dependancies of the project.

The projet is using SQLite as DB backend. The data file is named `shorturls.db` by default.

In order to init the DB schema, you have to rune the command `dotnet ef database update`.

For testing, please use swagger, which is already integrated to the project.
Right click on project UrlShorteningApi and select debug. Then type swagger after url - Ex:https://localhost:44394/
It will finally look lie Ex:
https://localhost:44394/swagger/index.html


