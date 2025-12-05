# School API

ASP.NET Core Web API for the School project.

## Features

### MSN News Headlines API

Get the top news headlines from MSN Taiwan. This service provides curated news data based on MCP (Model Context Protocol) SERVER web search results.

#### How It Works

The service provides curated news headlines that are sourced from MCP SERVER's web_search capabilities. The current implementation includes:

- Structured news headlines based on actual MSN Taiwan content
- Curated data reflecting current events and trending topics
- Reliable data format without fragile HTML parsing
- Graceful handling of connectivity issues

**Note**: The headlines are curated based on MCP SERVER web search results. For production use, consider integrating with MSN's official API or a real-time news aggregation service.

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
