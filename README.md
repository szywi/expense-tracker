# Expense tracker

Simple expense tracker

| Folder                       | Purpouse                                                                                                               |
|------------------------------|------------------------------------------------------------------------------------------------------------------------|
| ExpenseTracker               | ASP.NET Core Web App with RESTful API                                                                                  |
| ExpenseTracker.Domain        | Business logic                                                                                                         |
| ExpenseTracker.Persistence   | Database configuration & data access layer                                                                             |

## Development

Run the following to start the backend service locally:

`dotnet run --project ExpenseTracker`

Go to `\ExpenseTracker.Web` and run the following to start the frontend service locally:

```
 // install dependencies
npm i

// compile libraries to be Ivy compatible
npm run ngcc:node_modules

npm start
```

## Database

Project requires `SQL Server Express LocalDB` to be running locally. See [Install LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15#install-localdb)

### Migrations

Run the following to configure local database

`dotnet ef database update --project .\ExpenseTracker.Persistence\ --startup-project .\ExpenseTracker\`
