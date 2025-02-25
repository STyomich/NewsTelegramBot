using Core.Entities;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class NewsService
    {
        private readonly DataContext _context;

        public NewsService(DataContext context)
        {
            _context = context;
        }

        // Create
        public async Task<News> CreateNewsAsync(News news)
        {
            _context.News.Add(news);
            await _context.SaveChangesAsync();
            return news;
        }

        // Read (Get all)
        public async Task<List<News>> GetAllNewsAsync()
        {
            return await _context.News.ToListAsync();
        }
        // Read (Get all)
        public async Task<List<News>> GetTenNewsByCategoryAsync(string category)
        {
            return await _context.News
                .Where(n => n.Category == category)
                .OrderByDescending(n => n.Date)
                .Take(10)
                .ToListAsync();
        }


        // Read (Get by Id)
        public async Task<News?> GetNewsByIdAsync(Guid id)
        {
            return await _context.News.FindAsync(id);
        }

        // Update
        public async Task<bool> UpdateNewsAsync(News updatedNews)
        {
            var existingNews = await _context.News.FindAsync(updatedNews.Id);
            if (existingNews == null) return false;

            _context.Entry(existingNews).CurrentValues.SetValues(updatedNews);
            await _context.SaveChangesAsync();
            return true;
        }

        // Delete
        public async Task<bool> DeleteNewsAsync(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news == null) return false;

            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}