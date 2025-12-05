# School API

ASP.NET Core Web API for the School project.

## Features

### MSN News Headlines API

Get the top news headlines from MSN Taiwan.

#### Endpoint

```
GET /api/news/msn/headlines
```

#### Query Parameters

- `count` (optional): Number of headlines to return. Default: 3, Range: 1-10

#### Example Request

```bash
curl http://localhost:5000/api/news/msn/headlines
```

#### Example Response

```json
[
  {
    "title": "科技新聞：人工智慧發展突破新里程碑",
    "url": "https://www.msn.com/zh-tw/news/technology",
    "source": "MSN",
    "publishedDate": "2025-12-05T08:09:19.8866133Z"
  },
  {
    "title": "經濟快訊：全球股市今日表現穩定",
    "url": "https://www.msn.com/zh-tw/news/money",
    "source": "MSN",
    "publishedDate": "2025-12-05T08:09:19.886641Z"
  },
  {
    "title": "體育新聞：國際體壇賽事精彩回顧",
    "url": "https://www.msn.com/zh-tw/news/sports",
    "source": "MSN",
    "publishedDate": "2025-12-05T08:09:19.8866412Z"
  }
]
```

#### With Count Parameter

```bash
curl "http://localhost:5000/api/news/msn/headlines?count=5"
```

## Running the Application

### Prerequisites

- .NET 8.0 SDK
- PostgreSQL (optional, for database features)

### Build and Run

```bash
# Build the project
dotnet build

# Run the application
dotnet run
```

The API will be available at `http://localhost:5000` (or the port specified in launchSettings.json).

### Development Mode

To run with Swagger UI:

```bash
dotnet run --environment Development
```

Then navigate to `http://localhost:5000/swagger` to explore the API.

## Project Structure

```
School/
├── Controllers/          # API Controllers
│   └── NewsController.cs
├── Data/                 # Database context
│   └── ApplicationDbContext.cs
├── Models/              # Data models
│   └── NewsHeadline.cs
├── Services/            # Business logic services
│   ├── INewsService.cs
│   └── MsnNewsService.cs
└── Program.cs           # Application entry point
```

## Dependencies

- Microsoft.EntityFrameworkCore.Design (9.0.6)
- Npgsql.EntityFrameworkCore.PostgreSQL (9.0.4)
- HtmlAgilityPack (1.12.4)
- Swashbuckle.AspNetCore (6.4.0)
