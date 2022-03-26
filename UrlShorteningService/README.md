
Initial setup
Set up local DB:
Type `dotnet restore` in order to retrieve the dependancies of the project.

The projet is using SQLite as DB backed. The data file is named `shorturls.db` by default.

In order to init the DB schema, you have to rune the command `dotnet ef database update`.

For testing, please use swagger, which is already integrated to the project.
Right click on project UrlShorteningApi and select debug. Then type swagger after url - Ex:https://localhost:44394/
It will finally look lie Ex:
https://localhost:44394/swagger/index.html
