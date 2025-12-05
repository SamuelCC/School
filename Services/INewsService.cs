using School.Models;

namespace School.Services
{
    public interface INewsService
    {
        Task<List<NewsHeadline>> GetTopHeadlinesAsync(int count = 3);
    }
}
