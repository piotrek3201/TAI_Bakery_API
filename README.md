# TAI_Bakery_API

## Configuration
1. Clone or download repository
2. Open solution in Visual Studio
3. Right-click on project and choose "Manage user secrets"
4. In secrets.json put connection string to your Postgres database, for example:
```
{
  "TAI_Bakery": {
    "ConnectionString": "Server=localhost;Port=5432;Database=TAI_Bakery;User Id=postgres;Password=password;"
  }
}
```
5. Open NuGet Manager console and type:
```
Update-Database
```

## Endpoints
|HTTP Method|HTTP Endpoint|Description|Example data|
| ------------- | ------------- | ------------- | ------------- |
|GET|```/api/categories/all```|Returns all categories||
