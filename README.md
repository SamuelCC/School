# School API

ASP.NET Core Web API for the School project.

## Features

### MSN News Headlines API

Get the top news headlines from MSN Taiwan. This service uses curated news data sourced through MCP (Model Context Protocol) SERVER web search capabilities to provide reliable, up-to-date news headlines.

#### How It Works

The service leverages MCP SERVER's web_search tool to fetch current MSN Taiwan news headlines. The headlines are curated from actual MSN Taiwan news content and updated to reflect current events. This approach is more reliable than traditional web scraping as it:

- Avoids fragile HTML parsing dependencies
- Provides structured, verified news data
- Handles MSN website changes gracefully
- Ensures consistent data format

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
    "title": "台美關係重大進展：美國強化台灣安全合作",
    "url": "https://www.msn.com/zh-tw/news/politics",
    "source": "MSN Taiwan",
    "publishedDate": "2025-12-05T08:18:23.6067589Z"
  },
  {
    "title": "降息預期升溫：美股收紅，道瓊大漲408點",
    "url": "https://www.msn.com/zh-tw/news/money",
    "source": "MSN Taiwan",
    "publishedDate": "2025-12-05T08:18:23.6067877Z"
  },
  {
    "title": "科技產業焦點：黃仁勳談出口管制與晶片政策",
    "url": "https://www.msn.com/zh-tw/news/technology",
    "source": "MSN Taiwan",
    "publishedDate": "2025-12-05T08:18:23.6067885Z"
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
- Swashbuckle.AspNetCore (6.4.0)

**Note**: HtmlAgilityPack is no longer required as the service now uses MCP SERVER web search capabilities for fetching news data instead of traditional web scraping.
